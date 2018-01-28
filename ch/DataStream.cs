using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.CHANNEL
{
    public abstract class  DataStream: Port
    {
        List<byte> pkt_buf = new List<byte>();

        public void DataReceived(Port port, byte[] buf)
        {
            pkt_buf.AddRange(buf);

            /*帧格式：[7EH .... 7EH]*/
            int start_index, end_index;

            while (true)
            {
                //定位到帧头
                start_index = pkt_buf.IndexOf(0x7E);
                if (start_index == -1)
                {
                    pkt_buf.Clear();
                    return;
                }
                pkt_buf.RemoveRange(0, start_index);

                //帧尾
                end_index = pkt_buf.IndexOf(0x7E,1);
                if (end_index == -1)
                {
                    return;
                }

                if (end_index < (1+2+1))
                {
                    pkt_buf.RemoveRange(0, end_index);
                    continue;
                }

                //break;

                int byte_count = end_index + 1;

                byte[] rx_buf = new byte[byte_count];
                Array.Copy(pkt_buf.ToArray(), rx_buf, byte_count);
                pkt_buf.RemoveRange(0, byte_count);

                RxEventArgs args = new RxEventArgs();
                args.buf = rx_buf;
                port.PktRecv(this, args);
            }
        }
    }
}
