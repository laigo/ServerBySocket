using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using int16_t = System.Int16;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using WORD = System.UInt16;
using System.Runtime.InteropServices;
using WindowsFormsApplication1;
using System.Threading;


namespace ServerBySocket
{
    public class JT808 : MsgID
    {
        //常量定义
        const UInt16 PACKAGE_MAX = 1500; //包最大长度：帧标志1+消息头16+消息体1024+校验1+帧标志1=1043

        const UInt16 MSG_HEADER_LENGTH = 13;//消息头的长度(未分包)		
        const UInt16 MSG_SUBPACKET_HEADER_LENGTH = 17;//消息头的长度(分包)		

        const byte PACKET_HEAD_NET = (0x7e);

        const byte FOF = PACKET_HEAD_NET;
				
        const byte EEOF = (0x7e);
				
        const byte ESC_CHAR_H7D = 0x7d;//转义字符
        const UInt16 MSG_LEN_MAX = 1024;//消息体最大长度

        const UInt16 PACKAGE_MIN = 13;//最小的包长度：消息头12 + 校验1 

        //应答结果
        public const byte ACK_SUCCESS					=0;//成功/确认
        public const byte ACK_FAILED					=1;//失败
        public const byte ACK_WRONG_MSG				    =2;//消息有误
        public const byte ACK_NOT_SUPPORT				=3;//不支持
        public const byte ACK_NONE					    =4;//不应答
        public const byte ACK_MISMATCH				    =5;//设备号不匹配
        public const byte ACK_SUB						=6;//分包应答
        public const byte ACK_DECRYPT_ERR				=7;//解密错误


        public static UInt16 PlatDownSerialNum;
        public byte[] PackData = new byte[PACKAGE_MAX];//发送缓存区:帧组包后的数据
        public byte[] unPackData = new byte[PACKAGE_MAX];//接收缓存区:帧解包后的数据

        public uint16_t PlatsendLength;
        public static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        //清空应答流水号池
        public static List<UInt16> sn_pond = new List<UInt16>();


        public JT808()
        {
            PlatsendLength = 0;
        }

        public delegate string DataSentHandler(byte[] pBuf, int index, uint16_t length, string endPoint);
        public event DataSentHandler TCPSent;
        public event DataSentHandler UARTSent;

        public delegate void DataDisHandler(string msg, string ipClient);
        public event DataDisHandler DataDis;




        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBufIn"></param>
        /// <param name="len"></param>
        /// <param name="pBufOut"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public static bool Unpack(byte[] pBufIn, int len, byte[] pBufOut, out int Len)
        {
            int i, k;

	        for (i = 0, k = 0; i < len; i++, k++)
	        {
		        if (pBufIn[i] == ESC_CHAR_H7D)
		        {
			        if (pBufIn[i + 1] == 0x01) // 0x7d字符
			        {
				        pBufOut[k] = 0x7d;
				        ++i; //跳过转义字符
			        }
			        else if (pBufIn[i + 1] == 0x02) // 0x7e字符
			        {
				        pBufOut[k] = 0x7e;
				        ++i; //跳过转义字符
			        }
			        else
				        pBufOut[k] = pBufIn[i];
		        }
		        else
		        {
			        pBufOut[k] = pBufIn[i];
		        }
		        //bcc ^= pBufOut[k];
	        }

            if (k <= 2)
            {//至少包含2字节CRC16 + n byte (n>0)
                Len = 0; 
                return false;                
            }
            else
            {
                Len = k - 2;
            }
            
            return (CRC.GetCRC16(pBufOut, Len) == BitConverter.ToUInt16(pBufOut, Len)) ? true : false;
        }
        uint16_t Pack(byte[] pBufIn, uint16_t len, byte[] pBufOut)
        {
	        uint16_t bcc = 0;
	        uint8_t l_cc, h_cc;

	        uint16_t i, k = 0;


	        //原始数据CRC计算
            bcc = CRC.GetCRC16(pBufIn, len);
	        h_cc = (uint8_t)(bcc >> 8);
	        l_cc = (uint8_t)bcc;

	        //消息头
	        pBufOut[k] = FOF;
	        k += 1;

	        // + 消息体 
	        for (i = 0; i < len; i++, k++)
	        {
		        /*
		        bcc^=pBufIn[i]; //计算bcc
		        //转义处理
		        */
		        if (pBufIn[i] == 0x7e)
		        {
			        pBufOut[k++] = ESC_CHAR_H7D;
			        pBufOut[k] = 2;
		        }
		        else if (pBufIn[i] == 0x7d)
		        {
			        pBufOut[k++] = ESC_CHAR_H7D;
			        pBufOut[k] = 1;
		        }
		        else
			        pBufOut[k] = pBufIn[i];
	        }

	        //bcc 的转义处理
	        if (l_cc == 0x7e)
	        {
		        pBufOut[k++] = ESC_CHAR_H7D;
		        pBufOut[k++] = 2;
	        }
	        else if (l_cc == 0x7d)
	        {
		        pBufOut[k++] = ESC_CHAR_H7D;
		        pBufOut[k++] = 1;
	        }
	        else
	        {
		        pBufOut[k++] = (uint8_t)l_cc;
	        }

	        if (h_cc == 0x7e)
	        {
		        pBufOut[k++] = ESC_CHAR_H7D;
		        pBufOut[k++] = 2;
	        }
	        else if (h_cc == 0x7d)
	        {
		        pBufOut[k++] = ESC_CHAR_H7D;
		        pBufOut[k++] = 1;
	        }
	        else
	        {
		        pBufOut[k++] = (uint8_t)h_cc;
	        }

	        pBufOut[k++] = EEOF;

	        return k;
        }

