using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseStatus : JT808
    {
        public static byte StatusACK(byte[] msgbody, ref string info, string[] lampinfo,ref string devRTCinfo)
        {
            int oft = 0;

            //判断格式
            /*
            if (len != 5)
            {
                return returnstr += "帧格式错误!";
            }             
            */

            //2G单灯

            //0 应答流水号 WORD
            info += "应答流水号=" + BitConverter.ToUInt16(msgbody, oft).ToString("x4") + "\r\n";
            oft += 2;
            //2 控制模式 WORD
            info += "控制模式=" + BitConverter.ToUInt16(msgbody, oft).ToString("x4") + "\r\n";
            oft += 2;
            //3 设备状态 WORD
            info += "设备状态=" + BitConverter.ToUInt16(msgbody, oft).ToString("x4") + "\r\n";
            oft += 2;
            //7 设备时间
            devRTCinfo = "20"
                + msgbody[oft++].ToString("x2") + "-" //年
                + msgbody[oft++].ToString("x2") + "-" //月
                + msgbody[oft++].ToString("x2") + " "//日
                + msgbody[oft++].ToString("x2") + ":"//时
                + msgbody[oft++].ToString("x2") + ":"//分
                + msgbody[oft++].ToString("x2") + "\r\n";//秒                
            info += "设备时间" + devRTCinfo;
    
            //13 设备累计运行时间 DWORD
            info += "设备累计运行时间=" + BitConverter.ToUInt32(msgbody, oft) + "\r\n";
            oft += 4;
            //17 本次开灯运行时间 WORD
            info += "本次开灯运行时间=" + BitConverter.ToUInt16(msgbody, oft) + "\r\n";
            oft += 2;
            //22 水浸 BYTE
            info += "水浸=" + msgbody[oft++].ToString() + "\r\n";
            //23 设备复位次数 BYTE
            info += "设备复位次数=" + msgbody[oft++].ToString() + "\r\n";
            //24 应答状态包N BYTE
            byte ack_n =msgbody[oft++];
            info += "应答状态包个数=" + ack_n.ToString() + "\r\n";

            //状态包格式定义
            for (int ChCol_n = 0; ChCol_n < ack_n; ChCol_n++)
            {
                string tmpstr = string.Empty;

                //0 灯盏回路号 BYTE 范围（1~4）
                byte ch = msgbody[oft++];
                info += "灯盏回路号=" + ch.ToString() + "\r\n";

                //1 开关档位 BYTE 0:关；100~255:全开， 1~99-节能模式；
                byte switchgear = msgbody[oft++];
                info += "开关档位=" + switchgear.ToString() + "\r\n";
                tmpstr += switchgear.ToString() + ",";

                //2 电压 WORD 单位V
                UInt16 volt = BitConverter.ToUInt16(msgbody, oft);
                oft += 2;
                info += "电压=" + volt.ToString() + "V\r\n";
                tmpstr += volt.ToString() + "v ,";
                

                //4 电流 WORD 单位mA
                UInt16 cur = BitConverter.ToUInt16(msgbody, oft);
                oft += 2;
                info += "电流=" + cur.ToString() + "mA\r\n";
                tmpstr += cur.ToString() + "ma ,";
                

                //6 有功 WORD 单位W
                UInt16 pwr = BitConverter.ToUInt16(msgbody, oft);
                oft += 2;
                info += "有功=" + pwr.ToString() + "W\r\n";
                tmpstr += pwr.ToString() + "w ,";


                //8 灯盏报警 BYTE 预留 灯灭故障 过流报警 继电器故障 光源故障 功率因数故障 Bit7~5 Bit4 Bit3 Bit2 Bit1 Bit0
                byte lampalarm = msgbody[oft++];
                info += "灯盏报警=" + lampalarm.ToString("x") + "\r\n"; ;
                tmpstr += lampalarm.ToString("x2") + ",";

                //9 自熄灯次数 BYTE 单位:次
                info += "自熄灯次数=" + msgbody[oft++].ToString("x") + "\r\n";

                //10 预留 BYTE[2]
                info += "预留WORD=" + BitConverter.ToUInt16(msgbody, oft) +"\r\n";
                oft += 2;

                if ((ch >= 1) && (ch <= 4))
                {
                    lampinfo[ch-1] = tmpstr;
                } 
            }
            return ACK_NONE;
        }

    }
}
