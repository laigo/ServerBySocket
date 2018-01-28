using QF.CHANNEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class Transmission
    {
        static SocketManager _sm = null;

        public Transmission(SocketManager t)
        {
            _sm = t;
        }


        public static SocketManager GetDefaultSocket()
        {
            return _sm;
        }
        public static void SetDefaultSocket(SocketManager t)
        {
             _sm = t ;
        }

        public static string SocketSent(byte[] pBuf, int index, UInt16 length, string endPoint)
        {
            string Info = string.Empty;
            
            SocketManager _sm = Transmission.GetDefaultSocket();
            if (_sm == null)
            {
                Info += "SocketNotListening,";
            }
            else
            {
                if (!_sm._listSocketInfo.Keys.Contains(endPoint))
                {
                    Info += "ListSockeNotContains,";
                }
                else
                {
                    Info += endPoint;
                    _sm.SendMsg(pBuf, index, length, endPoint);
                }
            }

            return Info;
        }
        public static string SocketSent(string str, string endPoint)
        {
            string Info = string.Empty;

            SocketManager _sm = Transmission.GetDefaultSocket();
            if (_sm == null)
            {
                Info += "SocketNotListening,";
            }
            else
            {
                if (!_sm._listSocketInfo.Keys.Contains(endPoint))
                {
                    Info += "ListSockeNotContains,";
                }
                else
                {
                    Info += endPoint;
                    _sm.SendMsg(str, endPoint);
                }
            }
            return Info;
        }


        public static ObservableCollection<Port> Ports { get; set; }
        public static void Init(List<Port> ports)
        {
            Ports = new ObservableCollection<Port>();
            foreach (Port port in ports)
            {
                Ports.Add(port);
            }
        }

        public static string UartSent(byte[] pBuf, int index, UInt16 length, string comm)
        {
            string err_str = null;
            byte[] buf = new byte[length];

            Array.Copy(pBuf, buf, length);

            //判断Ports 未实例化? todo? 判断null
            if ((Ports == null))
            {
                return "ports is null!";
            }
            
            GetDefaultPort().Tx(buf, out err_str);
            return err_str;
        }

        public static string UartSent(string str)
        {
            string err_str = null;
            char[] chars = str.ToCharArray();
            byte[] buf = Encoding.Default.GetBytes(chars);

            if ((Ports == null))
            {
                return "ports is null!";
            }

            GetDefaultPort().Tx(buf, out err_str);            
            return err_str;
        }

        public static Port GetDefaultPort()
        {
            return Ports.First();
        }
        public static void Run()
        {
            foreach (Port port in Ports)
            {
                port.RxEvent += Port_RxEvent;
                port.Open();
            }
        }

        public static void Stop()
        {
            foreach (Port port in Ports)
            {
                port.RxEvent -= Port_RxEvent;
                port.Close();
            }
        }

        private static void Port_RxEvent(object sender, Port.RxEventArgs e)
        {
            Port port = (Port)sender;

            //logger.Info(port.Name + " Rx : " + Hex.ToString(e.buf, 0, e.buf.Length) + "[" + e.buf.Length + "]Bytes");        

            ServerForm.cbFunc(e.buf);


            //Packet rx_pkt = Packet.FromBuffer(e.buf);
            //Packet.Add(rx_pkt);

            //if (_rx_pkt == null)
            {
                //_rx_pkt = rx_pkt;
                //_rx_sem.Release();
            }
        }
        public static class cfg
        {
            public class Settings
            {
                public Settings()
                {
                    serialPort = new SerialPort();
                }


                public SerialPort serialPort { get; set; }
            }

            public static Settings settings = new Settings();

        }
    }
}
