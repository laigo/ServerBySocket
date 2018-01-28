using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseLogin : JT808
    {
        public static byte LoginACK(byte[] msgbody, UInt16 sn, ref string info)
        {
            int oft = 0;

            //判断格式

            if (msgbody.Length != (2 + 2 + 5 + 8))
            {
                info += "帧格式错误!";
                return ACK_WRONG_MSG;
            }             
            /*
            0 省域 ID WORD 
            2 市县域 ID WORD 
            4 制造商 ID BYTE[5] 
            9 终端型号 BYTE[8] 
            */

            UInt16 ProvinceID = BitConverter.ToUInt16(msgbody, oft);
            oft += 2;
            info += "省域 ID=" + ProvinceID.ToString("x4") + "\r\n";



            UInt16 CityID = BitConverter.ToUInt16(msgbody, oft);
            oft += 2;
            info += "市县域 ID=" + CityID.ToString("x4") + "\r\n";

           
            byte[] ManufacturerInfo = new byte[5];
            Array.Copy(msgbody, oft, ManufacturerInfo, 0, ManufacturerInfo.Length);
            info += "制造商 ID=" + System.Text.Encoding.ASCII.GetString(ManufacturerInfo) + "\r\n";

            
            byte[] TerminalType = new byte[8];
            Array.Copy(msgbody, oft, TerminalType, 0, TerminalType.Length);
            info += "终端型号 ID=" + System.Text.Encoding.ASCII.GetString(TerminalType) + "\r\n";

            return ACK_SUCCESS;
        }
    }
}
