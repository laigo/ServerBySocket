using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class PraseNetCfg : JT808
    {
        public static byte NetCfgsACK(byte[] msgbody, ref string info)
        {
            int oft = 0;
            /*
            0 应答流水号 WORD 
            2 包参数个数 BYTE 
            3 参数项列表                
                - 参数 ID DWORD 
                - 参数长度 BYTE 
                - 参数值 
            */
            info += "应答流水号=" + BitConverter.ToUInt16(msgbody, oft).ToString("x4") + "\r\n";
            oft += 2;

            byte cfgCnt = msgbody[oft++];
            info += "包参数个数=" + cfgCnt.ToString("") + "\r\n";

            for (int i = 0; i < cfgCnt; i++)
            {
                info += "参数 ID=" + BitConverter.ToUInt32(msgbody, oft).ToString("x8") + "\r\n";
                oft += 4;

                byte cfgLen =  msgbody[oft++];
                info += "参数 Len=" + cfgLen.ToString() + "\r\n";

                info += "参数 Value={";
                info +=  Hex.ToString(msgbody, oft, cfgLen);
                info += "};\r\n";   

                oft += cfgLen;
            }
            return ACK_NONE;        
        }


        public struct NET_CFG_INFO_S 
        {
            //
            public UInt32 cfgID;
            //
            public string cfgName;
            //
            public byte cfgLimitLen;

            public Type cfgType;

            public NET_CFG_INFO_S(UInt32 id, string name, byte limitlen, Type tp)  
            {
                this.cfgID = id;
                this.cfgName = name;
                this.cfgLimitLen = limitlen;
                this.cfgType = tp;

            }             
        }

        public const UInt32 NET_CFG_HEART_BEAT_ID = 0x00000001;	//终端心跳发送间隔，单位为秒(s)


        public readonly static NET_CFG_INFO_S[] cfgInfo = new NET_CFG_INFO_S[] { 
            new NET_CFG_INFO_S(0x00000001, "终端心跳发送间隔", 4, typeof(UInt32)),
            
            new NET_CFG_INFO_S(0x00000002, "TCP/UDP 消息应答超时时间", 4, typeof(UInt32)),
            new NET_CFG_INFO_S(0x00000003, "TCP/UDP 消息重传次数", 4, typeof(UInt32)),   

            new NET_CFG_INFO_S(0x00000010, "主服务器 APN", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000011, "主服务器 USER", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000012, "主服务器 PASSWORD", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000013, "主服务器 IP", 32, typeof(String)),    
 
            new NET_CFG_INFO_S(0x00000014, "备份服务器 APN", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000015, "备份服务器 USER", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000016, "备份服务器 PASSWORD", 32, typeof(String)),    
            new NET_CFG_INFO_S(0x00000017, "备份服务器 IP", 32, typeof(String)),  

            new NET_CFG_INFO_S(0x00000018, "主服务器端口 PORT", 4, typeof(UInt32)),  
            new NET_CFG_INFO_S(0x00000019, "备份服务器端口 PORT", 4, typeof(UInt32)),  

            new NET_CFG_INFO_S(0x00000030, "省域 ID", 4, typeof(UInt32)),  
            new NET_CFG_INFO_S(0x00000031, "市域 ID", 4, typeof(UInt32)),  
            new NET_CFG_INFO_S(0x00000032, "手机号 TEL", 7, typeof(byte[])),            
        };
    }
}