        //[StructLayout(LayoutKind.Explicit, Size=16, CharSet=CharSet.Ansi)]

        public struct  MESSAGE_TIME_TAG
        {
            public uint8_t year;
            public uint8_t month;
            public uint8_t day;
            public uint8_t hour;
            public uint8_t minute;
            public uint8_t second;
        };

        public struct MESSAGE_SUB_PACKAGE
        {
	        public WORD total;//消息包总数
	        public WORD No;//包序号
        } ;

        public class MESSAGE_HEAD_TYPE
        {
            public WORD id;//消息ID
            public WORD property;//消息属性

            public WORD msgLengthBit0_9;
            public bool resBit10;       //临时定义为主动上报标识
            public byte encryptBit11_12;
            public bool subBit13;
            public bool timeTagBit14;
            public bool resBit15;


            public byte[] TerminalId = new byte[6]; //终端ID
	        //BCD                                 
            public byte[] mobileNumber = new byte[7];
	        //BCD	
            public WORD serialNumber; //终端流水号

            public MESSAGE_SUB_PACKAGE subPackage;//消息分装项

            public MESSAGE_TIME_TAG timeTag;
        }

        public MESSAGE_HEAD_TYPE message_head = new MESSAGE_HEAD_TYPE();


        byte[] pMsgHeader = new byte[PACKAGE_MAX]; 

        public void GenerateMsgHeader()
        {
            int oft = 0;

            //消息ID
            Bytes.FromUInt16(message_head.id, pMsgHeader, oft);
            oft += 2;

            //消息体属性字
            message_head.property = message_head.msgLengthBit0_9;
            if (message_head.resBit10)
            {
                message_head.property |= (1 << 10);
            }

            message_head.property |= (WORD)(message_head.encryptBit11_12 << 11);

            if (message_head.subBit13)
            {
                message_head.property |= (1 << 13);
            }

            if (message_head.timeTagBit14)
            {
                message_head.property |= (1 << 14);
            }

            if (message_head.resBit15)
            {
                message_head.property |= (1 << 15);
            }
            Bytes.FromUInt16(message_head.property, pMsgHeader, oft);
            oft += 2;


            //终端手机号码
            Array.Copy(pMsgHeader, oft, message_head.mobileNumber, 0, message_head.mobileNumber.Length);
            oft += message_head.mobileNumber.Length;

            //消息流水号
            Bytes.FromUInt16(PlatDownSerialNum, pMsgHeader, oft);
            oft += 2;

            //消息包封装项
            if (message_head.subBit13)
            {
                Bytes.FromUInt16(message_head.subPackage.total, pMsgHeader, oft);
                oft += 2;//--WORD 消息包总数				


                Bytes.FromUInt16(message_head.subPackage.No, pMsgHeader, oft);
                oft += 2;//--WORD 包序号		

            }


            /*平台流水号处理*/
            //Mark_UpLink_Serailnum(pHeader->id, g_sendSerialNumber);

            if ((message_head.subBit13 == false) ||
                ((message_head.subBit13) && (message_head.subPackage.total == message_head.subPackage.No))//分包数据最后一包流水号+1
            )
            {
                PlatDownSerialNum++;
            }
        }

