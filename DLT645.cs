using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.IO;


namespace QF
{
    class DLT645
    {
        /* Protocol control ASCII characters */
        public const byte  SOH =0x01;
        public const byte  STX =0x02;
        public const byte  EOT =0x04;
        public const byte  XMODE_ACK =0x06;
        public const byte  NAK =0x15;
        public const byte  COH =0x43;
        public const byte  DUMP=0x1a;

        public const byte  DLT645_SOF =0x68;
        public const byte  DLT645_END =0x16;



        public static int Build_Package(byte[] pFrame, byte[] pDstaddr,    byte[] pIdata, byte len, byte Ctl)
        {
            byte u8PkCs = 0;

	        byte oft = 0;

	        //帧起始符
            pFrame[oft++] = DLT645_SOF;

	        //地址域	A0,A1....A5
            for (byte i = 0; i < 6; i++) {
                pFrame[oft++] = pDstaddr[i];
            }

	        //帧起始符
            pFrame[oft++] = DLT645_SOF;
	
	        //传输方向
            pFrame[oft++] = Ctl;
            pFrame[oft++] = len;

	        //转译  +0X33 处理
            /*
            for (byte i = 0; i < len; i++)
            {
		        pIdata[i] += 0x33;
	        }
            */

            for (byte i = 0; i < len; i++) {
                pFrame[oft++] = (byte)(pIdata[i] + 0x33);
            }

	        //从第一个帧起始符开始到校验码之前的所有各字节的模 256 的和
            for (byte i = 0; i < oft; i++)
            {
                u8PkCs += pFrame[i];
	        }
            pFrame[oft++] = u8PkCs;

            pFrame[oft++] = DLT645_END;

	        return (oft);
        }

        public static byte[] Escape_MsgBody(byte[] pMsgBody,int index, int len)
        {
            byte[] buf = new byte[len]; 

            //数据域转义 -H33
            if (len != 0)
            {
                for (int i = 0; i < len; i++)
                {
                    byte u8tmp = (byte)(pMsgBody[index++] - (byte)0x33);
                    buf[i] = u8tmp;              
                }
            }

            return buf;
        }

        public static int[] EsxCfgFeildLen = {2, 2, 6, 4, 4, 4, 4, 12, 12 };
        public static int[] EsxStaFeildLen = { 2, 2, 6, 4, 4, 4, 4, 12, 12 }; 

    }
}
