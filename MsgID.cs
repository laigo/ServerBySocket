using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    public class MsgID
    {
        //808消息ID定义。根据<<主站与单灯通讯协议V1.00-20150323(*号)>>
       public const UInt16 MSG_TERMINAL_GENERAL_ACK			=0x0000;	//消息ID:终端通用应答
       public const UInt16 MSG_MONITOR_GENERAL_ACK				=0x8000;	//消息ID:监控平台通用应答

       public const UInt16 MSG_TERMINAL_LOGIN					=0x0001;	//终端登入
       public const UInt16 MSG_TERMINAL_LOGIN_ACK				=0x8001;	//终端登入应答

       public const UInt16 MSG_HEARTBEAT						=0x0002;	//终端心跳	

       public const UInt16 MSG_NETWORK_SETTING					=0x8201;	//设置网络参数
       public const UInt16 MSG_QUERY_NETWORK					=0x8101;	//查询网络参数
       public const UInt16 MSG_QUERY_NETWORK_ACK				=0x0101;	//查询网络参数应答

       public const UInt16 MSG_TERMINAL_SETTING				=0x8202;	//设置终端参数
       public const UInt16 MSG_QUERY_TERMINAL					=0x8102;	//查询终端参数
       public const UInt16 MSG_QUERY_TERMINAL_ACK				=0x0102;	//查询终端参数应答

       public const UInt16 MSG_RTC_SETTING						=0x8203;	//设置日历时钟
       public const UInt16 MSG_QUERY_RTC						=0x8103;	//查询日历时钟
       public const UInt16 MSG_QUERY_RTC_ACK					=0x0103;	//查询日历时钟应答


       public const UInt16 MSG_JWD_STRATEGY_SETTING			=0x8204;	//设置经纬度-开关灯时间
       public const UInt16 MSG_QUERY_JWD_STRATEGY				=0x8104;	//查询经纬度-开关灯时间
       public const UInt16 MSG_QUERY_JWD_STRATEGY_ACK			=0x0104;	//查询经纬度-开关灯时间应答

       public const UInt16 MSG_TMP_STRATEGY_SETTING			=0x8205;	//设置临时-开关灯时间
       public const UInt16 MSG_QUERY_TMP_STRATEGY				=0x8105;	//查询临时-开关灯时间
       public const UInt16 MSG_QUERY_TMP_STRATEGY_ACK			=0x0105;	//查询临时-开关灯时间应答


       public const UInt16 MSG_QUERY_TERMINAL_RSA				=0x8109;	//查询终端RSA公钥
       public const UInt16 MSG_QUERY_TERMINAL_RSA_ACK			=0x0109;	//查询终端RSA公钥应答
       public const UInt16 MSG_PLATFORM_RSA_SETTING			=0x8208;	//设置平台RSA公钥
       public const UInt16 MSG_QUERY_PLATFORM_RSA				=0x8108;	//查询平台RSA公钥
       public const UInt16 MSG_QUERY_PLATFORM_RSA_ACK			=0x0108;	//查询平台RSA公钥应答



       public const UInt16 MSG_TERMINAL_CTL					=0x8301;	//终端控制

       public const UInt16 MSG_QUERY_REALTIME_DATA				=0x8401;	//查询实时数据
       public const UInt16 MSG_QUERY_REALTIME_DATA_ACK			=0x0401;	//查询实时数据应答

       public const UInt16 MSG_QUERY_HISTORY_DATA				=0x8501;	//查询历史数据
       public const UInt16 MSG_QUERY_HISTORY_DATA_ACK			=0x0501;	//查询历史数据应答


       public const UInt16 MSG_QUERY_EVENT					=0x8601;	//查询事件记录
       public const UInt16 MSG_QUERY_EVENT_ACK				=0x0601;	//查询事件记录应答
       public const UInt16 MSG_INITIATIVE_EVENT_REPORT      = 0x0602;	//事件主动上报

       public const UInt16 MSG_TRANSPARENT_DATA_IN				=0x8FEF;	//数据下行透传	
       public const UInt16 MSG_TRANSPARENT_DATA_OUT			=0x0FEF;	//数据上行透传	


       public const UInt16 MSG_LFC_ESX_SETTING					=0xB201;	//设置集中器-单灯关联
       public const UInt16 MSG_QUERY_LFC_ESX					=0xB101;	//查询集中器-单灯关联
       public const UInt16 MSG_QUERY_LFC_ESX_ACK				=0x3101;	//查询集中器-单灯关联应答

       public const UInt16 MSG_ESX_LAMP_SETTING				=0xB202;	//设置单灯-灯盏关联
       public const UInt16 MSG_QUERY_ESX_LAMP					=0xB102;	//查询单灯-灯盏关联
       public const UInt16 MSG_QUERY_ESX_LAMP_ACK				=0x3102;	//查询单灯-灯盏关联应答

       public const UInt16 MSG_ESX_GROUP_SETTING				=0xB203;	//设置单灯-组关联
       public const UInt16 MSG_QUERY_ESX_GROUP					=0xB103;	//查询单灯-组关联
       public const UInt16 MSG_QUERY_ESX_GROUP_ACK				=0x3103;	//查询单灯-组关联应答


        //程序BUG
        /*
       public const UInt16 MSG_ESX_ENERGY_SAVE_SETTING			=0xB204;	//设置自动节能控制参数
       public const UInt16 MSG_QUERY_ESX_ENERGY_SAVE			=0xB104;    //查询自动节能控制参数
       public const UInt16 MSG_QUERY_ESX_ENERGY_SAVE_ACK		=0x3104;	//查询自动节能控参数应答
        */
       public const UInt16 MSG_ESX_ENERGY_SAVE_SETTING          = 0xB104;	//设置自动节能控制参数
       public const UInt16 MSG_QUERY_ESX_ENERGY_SAVE            = 0xB504;    //查询自动节能控制参数
       public const UInt16 MSG_QUERY_ESX_ENERGY_SAVE_ACK        = 0x3504;	//查询自动节能控参数应答



       public const UInt16 MSG_FIRMWARE_UPGRADE                =0x8FFF;	//固件升级

    }
}
