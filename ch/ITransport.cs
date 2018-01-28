using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QF.CHANNEL
{
    public interface ITransport
    {
        void Open();
        void Close();
        bool Tx(byte[] tx_buf, out string err_str);

    }
}
