﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using Microsoft.Win32;

namespace ServerBySocket
{
    class MultipleGetPortName
    {
        /// <summary>
        /// 枚举win32 api
        /// </summary>
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }

        /// <summary>
        /// WMI取硬件信息
        /// </summary>
        /// <param name="hardType"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        public static string[] MulGetHardwareInfo(HardwareEnum hardType, string propKey)
        {

            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if ((hardInfo.Properties[propKey].Value != null) && (hardInfo.Properties[propKey].Value.ToString().Contains("COM")))
                        {
                            strs.Add(hardInfo.Properties[propKey].Value.ToString());
                        }

                    }
                    searcher.Dispose();
                }
                return strs.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            { strs = null; }
        }

        /// <summary>
        /// 待完善模块
        /// </summary>
        /// <returns></returns>
        public static string[] RegistryGetSerialCommInfo()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                /*
                 * 数值名称(N)                      数值数据
                 * \Device\ProlificSerial0          COM3 
                 * \Device\VSerial7_0               COM1
                 * \Device\VSerial7_1               COM2     
                 */
                string[] sSubKeys = keyCom.GetValueNames();


                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                }
            }
            return null;
        }

        #if false
        RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
        if (keyCom != null)
        {
            string[] sSubKeys = keyCom.GetValueNames();


            string[] cnitems = new string[cbSerial.Items.Count];

            int i=0;

            foreach(var item in cbSerial.Items)
            {
                cnitems[i++] = item.ToString();
            }

            if (Enumerable.SequenceEqual(str, cnitems))
            {
                return;
            }


            cbSerial.Items.Clear();
            foreach (string sName in sSubKeys)
            {
                string sValue = (string)keyCom.GetValue(sName);
                cbSerial.Items.Add(sValue);

                if (sValue == Profile.G_PORTNAME)
                {
                    cbSerial.SelectedIndex = cbSerial.Items.Count - 1;
                }
            }


        }
        #endif

        #if false
        #region ---通过WMI获取COM端口

            cbSerial.Items.Clear();
            string[] ss = MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");
            foreach (string s in ss)
            {
                cbSerial.Items.Add(s);

                if (s == Profile.G_PORTNAME)
                {
                    cbSerial.SelectedIndex = cbSerial.Items.Count - 1;
                }
            }
        #endregion
        #endif
    }
}