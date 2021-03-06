﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INIFILE
{
    class Profile
    {
        public static void LoadProfile()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strPath + "Cfg.ini");
            G_PORTNAME = _file.ReadString("CONFIG", "PortName", "COM1");    //读数据，下同
            G_BAUDRATE = _file.ReadString("CONFIG", "BaudRate", "9600");   
            G_DATABITS = _file.ReadString("CONFIG", "DataBits", "8");
            G_STOP = _file.ReadString("CONFIG", "StopBits", "1");
            G_PARITY = _file.ReadString("CONFIG", "Parity", "NONE");
            //
            G_RTSENABLE  =  _file.ReadString("CONFIG", "RtsEnable", "false"); 
            G_DTSENABLE  =  _file.ReadString("CONFIG", "DtsEnable", "false");     
        }

        public static void SaveProfile()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strPath + "Cfg.ini");
            _file.WriteString("CONFIG", "PortName", G_PORTNAME);            //写数据，下同
            _file.WriteString("CONFIG", "BaudRate", G_BAUDRATE);            
            _file.WriteString("CONFIG", "DataBits", G_DATABITS);
            _file.WriteString("CONFIG", "StopBits", G_STOP);
            _file.WriteString("CONFIG", "Parity", G_PARITY);
            //
            _file.WriteString("CONFIG", "RtsEnable", G_RTSENABLE);
            _file.WriteString("CONFIG", "DtsEnable", G_DTSENABLE);
        }

        private static IniFile _file;//内置了一个对象

        public static string G_PORTNAME = "COM1";//给ini文件赋新值，并且影响界面下拉框的显示
        public static string G_BAUDRATE = "9600";//给ini文件赋新值，并且影响界面下拉框的显示
        public static string G_DATABITS = "8";
        public static string G_STOP = "1";
        public static string G_PARITY = "EVEN";
        //
        public static string G_RTSENABLE = "false";
        public static string G_DTSENABLE = "false";

    }
}
