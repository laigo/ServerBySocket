using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using INIFILE;
using ServerBySocket;
using QF.CHANNEL;



namespace QF
{
    public partial class ConnectSetupForm : Form
    {
        public string ComInf;
        public ConnectSetupForm()
        {
            InitializeComponent();
        }

        private void ConnectionSetupForm_Load(object sender, EventArgs e)
        {
            #region  界面加载串口配置
            // 预置波特率
            switch (Profile.G_BAUDRATE)
            {
                case "300":
                    cbBaudRate.SelectedIndex = 0;
                    break;
                case "600":
                    cbBaudRate.SelectedIndex = 1;
                    break;
                case "1200":
                    cbBaudRate.SelectedIndex = 2;
                    break;
                case "2400":
                    cbBaudRate.SelectedIndex = 3;
                    break;
                case "4800":
                    cbBaudRate.SelectedIndex = 4;
                    break;
                case "9600":
                    cbBaudRate.SelectedIndex = 5;
                    break;
                case "19200":
                    cbBaudRate.SelectedIndex = 6;
                    break;
                case "38400":
                    cbBaudRate.SelectedIndex = 7;
                    break;
                case "115200":
                    cbBaudRate.SelectedIndex = 8;
                    break;
                default:
                    {
                        MessageBox.Show("波特率预置参数错误。");
                        return;
                    }
            }

            //预置波特率
            switch (Profile.G_DATABITS)
            {
                case "5":
                    cbDataBits.SelectedIndex = 0;
                    break;
                case "6":
                    cbDataBits.SelectedIndex = 1;
                    break;
                case "7":
                    cbDataBits.SelectedIndex = 2;
                    break;
                case "8":
                    cbDataBits.SelectedIndex = 3;
                    break;
                default:
                    {
                        MessageBox.Show("数据位预置参数错误。");
                        return;
                    }

            }
            //预置停止位
            switch (Profile.G_STOP)
            {
                case "1":
                    cbStop.SelectedIndex = 0;
                    break;
                case "1.5":
                    cbStop.SelectedIndex = 1;
                    break;
                case "2":
                    cbStop.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("停止位预置参数错误。");
                        return;
                    }
            }

            //预置校验位
            switch (Profile.G_PARITY)
            {
                case "NONE":
                    cbParity.SelectedIndex = 0;
                    break;
                case "ODD":
                    cbParity.SelectedIndex = 1;
                    break;
                case "EVEN":
                    cbParity.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("校验位预置参数错误。");
                        return;
                    }
            }
            #endregion              

            #region 本机电脑串口检测
            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            #endregion

            #region 串口列表添加
            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                //System.Diagnostics.Debug.WriteLine(s);
                cbSerial.Items.Add(s);

                if (s == Profile.G_PORTNAME)
                {
                    cbSerial.SelectedIndex = cbSerial.Items.Count - 1;
                }
            }
            #endregion

            #region 传输介质选择
            //COM 或者 socket 选择
            comboBox1.SelectedIndex = 0;
            #endregion
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SerialPort _sp = Transmission.cfg.settings.serialPort;
            if (_sp.IsOpen == true)//如果打开状态，则先关闭一下
            {
                _sp.Close();
            }


            #region 串口设置
            try
            {
                //设置串口号
                _sp.PortName = cbSerial.SelectedItem.ToString();

                //设置各“串口设置”
                _sp.BaudRate = Convert.ToInt32(cbBaudRate.Text);//波特率
                _sp.DataBits = Convert.ToInt32(cbDataBits.Text);//数据位     
                switch (cbStop.Text)                            //停止位
                {
                    case "1":
                        _sp.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        _sp.StopBits = StopBits.OnePointFive;
                        break;
                    case "2":
                        _sp.StopBits = StopBits.Two;
                        break;
                    default:
                        MessageBox.Show("Error：参数不正确!", "Error");
                        break;
                }
                switch (cbParity.Text)             //校验位
                {
                    case "NONE":
                        _sp.Parity = Parity.None;
                        break;
                    case "ODD":
                        _sp.Parity = Parity.Odd;
                        break;
                    case "EVEN":
                        _sp.Parity = Parity.Even;
                        break;
                    default:
                        MessageBox.Show("Error：参数不正确!", "Error");
                        break;
                }

                /*
                COM port_com = new COM(_sp);
                List<Port> ports = new List<Port>();
                ports.Add(port_com);

                Transmission.Init(ports);
                Transmission.Run();
                
                */
                Profile.G_PORTNAME = _sp.PortName;

                Profile.G_BAUDRATE = _sp.BaudRate + "";       //波特率
                Profile.G_DATABITS = _sp.DataBits + "";       //数据位
                Profile.G_STOP = cbStop.Text;               //停止位
                Profile.G_PARITY = cbParity.Text;           //校验位
                INIFILE.Profile.SaveProfile();     
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Error:" + ex.Message, "Error");
                return;
            }

            #endregion
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

    }
}