        public string JT_SendBuf(uint8_t srvProfileId,byte[] pIdata,uint16_t uwlen,string endPoint)
        {
            string info = string.Empty;

            if (TCPSent != null)
            {
                info+=TCPSent(pIdata, 0, uwlen, endPoint);
            }
            if (UARTSent != null)
            {
                info += UARTSent(pIdata, 0, uwlen, endPoint);
            }
            return info;
        }

        public int PackageFrame(UInt16 msgid, byte[] pMessageBody, UInt16 ackSerialNumber, bool dir, string endPoint)
        {
            byte[]  Frame =      new byte[PACKAGE_MAX]; 
	        

            int oft=0;
            uint16_t _sendLength;
	       
            /*消息id*/
            message_head.id = msgid;

	        /*消息头长度*/
	        uint8_t _MsgHeader_Len = (byte)MSG_HEADER_LENGTH;
	
	        /*数据分包 +4字节消息分包项*/
            if  (Bits.GetbitValue(message_head.property,13)==1)
            {
                _MsgHeader_Len+=4;
            }

	
	        /*时间标签 +6字节(BCD) DATETIME*/
            if  (Bits.GetbitValue(message_head.property,14)==1)
            {
		        _MsgHeader_Len+=6;
            }

	        /*帧偏移_MsgHeader_Len字节到消息体*/
	        oft += _MsgHeader_Len;
	
	        /*消息体---应答消息ID*/
	        if(dir)
            {
		        Bytes.FromUInt16(ackSerialNumber, Frame, oft);
		        oft+=2;
	        }
	
	        /*消息体--数据DATA*/
            Array.Copy(pMessageBody, 0, Frame, oft, message_head.msgLengthBit0_9);
            oft += message_head.msgLengthBit0_9;

            message_head.msgLengthBit0_9 += (UInt16)(dir ? 2 : 0);

	        /*消息体---RSA加密*/
            if  (Bits.GetbitValue(message_head.property,13)==1)
		    {

	        }
	
	        /*生成消息头*/
	        GenerateMsgHeader();
            Array.Copy(pMsgHeader, 0, Frame, 0, _MsgHeader_Len);
	
	        /*帧组包--+帧头+ 转义+ CRC16+ 帧尾巴*/
            _sendLength = Pack(Frame, (uint16_t)oft, PackData); //打包

            PlatsendLength = _sendLength;
	        /*数据发送*/

            LogHelper.WriteLog(typeof(JT808), Hex.ToString(PackData, 0,  _sendLength));


            if (endPoint == string.Empty)
            {
                endPoint = MsgData._myData.TheValue;
            }

            string promptInfo = JT_SendBuf(0, PackData, _sendLength, endPoint);
            
            if (DataDis != null)
            {
                DataDis(Hex.ToString(PackData, 0, _sendLength), promptInfo);
            }
            return 0;
        }



        //命令解析、处理和消息通知
        public static byte[] Process_jt808_Package(byte[] pPackage, int packageLength, ref string returnstr, out UInt16 msgid, out UInt16 serial_number, out string telnumstr)
        {
            int oft = 0;
            //消息ID
            msgid = BitConverter.ToUInt16(pPackage, oft);
            oft += 2;

            UInt16 property = BitConverter.ToUInt16(pPackage, oft);
            oft += 2;

            //终端手机号 
            byte[] mobileNumber = new byte[7];
            Array.Copy(pPackage, oft, mobileNumber, 0, 7);
            oft += 7;

            telnumstr = Hex.ToString(mobileNumber, 0, mobileNumber.Length, "", "");
            returnstr += "TelNum=" + telnumstr + "\r\n";                


            //消息流水号
            serial_number = BitConverter.ToUInt16(pPackage, oft);
            oft += 2;

            //消息包封装项
            
            //时间标签

            int msglen= packageLength - oft;
            if(msglen<0)
            {
                returnstr+="消息体长度异常";
                return null; 
            }


            byte[] msgbody = new byte[packageLength - oft];
            Array.Copy(pPackage, oft, msgbody, 0, msglen);

            return msgbody;
        }


    }
}
