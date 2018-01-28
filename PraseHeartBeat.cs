using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseHeartBeat : JT808
    {
        public static byte HeartBeatACK(byte[] msgbody, ref string info, out byte rssi)
        {
            int oft = 0;
            /*
            0 信号强度 BYTE 

                0           -113 dBm or less
                1           -111 dBm
                2...30      -109... -53 dBm
                31          -51 dBm or greater
                99...255    not known or not detectable             
            */
            rssi = msgbody[oft++];

            info += "信号强度RSSI=" + rssi.ToString() + "\r\n";

            //
            return ACK_SUCCESS;
        }
    }
}
