using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseTimeCtrl : JT808
    {

        public static byte TimeCtrlAck(byte[] msgbody, ref string info)
        {
            int oft = 0;
            /*
            0 应答流水号 WORD 

            
            */
            oft += 2;

            /*
            配置字节
            时段数    预留       时间              启用标志
            Bit7~4    Bit3~2     Bit1               Bit0
            0~8                  0: 相对时间        0: 禁用
                                 1: 绝对时间        1: 启用 
            */
            byte cfgByte = msgbody[oft++];
            info += "启用标志:" + (Bits.GetbitValue(cfgByte,0)==0 ? "禁用" : "启用") + "\r\n";
            info += "时间:" + (Bits.GetbitValue(cfgByte, 1) == 0 ? "相对时间" : "绝对时间") + "\r\n";
            info += "时段数:" + ((byte)(cfgByte>>4)).ToString() + "\r\n";

            //时段选择标志位
            byte gradeMask = msgbody[oft++]; 

            for (int i = 0; i < 8; i++)
            {
                if (Bits.GetbitValue(gradeMask, i) == 1)
                {
                    info += ("时段:" + (i + 1).ToString()) + "\r\n";

                    /*
                    0 路数选择标志位 BYTE 
                    1 时段策略 
                        0 0x00~0x23 小时 
                        1 0x00~0x59 分钟 
                        2 0x00~0xFF 第 1 路控制值 
                    */
                    byte channelMask  = msgbody[oft++];
                    info += "时间："+ msgbody[oft++].ToString("x2") + "时 -" + msgbody[oft++].ToString("x2") + "分\r\n";   

                    for (int j = 0; j < 8; j++)
                    {
                        if (Bits.GetbitValue(channelMask, j) == 1)
                        {
                            info += msgbody[oft++].ToString()+ ",";                       
                        }
                    }
                    info += "\r\n";
                }          
            }
            return ACK_NONE;
        }

    }
}
