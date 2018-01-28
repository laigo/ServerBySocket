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
    public partial class ToolBH1750 : Form
    {
        public ToolBH1750()
        {
            InitializeComponent();
        }

        private void ToolBH1750_Load(object sender, EventArgs e)
        {
            //trackBar1.DataBindings.Add("Text", MsgData._myData, "TheValue", false, DataSourceUpdateMode.OnPropertyChanged);

            trackBar1.Maximum = 222;
            trackBar1.Minimum = 27;

            trackBar1.Value = 100;
        }




        const byte REG_H_BASE_VALUE = 0x40;
        const byte REG_L_BASE_VALUE = 0x60;

        const int  BASE_VALUE = 69;

        /// <summary>
        /// 透光率设置方法：若想把透光率设为X, 则在寄存器Change Measurement time 中写入的值应为:100%透光率的基准值除以X;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int CalcBH1750Transmittance(int value, out byte regH, out byte regL)
        {
            //Math.Ceiling()向上取整，Math.Floor()向下取整 

            float FloatValue = BASE_VALUE * 100.0f / value;

            int DecimalValue= (int)Math.Round(FloatValue);


            regH = (byte)(REG_H_BASE_VALUE + ((DecimalValue & 0x000000e0)>>5));
            regL = (byte)(REG_L_BASE_VALUE + (DecimalValue & 0x0000001f));

            return DecimalValue;
        }



        const byte REC_HEAD_BYTE_AA = 0xaa;
        const byte SEND_HEAD_BYTE_bb = 0xbb;
        const byte END_BYTE_cc = 0xcc;

        const byte rLX_VALUE			=0x01; 	
        const byte wTransmittance		=0xC8;
        const byte rSW				    =0x04;



        private int PackageFrame(byte cmd ,byte[] data)
        {
            //0xaa+len+cmd+data+verify+0xcc
            byte[] frame = new byte[256];
            int oft = 0;

            //帧头AA
            frame[oft++] = REC_HEAD_BYTE_AA;
            
            //i. len˖cmd+data+verify
            frame[oft++] = (byte)(1 + data.Length + 1);

            //
            frame[oft++] = cmd;

            //data
            Array.Copy(data, 0, frame, oft, data.Length);
            oft += data.Length;

            //verify
            byte verify = 0;

            for (int i = 0; i < oft-1; i++)	//len xor cmd xor data
            {
                verify ^= frame[i + 1];
            } 		
            frame[oft++] = verify;

            frame[oft++] = END_BYTE_cc;

            textBox1.Text =  Hex.ToString(frame, 0, oft);

            return oft;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            byte regH, regL;

            int DecimalValue = CalcBH1750Transmittance(trackBar1.Value, out regH, out regL);

            label1.Text = "10进制值:" + DecimalValue.ToString() 
                + "     寄存器高8位值：0x" + regH.ToString("x") 
                + "     寄存器低8位值：0x" + regL.ToString("x");


            label3.Text = trackBar1.Value.ToString() + "%";

            byte[] data = new byte[2];
            //大端模式
            data[0]= regH;
            data[1]= regL;

            PackageFrame(wTransmittance ,data);
        }
    }
}
