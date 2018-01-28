using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.TOOLS
{
    class Hex
    {
        public static string ToString(byte[] bytes, int index, int count, string separator, string preamble)
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str += preamble + bytes[index + i].ToString("X2") + separator;
            }
            return str;
        }

        public static string ToString(byte[] bytes, int index, int count)
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str += bytes[index + i].ToString("X2") + " ";
            }
            return str;
        }
        public static string ToString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += bytes[i].ToString("X2") + " ";
            }
            return str;
        }

        /// <summary>
        /// BCD编码字符串转换为字节数组 字符串（13777840014）-> 字节数组（0x13，0x77，0x84...）
        /// </summary>
        /// <param name="bcd"></param>
        /// <returns></returns>
        public static byte[] FromBCDString(string str)
        {
            string str2 = str.Replace("0x", "");
            string str3 = "";
            foreach (char c in str2)
            {
                if (((c >= '0') && (c <= '9')) ||
                    ((c >= 'a') && (c <= 'f')) ||
                    ((c >= 'A') && (c <= 'F')))
                {
                    str3 += c;
                }
            }
            byte[] bytes = new byte[str3.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(str3.Substring(i * 2, 2));
            }
            return bytes;
        }


        public static byte[] FromHEXString(string str)
        {
            string str2 = str.Replace("0x", "");
            string str3 = "";
            foreach (char c in str2)
            {
                if (((c >= '0') && (c <= '9')) ||
                    ((c >= 'a') && (c <= 'f')) ||
                    ((c >= 'A') && (c <= 'F')))
                {
                    str3 += c;
                }
            }

            byte[] bytes = new byte[str3.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(str3.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}
