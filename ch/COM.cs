using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QF.CHANNEL
{
    public class COM : DataStream, ITransport
    {
        SerialPort sp = null;

        public COM(SerialPort _sp)
        {
            this.sp = _sp;
        }

        public override void Open()
        {           
            sp.DataReceived += Sp_DataReceived;
            sp.Open();
        }

        public override bool IsOpen()
        {
            return sp.IsOpen;
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);

            byte[] rx_buf = new byte[sp.BytesToRead];
            sp.Read(rx_buf, 0, rx_buf.Length);

            //foreach (byte i in rx_buf)
            {
                //DebugInfo += i.ToString("X2")+ " ";
            }
            //DebugInfo = string.Join(" ", rx_buf);
            
            base.DataReceived(this, rx_buf);
        }

        public override void Close()
        {
            sp.DataReceived -= Sp_DataReceived;
            sp.Close();
        }

        public override bool Tx(byte[] tx_buf, out string err_str)
        {
            if (sp == null)
            {
                err_str = "comm not found";
                return false;           
            }

            if (!sp.IsOpen)
            {
                err_str = sp.PortName + " not opened";
                return false;
            }
            try
            {
                

                sp.Write(tx_buf, 0, tx_buf.Length);
                err_str =" ->"+ sp.PortName;
                //err_str = null;
                return true;
            }
            catch (Exception ex)
            {
                err_str = "串口: " + sp.PortName + " 发送数据失败." + " 错误信息: " + ex.Message;
                return false;
            }
        }

        public override string Name { get { return sp.PortName; } }



    }
}
