using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseTerminalCfg : JT808
    {
        public static byte TerminalCfgACK(byte[] msgbody, ref string info)
        {
            //消息体剩余长度
            int remainLen = msgbody.Length;
            if (remainLen < 2)
            {
                
                return ACK_WRONG_MSG;
            }

            int oft = 0;
            //0 应答流水号 WORD
            info += "应答流水号=" + BitConverter.ToUInt16(msgbody, oft).ToString("x4") + "\r\n";
            oft+=2;

            //2 包参数个数 BYTE
            byte par_cnt = msgbody[oft++];

            //3 参数项列表 
                /*
                参数 ID DWORD 
                参数长度 BYTE 
                参数值 
                 */
            for (int i = 0; i < par_cnt; i++)
            {
                UInt32 par_id = BitConverter.ToUInt32(msgbody, oft);
                oft += 4;
                info += "参数 ID=" + par_id.ToString("x4") + "\r\n";

                byte par_len = msgbody[oft++];
                info += "参数 LEN=" + par_len.ToString() + "\r\n";

                info += "参数 Value=" + Hex.ToString(msgbody, oft, par_len, " ", "") + "\r\n";
                oft += par_len;

                //消息体内容出错,容错，todo?
                if (oft >= remainLen)
                {
                    break;
                }
            }
            return ACK_NONE;
        }



    }
}
