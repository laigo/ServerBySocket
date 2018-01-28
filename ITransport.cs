using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    interface ITransport
    {
        bool Tx(byte[] tx_buf, out string err_str);
    }
}
