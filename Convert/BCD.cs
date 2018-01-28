using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.TOOLS
{
    class BCD
    {
        /// <summary>
        /// 单字节BCD格式转换到实际值(0x99 -> 0d99)
        /// </summary>
        /// <param name="bcd">BCD格式数据(范围:0x00 ~ 0x99)</param>
        /// <returns></returns>
        public static byte ToByte(int bcd)
        {
            if (((bcd & 0xF) > 9) || (((bcd >> 4) & 0xF) > 9))
                throw new ArgumentOutOfRangeException("bcd", bcd, "BCD Value Incorrect.");
            return (byte)((bcd & 0xF) + ((bcd >> 4) & 0xF) * 10);
        }
        /// <summary>
        /// 单字节BCD格式转换到实际值(0x99 -> 0d99)
        /// </summary>
        /// <param name="bcd">BCD格式数据(范围:0x00 ~ 0x99)</param>
        /// <returns></returns>
        public static byte ToByte(byte bcd)
        {
            return ToByte((int)bcd);
        }

        /// <summary>
        /// 从单字节值转换成BCD格式(0d99 -> 0x99)
        /// </summary>
        /// <param name="_byte">单字节值(范围:0 ~ 99)</param>
        /// <returns></returns>
        public static byte FromByte(int _byte)
        {
            if (_byte > 99)
                throw new ArgumentOutOfRangeException("_byte", _byte, "_byte Value Incorrect.");
            int l = _byte % 10;
            int h = _byte / 10;
            return (byte)((h << 4) + l);
        }

        /// <summary>
        /// 从单字节值转换成BCD格式(0d99 -> 0x99)
        /// </summary>
        /// <param name="_byte">单字节值(范围:0 ~ 99)</param>
        /// <returns></returns>
        public static byte FromByte(byte _byte)
        {
            return FromByte((int)_byte);
        }


        /// <summary>
        /// 从四字节DWORD值转换成BCD格式(0d12345678 -> 0x12345678)
        /// </summary>
        /// <param name="_byte">UInt32</param>
        /// <returns></returns>
        public static void FromUint32(UInt32 value, byte[] pBuf)
        {
            for (int i = 0; i < 4; i++)
            {
                pBuf[i] = (byte)(value % 10);
                value /= 10;

                pBuf[i] += (byte)((value % 10) << 4);
                value /= 10;
            }
        }


    }
}
