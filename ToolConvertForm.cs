using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerBySocket
{
    public partial class ToolConvertForm : Form
    {
        public ToolConvertForm()
        {
            InitializeComponent();
        }


        private void TxtAscii_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUnicode_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtHex_TextChanged(object sender, EventArgs e)
        {
            byte[] buf = Hex.FromHEXString(TxtHex.Text);


            TxtHex_0x.Text = Hex.ToString(buf, 0, buf.Length, ",","0x");
            TxtHex_Space.Text = Hex.ToString(buf, 0, buf.Length, " ","");
            TxtHex_null.Text = Hex.ToString(buf, 0, buf.Length, "","");

            TxtAscii.Text= Encoding.ASCII.GetString(buf);
            TxtUnicode.Text = Encoding.Unicode.GetString(buf);  

        }

        private void ToolConvertForm_Load(object sender, EventArgs e)
        {
            this.TxtHex.Focus();
        }
    }
}
