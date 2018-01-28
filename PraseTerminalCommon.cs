using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseTerminalCommon : JT808
    {
        //对应的终端消息的流水号
        public static byte CommonACK(byte[] msgbody, ref string info)
        {
            UInt16 ackMsgId,ackSN;
            byte ackRet;

            int oft = 0;

            //判断格式
            if (msgbody.Length != 5)
            {
                info += "帧格式错误!";
                return ACK_WRONG_MSG;
            }

            //应答流水号-WORD
            ackSN = BitConverter.ToUInt16(msgbody, oft);
            oft += 2;
            info += "应答流水号=" + ackSN.ToString("x4") + "\r\n";
            

            //应答ID-WORD
            ackMsgId = BitConverter.ToUInt16(msgbody, oft);
            oft += 2;
            info += "应答ID=" + ackMsgId.ToString("x4") + "\r\n";
            

            //应答结果-BYTE
            ackRet = msgbody[oft++];
            info += "应答结果=" + ackRet.ToString();


            int index = sn_pond.IndexOf(ackSN);
            if (index != -1)
            {
                sn_pond.RemoveAt(index);

                if (ackRet == 0)
                {
                    autoResetEvent.Set();
                }
            }
            else
            {
                return ACK_NONE;
            }
            return ACK_NONE;
        }
    }
}
