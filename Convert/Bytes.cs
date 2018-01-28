using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.TOOLS
{
    class Bytes
    {
        /// <summary>
        /// WORD 小端字节数组
        /// </summary>
        /// <param name="bcd"></param>
        /// <returns></returns>
        public static void FromUInt16(UInt16 val, byte[] bytes, int index)
        {
            const int len = 2;
            for (int i = 0; i < len; i++)
            {
                bytes[index + i] = (byte)(val >> (8 * i));
            }
        }
        /// <summary>
        /// DWORD 小端字节数组
        /// </summary>
        /// <param name="bcd"></param>
        /// <returns></returns>
        public static void FromUInt32(UInt32 val, byte[] bytes, int index)
        {
            const int len = 4;
            for (int i = 0; i < len; i++)
            {
                bytes[index + i] = (byte)(val >> (8 * i));
            }
        }

        /// <summary>
        /// 十六进制字符串转换为字节数组
        /// </summary>
        /// <param name="bcd"></param>
        /// <returns></returns>
        public static byte[] FromStr(string hexString)
        {
            hexString = hexString.Replace(',', ' ');  //去掉英文逗号
            hexString = hexString.Replace('，', ' '); //去掉中文逗号

            hexString = hexString.Replace("0x", "");   //去掉0x
            hexString = hexString.Replace("0X", "");   //去掉0X


            hexString = hexString.Replace(" ", "");



            if ((hexString.Length % 2) != 0)
            {
                //hexString = hexString.Insert(hexString.Length - 1, "0");
                hexString = hexString.Insert(0, "0");
            }


            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return returnBytes;
        }
    }
}
