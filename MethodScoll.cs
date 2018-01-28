using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class MethodScoll
    {
        //在 .NET 框架程序中通过DllImport使用 Win32 API
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll", EntryPoint = "GetScrollPos")]
        public static extern int GetScrollPos(int hwnd, int nBar);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

#if false
       public int Dif=5;

        private void txtMsg_VScroll(object sender, EventArgs e)
        {
            int MinH, MaxH, MinV, MaxV;

            MethodScoll.GetScrollRange(txtMsg.Handle, 1, out MinV, out MaxV);
            Dif = txtMsg.Size.Height - (MaxV - MethodScoll.GetScrollPos((int)txtMsg.Handle, 1));
            DebugTxtMsg.Text = Dif.ToString();
            //txtMsg.Focus();
        }
        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            //api 滚动条位置获取和设置demo
            //MessageBox.Show(GetScrollPos((int)txtMsg.Handle, 1).ToString());
            //SetScrollPos(txtMsg.Handle, 1, txtMsg.Lines.Length - 1, true);            

            //GetScrollRange(txtMsg.Handle, 1, out MinV, out MaxV);

            //ScrollPos = GetScrollPos((int)txtMsg.Handle, 1);
            //Dif = txtMsg.Size.Height - (MaxV - ScrollPos);


            //滚动条 拉到最底部,todo? ScrollPos = MaxV + 5 - txtMsg.Size.Height;
            DebugTxtMsg.Text = Dif.ToString();
            if ((Dif == 5) || (Dif == 6))
            {
                //txtMsg.SelectionStart = txtMsg.Text.Length;
                //txtMsg.ScrollToCaret(); 
            }


            /*
            textBox1.Clear();
            GetScrollRange(txtMsg.Handle, 1, out MinV, out MaxV);
            textBox1.AppendText("\r\nMinV:" + MinV.ToString() + "\r\nMaxV:" + MaxV.ToString() + "\r\n");

            ScrollPos = GetScrollPos((int)txtMsg.Handle, 1);
            textBox1.AppendText(ScrollPos.ToString() + "\r\n");
            textBox1.AppendText("Height:" + txtMsg.Size.Height.ToString() + "\r\n");
            textBox1.AppendText("Dif:" + (txtMsg.Size.Height - (MaxV - ScrollPos)).ToString() + "\r\n");
            */
        }
#endif
    }
}
