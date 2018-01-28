using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseSwitchTime : JT808
    {

        public static byte TmpSwitchTimeAck(byte[] msgbody, ref string info)
        {
            int oft = 0;
            /*
            0 应答流水号 WORD 
            2 临时开关策略  
            */
            oft += 2;

            //BCD[0]时 ，BCD[1]分
            info += "开灯时间:" + msgbody[oft++].ToString("x2") + "：" + msgbody[oft++].ToString("x2") + "\r\n";
            info += "关灯时间:" + msgbody[oft++].ToString("x2") + "：" + msgbody[oft++].ToString("x2") + "\r\n";

            //BCD[0]年，BCD[1]月，BCD[2]日
            info += "执行日期:" + msgbody[oft++].ToString("x2") + "-" + msgbody[oft++].ToString("x2") + "-" + msgbody[oft++].ToString("x2") + "\r\n";

            info += "执行天数:" + msgbody[oft++].ToString("") + "\r\n";

            return ACK_NONE;
        }



        public static byte JwdSwitchTimeAck(byte[] msgbody, ref string info)
        {
            int oft = 0;
            /*
            0 应答流水号 WORD 
            2 开关时间 1 DWORD
            开关时间 2 DWORD
            ...
            开关时间 N DWORD 
            */
            oft += 2;

            int days = (msgbody.Length-2)/4;


            for (int i = 0; i < days; i++)
            {
                info += "开关时间:" + BitConverter.ToUInt32(msgbody,oft).ToString("x8") + "\r\n";
                oft += 4;
            }
            return ACK_NONE;
        } 
    }
}
