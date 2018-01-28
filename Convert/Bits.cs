using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.TOOLS
{
    class Bits
    {
        //https://msdn.microsoft.com/en-us/library/system.bitconverter(v=vs.110).aspx
        //Converts base data types to an array of bytes, and an array of bytes to base data types.


        //Int32 dd = BitConverter.ToInt32(buf, 0);  

        /// <summary>
        /// 设置某一位的值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index">要设置的位， 值从低到高为 1-8</param>
        /// <param name="flag">要设置的值 true / false</param>
        /// <returns></returns>
        public static byte set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }

        /// <summary>
        /// 获取数据中某一位的值
        /// </summary>
        /// <param name="input">传入的数据类型,可换成其它数据类型,比如Int</param>
        /// <param name="index">要获取的第几位的序号,从0开始</param>
        /// <returns>返回值为-1表示获取值失败</returns>
        /*
        public static int GetbitValue(byte input, int index)
        {
            if (index > sizeof(byte))
            {
                return -1;
            }
            //左移到最高位
            int value = input << (sizeof(byte) - 1 - index);
            
            //右移到最低位
            value = value >> (sizeof(byte) - 1);
            return value;
        }
        */
        public static int GetbitValue(int input, int index)
        {
            return (input & ((uint)1 << index)) > 0 ? 1 : 0;
        }
        
    }
}
