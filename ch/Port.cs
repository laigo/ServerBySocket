using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.CHANNEL
{
    public abstract class Port: ITransport
    {
        public event EventHandler<RxEventArgs> RxEvent;
        public class RxEventArgs : EventArgs
        {
            public byte[] buf { get; set; }
        }

        public abstract string Name { get; }



        public abstract void Open();
        public abstract bool IsOpen();

        public abstract void Close();

        public abstract bool Tx(byte[] tx_buf, out string err_str);

        public void PktRecv(Port port, RxEventArgs args)
        {
            if (RxEvent != null)
            {
                RxEvent(port, args);
            }
        }

    }
}
