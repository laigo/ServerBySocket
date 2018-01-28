using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseEvent : JT808
    {

        public struct EventClass
        {
            public byte erc;
            public byte len;
            public byte[] content;
        }



        public static byte EVENT(byte[] msgbody, UInt16 sn, EventClass[] eventrecord, ref UInt16 event_count, ref string info)
        {
            /*
            0   事件总数          N WORD
            2   事件1             BYTES 
            …   …
                事件N             BYTES
            */
            int oft = 0;

            event_count = BitConverter.ToUInt16(msgbody, oft);
            oft += 2;
            info += "事件总数=" + event_count.ToString() + "\r\n";
            /*
            事件代码 ERC          BYTE            注：erc=15 等价于 erc=0x0F
            事件记录长度 Le       BYTE
            事件记录内容
            Byte_1
            ……
            事件记录内容
            Byte_Le
            */ 
            for(int i= 0;i< event_count;i++)
            {
                byte ERC_Code = msgbody[oft++];
                info += "事件代码 ERC=" + ERC_Code.ToString() + "\r\n";
                eventrecord[i].erc = ERC_Code;
                     
                byte ERC_Context_Len = msgbody[oft++];
                info += "事件代码 Le=" + ERC_Context_Len.ToString() + "\r\n";
                eventrecord[i].len = ERC_Context_Len;

                byte[] ERC_ContextBuf = new byte[ERC_Context_Len];
                Array.Copy(msgbody, oft, ERC_ContextBuf, 0, ERC_Context_Len);

                oft += ERC_Context_Len;
                info += "事件记录内容=" + Hex.ToString(ERC_ContextBuf) + "\r\n";

                //eventrecord[i].content = new Byte[ERC_Context_Len];
                //Array.Copy(eventrecord[i].content, ERC_ContextBuf, ERC_Context_Len);
                eventrecord[i].content = ERC_ContextBuf;
            }          
            return ACK_SUCCESS;
        }

    }
}
