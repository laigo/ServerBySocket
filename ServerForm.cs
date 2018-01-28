using DevExpress.XtraTreeList.Nodes;
using INIFILE;
using Microsoft.Win32;
using QF;
using QF.CHANNEL;
using QF.TOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace ServerBySocket
{
    public partial class ServerForm : Form
    {
        string ip = "127.0.0.1";
        int port = 6802;

        DataTable DT_网络参数 = new DataTable("Table_NetCfg");
        DataTable DT_树形表格 = new DataTable("Table_TreeList");


        灯杆通讯端点集合 _listEndPoint =  new 灯杆通讯端点集合();

        private object lockTreeListObj = new object();
        private object lockSqlTableObj = new object();  


        private System.Timers.Timer aTimer = null;
        private delegate void TimerDispatcherDelegate();

        private void InitTimerForStatusStrip()
        {
            
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;        
        }

        /// <summary>
        /// 定时器回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, EventArgs e)
        {
            // Place delegate on the Dispatcher.
            /*
            this.Dispatcher.Invoke(DispatcherPriority.Normal,
                new TimerDispatcherDelegate(updateUI));
            */
            this.Invoke((EventHandler)(delegate
            {
                //状态条显示内容更新
                this.工具条_RTC_状态.Text = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                if (txtMsg.Text.Length > 512 * 1024)//512KB
                {
                    string path = System.Environment.CurrentDirectory + "\\richtextlog\\" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
                    this.txtMsg.SaveFile(path, RichTextBoxStreamType.PlainText);//重点在此句                

                    txtMsg.Clear();
                }
            }));
        }

        public ServerForm()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //遍历本地IP添加到组合框
            TraversalLocalIPToComboBox(comboBoxIP);
            
            //
            InitEsxUserControlTable();

            //cbClient.DataBindings.Add("Text", MsgData._myData, "TheValue", false, DataSourceUpdateMode.OnPropertyChanged);

            //
            InitContextMenuStripForTxtMsg();
            //
            InitEsxStatusTable();
            //
            InitTimerForStatusStrip();

            //try open uart comm
            InitComm();

            //
            InitEsxNetCfgTable();

            //
            InitTreeList(DT_树形表格);

            //
            InitTabControlConsole();

            //订阅事件
            praseFrame += new praseEventHandler(ProcEvent);  //订阅UpdateControl事件，指定Test方法为事件处理函数

            //线程
            //Thread producer = new Thread(new ThreadStart(prod.ThreadRun));
            //Thread consumer = new Thread(new ThreadStart(cons.ThreadRun));

            Thread CheckConnection = new Thread(new ThreadStart(Thread_设备连接更新));
            CheckConnection.IsBackground = true;//线程才会随着主线程的退出而退出
            CheckConnection.Start();

            Thread BatchPointCopy = new Thread(new ThreadStart(Thread_批量定时招测));
            BatchPointCopy.IsBackground = true;
            BatchPointCopy.Start();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = System.Environment.CurrentDirectory + "\\richtextlog\\" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt";
            this.txtMsg.SaveFile(path, RichTextBoxStreamType.PlainText);//重点在此句      
        }

        public void InitTabControlConsole()
        { 
            Point xy = new Point(0, 0);
            tabControl_Console.Location = xy;
            tabControl_Console.Width = splitContainerE1.Panel1.Width - 4;
            tabControl_Console.Height = splitContainerE1.Panel1.Height - 4;        
        }


        #region 串口COMM相关函数
        /// <summary>
        /// 
        /// </summary>
        public void InitComm()
        {          
            INIFILE.Profile.LoadProfile();//加载配置            
           
            #region ---本机电脑串口检测          
            string[] str = SerialPort.GetPortNames();
            if (str == null || str.Length == 0)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            #endregion
            #region ---比较combox items
            string[] cnitems = new string[cbSerial.Items.Count];
            int i = 0;
            foreach (var item in cbSerial.Items)
            {
                cnitems[i++] = item.ToString();
            }

            if (Enumerable.SequenceEqual(str, cnitems))
            {
                return;
            }
            #endregion
            #region 串口列表添加
            cbSerial.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())//获取有多少个COM口
            {
                //System.Diagnostics.Debug.WriteLine(s);
                cbSerial.Items.Add(s);

                if (s == Profile.G_PORTNAME)
                {
                    cbSerial.SelectedIndex = cbSerial.Items.Count - 1;
                }
            }
            #endregion
        }

        private void cbSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPort _sp = Transmission.cfg.settings.serialPort;
            if (_sp.IsOpen == true)//如果打开状态，则先关闭一下
            {
                _sp.Close();
            }

            _sp.PortName = cbSerial.SelectedItem.ToString();
            _sp.BaudRate = Convert.ToInt32(Profile.G_BAUDRATE);       //波特率
            _sp.DataBits = Convert.ToInt32(Profile.G_DATABITS);       //数据位
            switch (Profile.G_STOP)            //停止位
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
            switch (Profile.G_PARITY)             //校验位
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

            try
            {
                COM port_com = new COM(_sp);
                List<Port> ports = new List<Port>();
                ports.Add(port_com);

                Transmission.Init(ports);
                Transmission.Run();
            }
            catch (System.Exception ex)
            {
                tsbtnQuickConnect.Enabled = true;               
                tsbtnDisconnect.Enabled = false;

                工具条_COM_状态.Text = ex.Message;
                工具条_COM_状态.ForeColor = Color.Red;

                MessageBox.Show("Error:" + ex.Message, "Error");
                return;
            }

            工具条_COM_状态.Text = _sp.PortName + " OPENED, " + Profile.G_BAUDRATE + "," + Profile.G_DATABITS + "," + Profile.G_STOP + "," + Profile.G_PARITY;
            工具条_COM_状态.ForeColor = Color.Green;

            Profile.G_PORTNAME = _sp.PortName;
            INIFILE.Profile.SaveProfile();

            tsbtnQuickConnect.Enabled = false;
            tsbtnDisconnect.Enabled = true;
        }

        /// <summary>
        /// combox 下拉加载串口列表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSerial_DropDown(object sender, EventArgs e)
        {
            InitComm();
        }
        #endregion

        #region 消息文本右键属性方法
        private void InitContextMenuStripForTxtMsg()
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            //右键菜单加入一个选项
            string[] option = { "复制", "剪切", "粘贴", "全选", "清空" };
            foreach (string s in option)
            {
                cm.Items.Add(s);
            }   

            //点击选项时发生Click事件
            cm.Items[0].Click += Copy_Click;
            cm.Items[1].Click += Cut_Click;
            cm.Items[2].Click += Paste_Click;
            cm.Items[3].Click += SelectAll_Click;
            cm.Items[4].Click += ClrAll_Click;

            //激活ContextMenuStrip的时候发生onlyfornumber3_Click2事件
            //cm.Opening += onlyfornumber3_Click2;

            //将ContextMenuStrip和richbox绑定在一起
            txtMsg.ContextMenuStrip = cm;        
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            this.txtMsg.Copy();
        }
        private void Cut_Click(object sender, EventArgs e)
        {
            this.txtMsg.Cut(); 
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            this.txtMsg.Paste(); 
        }
        private void SelectAll_Click(object sender, EventArgs e)
        {
            this.txtMsg.SelectAll();
        }
        private void ClrAll_Click(object sender, EventArgs e)
        {
            this.txtMsg.Clear();
        }
        #endregion

        #region socket 相关函数
        void InitSocketServer()
        {
            txtMsg.Text += GetDateNow() +"  服务器启动成功！\r\n";
            /*
            lblIp.Text = ip;
            lblPort.Text = port.ToString();
            lblStatus.Text = "正常启动";
            */ 
        }
        public void OnReceiveMsgPrase(string endPoint, byte[] Frame)
        {
            byte[] message = new byte[1500];
            int len=0;

            //提取7e...7e报文
            List<byte> finaly = Frame.ToList<byte>();

            int start_index = finaly.IndexOf(0x7e);
            if (start_index == -1)
            {
                finaly.Clear();
                return;
            }
            finaly.RemoveRange(0, start_index+1);

            int end_index = finaly.IndexOf(0x7e);
            if (end_index == -1)
            {
                finaly.Clear();
                return;          
            }
           
            finaly.RemoveRange(end_index, finaly.Count - end_index);
            byte[] buffer = finaly.ToArray();
            finaly.Clear();

            byte res = JT808.ACK_NONE;
            string retstr = "\r\n原始报文：7E " + Hex.ToString(buffer, 0, buffer.Length, " ","") + "7E\r\n";
            
            UInt16 msgid = 0, serial_number = 0;
            string telnum;

            if (!JT808.Unpack(buffer, buffer.Length, message, out len))
            {
                retstr += "CRC error!\r\n";
            }
            else
            {
                byte[] msgbody = JT808.Process_jt808_Package(message, len, ref retstr, out msgid, out serial_number, out telnum);
                if (msgbody != null)
                {
                    retstr += "MsgID=" + msgid.ToString("x4") + "\r\n";                
                    switch (msgid)
                    {
                        //终端通用应答
                        case MsgID.MSG_TERMINAL_GENERAL_ACK:
                            res = PraseTerminalCommon.CommonACK(msgbody, ref retstr);
                            break;

                        case MsgID.MSG_HEARTBEAT:
                            byte rssi;
                            res = PraseHeartBeat.HeartBeatACK(msgbody, ref retstr, out rssi);
                            //
                            TreeListUpdateHeartBeat(telnum, rssi);

                            break;

                        case MsgID.MSG_TERMINAL_LOGIN:
                            res = PraseLogin.LoginACK(msgbody, serial_number, ref retstr);
                            break;

                        case MsgID.MSG_INITIATIVE_EVENT_REPORT:
                            UInt16 eventcount = 0;
                            PraseEvent.EventClass[] eventrecord = new PraseEvent.EventClass[10];
                            res = PraseEvent.EVENT(msgbody, serial_number, eventrecord, ref eventcount, ref retstr);

                            //事件插入到数据库
                            for (int i = 0; i < eventcount; i++)
                            {
                                EventInsert(telnum, eventrecord[i].erc, Hex.ToString(eventrecord[i].content));
                            }
                            //事件上报平台主动招测单灯状态数据
                            PointCopyStatus(endPoint); 
                            break;
                        case MsgID.MSG_QUERY_REALTIME_DATA_ACK:
                            string[] LampInfo = new string[4];
                            string DeviceRTCInfo = string.Empty;

                            res = PraseStatus.StatusACK(msgbody, ref retstr, LampInfo, ref DeviceRTCInfo);
                            //
                            RefreshEsxStatusTable(msgbody);
                            //
                            TreeListUpdatePointCopy(telnum, LampInfo, DeviceRTCInfo);
                            break;

                        case MsgID.MSG_QUERY_TERMINAL_ACK:
                            res = PraseTerminalCfg.TerminalCfgACK(msgbody, ref retstr);
                            //
                            RefreshEsxTerminalCfgTable(msgbody);
                            break;

                        case MsgID.MSG_QUERY_TMP_STRATEGY_ACK:
                            res = PraseSwitchTime.TmpSwitchTimeAck(msgbody, ref retstr);
                            break;

                        case MsgID.MSG_QUERY_JWD_STRATEGY_ACK:
                            res = PraseSwitchTime.JwdSwitchTimeAck(msgbody, ref retstr);
                            //
                            RefreshJwdTimeTable(msgbody);
                            break;

                        case MsgID.MSG_QUERY_ESX_ENERGY_SAVE_ACK:
                            res = PraseTimeCtrl.TimeCtrlAck(msgbody, ref retstr);
                            //
                            RefreshTimeCtrlTable(msgbody);
                            break;

                        case MsgID.MSG_QUERY_NETWORK_ACK:
                            res = PraseNetCfg.NetCfgsACK(msgbody, ref retstr);
                            //
                            RefreshNetCfgTable(msgbody);
                            break;                       

                        default:
                            break;
                    }                   
                }

                _listEndPoint.UpdateInsert(telnum, endPoint);    
            }
           
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.AppendText(AppendReceiveMsg(retstr, endPoint));

                }));
            }
            else
            {
                txtMsg.AppendText(AppendReceiveMsg(retstr, endPoint));
            }

            //主动上报的帧,todo? 平台应答
            if (JT808.ACK_NONE != res)
            {
                PlatformAnswer(endPoint, msgid, serial_number, res);
            }

            
        }
        public void PlatformAnswer(string endPoint, UInt16 msgid, UInt16 sn, byte res)
        {
             //主动上报[ 登入，事件上报 ]
            byte[] tBuf = new byte[1024];
            int oft = 0;
         
            //消息体
            if (msgid == MsgID.MSG_TERMINAL_LOGIN)
            {
                //0：成功； 1：已登入； 2：数据库中无该终端； 3：消息有误
                tBuf[oft++] = (byte)(JT808.ACK_SUCCESS == res ? 0 : 3);
                
                //登入应答
                msgid = MsgID.MSG_TERMINAL_LOGIN_ACK;
            }
            else
            {              
                //0：成功/确认； 1：失败； 2：消息有误； 3：不支持
                Bytes.FromUInt16(msgid, tBuf, oft);
                oft += 2;
                tBuf[oft++] = (byte)(JT808.ACK_SUCCESS == res ? 0 : 3);
                
                //通用应答
                msgid = MsgID.MSG_MONITOR_GENERAL_ACK;
            }
            //组包
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndAck(msgid, msgbody, sn, endPoint);
        }


        /// <summary>
        /// 添加本地IP到组合框comboBoxIP
        /// </summary>
        /// <param name="ip"></param>
        public void TraversalLocalIPToComboBox(System.Windows.Forms.ToolStripComboBox cb)
        {
            string AddressIP = string.Empty;

            IPHostEntry iphostentry = null;
            iphostentry = Dns.GetHostEntry(Dns.GetHostName()); 

            foreach (IPAddress address in iphostentry.AddressList)
            {
                if (address.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = address.ToString();
                    cb.Items.Add(AddressIP);
                }  
            }
            cb.SelectedIndex = 0;        
        }




        public void OnReceiveMsg(string ip)
        {
            SocketManager _sm = Transmission.GetDefaultSocket();
            
            byte[] buffer = _sm._listSocketInfo[ip].msgBuffer;
            
            //报文 ascii 显示
            string msg = Encoding.ASCII.GetString(buffer).Replace("\0", "");
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.AppendText(AppendReceiveMsg(msg, ip));
                }));
            }
            else
            {
                txtMsg.AppendText(AppendReceiveMsg(msg, ip));
            }

            OnReceiveMsgPrase(ip, buffer);
        }
        public void OnConnected(string clientIP)
        {
            string ipstr = clientIP.Split(':')[0];
            string portstr = clientIP.Split(':')[1];

            this.Invoke((EventHandler)(delegate
            {
                txtMsg.Text += GetDateNow() + clientIP + "已连接至本机\r\n";

                cbClient.Items.Add(clientIP);

                if (cbClient.SelectedIndex == -1)
                {
                    cbClient.SelectedIndex = 0;
                }
            }));
        }

        public void OnDisConnected(string clientIp)
        {
            this.Invoke((EventHandler)(delegate
            {
                txtMsg.Text += GetDateNow() + clientIp + "已经断开连接！\r\n";
                cbClient.Items.Remove(clientIp);
            }));

            _listEndPoint.Remove(clientIp);
        }
        /*
        public void OnConnected(string clientIP)
        {
            string ipstr = clientIP.Split(':')[0];
            string portstr = clientIP.Split(':')[1];
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    txtMsg.Text += clientIP + "已连接至本机\r\n";
                    
                    object obj = new { Value = clientIP, Text = clientIP };
                    cbClient.Items.Add(obj);
                    cbClient.DisplayMember = "Value";
                    cbClient.ValueMember = "Text";
                    cbClient.SelectedItem = obj;
                    
                }));
            }
            else
            {
                txtMsg.Text += clientIP + "已连接至本机\r\n";
            }
        }

        public void OnDisConnected(string clientIp)
        {
            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    object obj = new { Value = clientIp, Text = clientIp };
                    cbClient.Items.Remove(obj);
                    //
                    cbClient.SelectedIndex = cbClient.Items.Count - 1;
                    txtMsg.Text += clientIp + "已经断开连接！\r\n";
                }));
            }
            else
            {
                object obj = new { Value = clientIp, Text = clientIp };
                cbClient.Items.Remove(obj);
                //
                cbClient.SelectedIndex = cbClient.Items.Count - 1;
                txtMsg.Text += clientIp + "已经断开连接！\r\n";
            }
        }
        */ 

        #endregion

        private void btn_数据发送_Click(object sender, EventArgs e)
        {
            string Info = string.Empty;

            if (Chk_Format十六进制.Checked == true)
            {
                byte[] buff = Hex.FromHEXString(txtSend.Text);
                Info += Transmission.SocketSent(buff, 0, (UInt16)buff.Length, cbClient.Text);
            }
            else
            {
                Info += Transmission.SocketSent(txtSend.Text, cbClient.Text);
            }


            Port _port = Transmission.GetDefaultPort();
            if (_port == null)
            {
                Info += "CommNotFound,";
            }
            else
            {
                if (!_port.IsOpen())
                {
                    Info += "CommNotOpened,";
                }
                else
                {
                    Info += cbSerial.Text;

                    if (Chk_Format十六进制.Checked == true)
                    {
                        byte[] buff = Hex.FromHEXString(txtSend.Text);
                        Transmission.UartSent(buff, 0, (UInt16)buff.Length, "");
                    }
                    else
                    {
                        Transmission.UartSent(txtSend.Text);
                    }
                }
            }
            AppendSendMsg(txtSend.Text, Info);
        }

        public void AppendSendMsg(string msg, string ipClient)
        {
            string str =  GetDateNow() + "  " + "[发送" + ipClient + "]  " + msg + "\r\n\r\n";

            if (txtMsg.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    txtMsg.AppendText( str);
                }));
            }
            else
            {
                txtMsg.AppendText(str);
            }
        }

        public string AppendReceiveMsg(string msg, string ipClient)
        {
            return GetDateNow() + "  " + "[接收" + ipClient + "]  " + msg + "\r\n\r\n";
        }
        /// <summary>
        /// http://note.youdao.com/noteshare?id=435abf02e3043ca8ab2676fd16c469fd&sub=19A48A6B9EB9446A874C20D7A1007B6E
        /// </summary>
        /// <returns></returns>
        public string GetDateNow()
        {
            //return DateTime.Now.ToString("HH:mm:ss");           
            //return System.DateTime.Now.ToString("g");//2008-4-24 16:30 
            return System.DateTime.Now.ToString("G") + " "; //2008年4月24日 8:30:15

        }
        /// <summary>
        /// 启动socket侦听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSocketStartListen_Click(object sender, EventArgs e)
        {
            ip = comboBoxIP.SelectedItem.ToString();

            if (TxtPort.Text == "")
            {
                return;

            }
            port = Convert.ToInt32(TxtPort.Text);


            SocketManager _sm = new SocketManager(ip, port);

            _sm.OnReceiveMsg += OnReceiveMsg;
            _sm.OnConnected += OnConnected;
            _sm.OnDisConnected += OnDisConnected;
            _sm.Start();
            Transmission.SetDefaultSocket(_sm);

            InitSocketServer();
            button侦听.Enabled = false;

        }
        /// <summary>
        /// 停止socket侦听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSocketStopListen_Click(object sender, EventArgs e)
        {
            SocketManager _sm = Transmission.GetDefaultSocket();
            if (_sm != null)
            {
                _sm.OnReceiveMsg -= OnReceiveMsg;
                _sm.OnConnected -= OnConnected;
                _sm.OnDisConnected -= OnDisConnected;

                _sm.Stop();

                cbClient.Items.Clear();
                button侦听.Enabled = true;
            }
            Transmission.SetDefaultSocket(null);
        }


        #region 固件升级界面属性方法
        private void btn_浏览BIN文件_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() == DialogResult.OK)
                {

                    BinPathTxt.Text = of.FileName;

                    FileStream fs;

                    //读取并输出数据  
                    fs = new FileStream(of.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    Int32 length = Convert.ToInt32(br.BaseStream.Length);
                    Byte[] data = br.ReadBytes(length);

                    int sv_year = data[0x2810];
                    int sv_modify = data[0x2811];
                    int sv_user = data[0x2812];


                    char[] devModelArray = new char[8];
                    Array.Copy(data, 0x2800 + 6, devModelArray, 0, devModelArray.Length);

                    //string str = new string(devModelArray);

                    DevModelTxt.Text = string.Concat(devModelArray);

                    textBinFileSize.Text = fs.Length.ToString();
                    textBinVerNO.Text = String.Format("{0:X2}.{1}.{2}", sv_year, sv_modify, sv_user);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error");
            }
        }





        FirmwareUpdate _firmwareUpdate = null;

        private void Btn_固件升级_Click(object sender, EventArgs e)
        {
            if ((BinPathTxt.Text == ""))
            {
                MessageBox.Show("请选择bin文件");
                return;
            }

            if ((FirmwarePackedSizeCmb.Text == ""))
            {
                MessageBox.Show("请选择数据包大小");
                return;
            }


            if (Btn_固件升级.Text == "开始")
            {
                _firmwareUpdate = new FirmwareUpdate(BinPathTxt.Text, 
                    int.Parse(textTryCnt.Text), 
                    int.Parse(textTryTimeout.Text),
                    int.Parse(FirmwarePackedSizeCmb.Text),
                    DevModelTxt.Text,
                    cbClient.Text);
               
                Btn_固件升级.Text = "停止";
                MessageBox.Show("Thread_TransBinFile Start");
                _firmwareUpdate.OnTransFileIng += OnUpdate;
                _firmwareUpdate.OnTransFileOver += OnUpdateOver;
                _firmwareUpdate.Start(AppendSendMsg);
            }
            else
            {
                Btn_固件升级.Text = "开始";
                MessageBox.Show("Thread_TransBinFile End!!!");
                
                _firmwareUpdate.Stop();
                _firmwareUpdate.DataDis -= AppendSendMsg;

            }
        }
        public  void OnUpdate(Int32 progressBarValue, Int32 progressBarMaximum, Int32 remainingTime)
        {            
            if (固件升级进度条.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    固件升级进度条.Value = progressBarValue;
                    固件升级进度条.Maximum = progressBarMaximum;
                }));
            }
            else
            {
                固件升级进度条.Value = progressBarValue;
                固件升级进度条.Maximum = progressBarMaximum;
            }

            if (剩余时间label.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    剩余时间label.Text = "剩余时间:" + remainingTime.ToString();
                }));
            }
            else
            {
                剩余时间label.Text = "剩余时间:" + remainingTime.ToString();
            }             
        }

        public void OnUpdateOver(Int32 progressBarValue, Int32 progressBarMaximum, Int32 remainingTime)
        {
            if (Btn_固件升级.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Btn_固件升级.Text = "开始";
                }));
            }
            else
            {
                Btn_固件升级.Text = "开始";
            }
            MessageBox.Show("Thread_TransBinFile Over!!!");
        }
        #endregion


        #region 界面按钮触发
        private void btn_协议解析_Click(object sender, EventArgs e)
        {
            byte[]  unPackData = new byte[2048];
            byte[] Data = Hex.FromHEXString(textBox2.Text.Trim());

            int len = -1;//消息体长度

            List<byte> pkt_buf = new List<byte>();
            pkt_buf.AddRange(Data);

            pkt_buf.Insert(0,0x11);

            //提取7E报文
            int start_index = pkt_buf.IndexOf(0x7e);
            pkt_buf.RemoveRange(0, start_index+1);

            int end_index = pkt_buf.IndexOf(0x7e);
            pkt_buf.RemoveRange(end_index, 1);


            byte[] rx_buf = new byte[end_index - start_index+1];
            Array.Copy(pkt_buf.ToArray(), rx_buf, rx_buf.Length);


            //转义解包
            bool isCRCOK = JT808.Unpack(rx_buf, rx_buf.Length, unPackData, out len);
            string str_recFrame = isCRCOK ? "CRC OK\r\n" : "CRC ERROR\r\n";

            //消息ID

            int oft=0;
            str_recFrame += string.Format("消息ID = 0x{0:X4}\r\n", BitConverter.ToUInt16(unPackData, oft));
            oft+=2;

            UInt16 property = BitConverter.ToUInt16(unPackData, oft);
            oft += 2;

            str_recFrame += string.Format("消息体属性:\r\n消息体长度 = {0}\r\nresBit10 = {1}\r\n数据加密方式 = {2}-{3}\r\n分包 = {4}\r\n时间标签 ={5}\r\nresBit15 = {6}\r\n",
                property & (UInt16)0x03FFF,
                Bits.GetbitValue(property,10),
                Bits.GetbitValue(property,11),Bits.GetbitValue(property,12),
                Bits.GetbitValue(property,13),
                Bits.GetbitValue(property,14),
                Bits.GetbitValue(property,15)
            );

            //终端手机号 BCD[7]
            str_recFrame += ("终端手机号:" + Hex.ToString(unPackData, oft, 7,"","") + "\r\n");
            oft += 7;

            //消息流水号 WORD
            str_recFrame += string.Format("消息流水号 = 0x{0:X4}\r\n", BitConverter.ToUInt16(unPackData, oft));
            oft += 2;

            //消息包封装项 BYTE[4]

            //时间标签Tp DATETIME

            //消息体
            str_recFrame += ("\r\n消息体:\r\n" + Hex.ToString(unPackData, oft, len - oft) + "\r\n");
            txtMsg.AppendText(str_recFrame);
        }

        private void numericUpDown控制灯盏数_ValueChanged(object sender, EventArgs e)
        {
            LampUserControl.lampCtrlList.Clear();

            LampUserControl.lampId = 1;

            for (int i=0; i< numericUpDown1.Value; i++)
            {
                LampUserControl.lampCtrlList.Add(new LampUserControl(LampUserControl.lampId++) { 开关档位 = 100 });
            }
            EsxUserCtrlGrid.RefreshDataSource();

        }

        private void btn_单灯遥控_Click(object sender, EventArgs e)
        {
            /*
            byte[] tBuf = new byte[512];
            int oft = 0;          
            
            //消息体

            //参数总数 N 
            tBuf[oft++] = (byte)gridView1.RowCount;
            for (int i = 0; i < gridView1.RowCount; i++)
            { 
            //参数i
                //0 FN BYTE FN见表A.8.21.3
                tBuf[oft++] = 9;//F9灯盏遥控

                //1 FN数据单元
                    //灯序号/灯盏回路号 BIN 1
                    tBuf[oft++] = byte.Parse(this.gridView1.GetRowCellValue(i, gridView1.Columns["灯盏序号"]).ToString());

                    //开关档位 BIN 1
                    tBuf[oft++] = byte.Parse(this.gridView1.GetRowCellValue(i, gridView1.Columns["开关档位"]).ToString());
            }
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_TERMINAL_CTL, msgbody, 0);
            */
            PointUserControl(cbClient.Text, LampUserControl.lampCtrlList);
        }



        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo
            Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }

        private void btn_时钟设置_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(dateTimePicker.Value.ToString(dateTimePicker.CustomFormat));
            PointSynTime(cbClient.Text, dt);
        }

        private void btn_时钟查询_Click(object sender, EventArgs e)
        {
            byte[] tBuf = new byte[512];
            int oft = 0;

            //组包
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_QUERY_RTC, msgbody, 0);
        }
        #endregion


        #region 表格界面初始化
        public void InitEsxUserControlTable()
        {
            for (int i = 0; i < 2; i++)
            {
                LampUserControl.lampCtrlList.Add(new LampUserControl(LampUserControl.lampId++) { 开关档位 = 100 });
            }
            EsxUserCtrlGrid.DataSource = LampUserControl.lampCtrlList;


            for (int i = 0; i < 8; i++)
            {
                LampTimeCtrl.lampCtrlList.Add(new LampTimeCtrl(LampTimeCtrl.gradeNo++) { 小时 = 0, 分钟 = 0, CH1开关档位 = 255, CH2开关档位 = 255 });
            }
            EsxTimeCtrlGrid.DataSource = LampTimeCtrl.lampCtrlList;        
        }


        public void InitEsxStatusTable()
        {
            const byte COL_MAX = 7;
            const byte COL_设备报警 = 6;
            const byte COL_设备状态 = 4;

            const byte ROW_MAX = 12;


            //行列数据清除
            dGV_esxStatus.Rows.Clear();
            dGV_esxStatus.Columns.Clear();

            //标定系数表格表头
            dGV_esxStatus.ColumnHeadersVisible = true;
            dGV_esxStatus.ColumnCount = COL_MAX;


            for (int index = 0; index < COL_MAX; index++)
            {
                //dataGridView2.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;//列自动大小
                dGV_esxStatus.Columns[index].ReadOnly = true;//只读
                dGV_esxStatus.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;//不进行分类
            }

            //灯盏状态（回路1...4）
            int oft = 0;
            for (int index = 0; index < 4; index++)
            {
                dGV_esxStatus.Columns[oft].HeaderCell.Value = "第" + (index + 1).ToString() + "路";
                dGV_esxStatus.Columns[oft].Width = 60;
                oft += 1;
            }

            //设备状态（模式，运行时间, RTC，开关灯时间...）
            dGV_esxStatus.Columns[oft].HeaderCell.Value = "设备状态";
            dGV_esxStatus.Columns[oft].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGV_esxStatus.Columns[oft].Width = 100;   
            oft += 1;

            dGV_esxStatus.Columns[oft].HeaderCell.Value = "";
            dGV_esxStatus.Columns[oft].Width = 150;
            oft += 1;

            //设备报警信息
            dGV_esxStatus.Columns[oft].HeaderCell.Value = "设备报警";
            dGV_esxStatus.Columns[oft].Width = 100;
            oft += 1;

            //行表头ROW数据
            dGV_esxStatus.RowCount = ROW_MAX;
            dGV_esxStatus.RowHeadersWidth = 100;

            dGV_esxStatus.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Regular);
            dGV_esxStatus.RowHeadersDefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Regular);


            string[] Field = { "控制值", "电压(V)", "电流(mA)", "功率(W)", "电容故障", "光源损坏", "继电器故障", "过流", "灯灭", "自熄灯次数", "功率因数", };
            for (int i = 0; i < Field.Length; i++)
            {
                dGV_esxStatus.Rows[i].HeaderCell.Value = Field[i];
                //dataGridView2.Rows[i].Cells[COL_设备状态].Style.BackColor = Color.AliceBlue;
            }

            string[] FieldDevStatus = { "控制模式", "实时时间", "运行时间", "开灯时间", "水浸", "复位次数" };
            for (int i = 0; i < FieldDevStatus.Length; i++)
            {
                dGV_esxStatus.Rows[i].Cells[COL_设备状态].Value = FieldDevStatus[i];
            }

            string[] FieldDevAlarm = { "RTC异常", "FLASH异常", "CFG异常", "过压", "欠压", "熔丝故障", "读卡故障", "漏电流", "其他" };
            for (int i = 0; i < FieldDevAlarm.Length; i++)
            {
                dGV_esxStatus.Rows[i].Cells[COL_设备报警].Value = FieldDevAlarm[i];
            }
            //dGV_esxStatus.Rows[8].Cells[COL_设备报警].Style.BackColor = Color.Yellow;

            //不允许用户编辑自动增加行
            dGV_esxStatus.AllowUserToAddRows = false;

        }

        public void InitEsxNetCfgTable()
        {
            //DataTable dt = new DataTable("Table_NetCfg");
            //dt.Columns.Add("chk", System.Type.GetType("System.Boolean"));
            //dt.Columns["chk"].DefaultValue = Boolean.FalseString;

            DataTable dt = DT_网络参数;

            dt.Columns.Add("name", System.Type.GetType("System.String"));
            dt.Columns["name"].DefaultValue = String.Empty;
            dt.Columns["name"].ReadOnly = true;

            dt.Columns.Add("id", System.Type.GetType("System.String"));
            dt.Columns["id"].DefaultValue = String.Empty;
            dt.Columns["id"].ReadOnly = true;

            dt.Columns.Add("LimitLen", System.Type.GetType("System.String"));
            dt.Columns["LimitLen"].DefaultValue = String.Empty;
            dt.Columns["id"].ReadOnly = true;

            dt.Columns.Add("value", System.Type.GetType("System.String"));
            dt.Columns["value"].DefaultValue = String.Empty;

            //1.创建空行
            //DataRow dr = dt.NewRow();
            //dt.Rows.Add(dr);

            //2.创建空行=
            //dt.Rows.Add();

            //3.通过行框架创建并赋值 
            //dt.Rows.Add("第一列值", "第二列值","第三列值");
            foreach (PraseNetCfg.NET_CFG_INFO_S item in PraseNetCfg.cfgInfo)
            {
                dt.Rows.Add(item.cfgName, item.cfgID.ToString("x4"), item.cfgLimitLen.ToString());

                //Type tp = item.cfgType;
                //MessageBox.Show(tp.ToString());
            }
            EsxNetGrid.DataSource = dt;
            this.gv.OptionsCustomization.AllowSort = false;// 是否禁止所有列排序
            /*
            gv.OptionsView.ColumnAutoWidth = false;
            for (int I = 0; I < gv.Columns.Count; I++)
            {
                this.gv.BestFitColumns();
                this.gv.Columns[I].BestFit();//自动列宽
            }
            */       
        }
        #endregion
        public void RefreshEsxStatusTable(byte[] msgbody)
        {
            int oft = 0;

            int  row_DeviceStatus =0 ,  row_LampStatus =0;
            
            //应答流水号
            oft += 2;

 
            //控制模式WORD
            dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = BitConverter.ToUInt16(msgbody, oft).ToString("X4"); oft += 2;

            //设备报警WORD
            {
                UInt16 Dalarm = BitConverter.ToUInt16(msgbody, oft); oft += 2;
                for (int row_alarm = 0; row_alarm < 10; row_alarm++)
                {
                    if ((Dalarm & 0x01) == 0x01)
                    {
                        dGV_esxStatus.Rows[row_alarm].Cells[6].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        dGV_esxStatus.Rows[row_alarm].Cells[6].Style.BackColor = Color.White;
                    }
                    Dalarm >>= 1;
                }
            }

            //设备RTC时间
            {
                int _year = BCD.ToByte(msgbody[oft++]) + 2000;
                int _month = BCD.ToByte(msgbody[oft++]);
                int _day = BCD.ToByte(msgbody[oft++]);
                int _hour = BCD.ToByte(msgbody[oft++]);
                int _minute = BCD.ToByte(msgbody[oft++]);
                int _second = BCD.ToByte(msgbody[oft++]);

                //2009-05-01 14:57:32.8
                string strDate = _year.ToString() + "-"
                    + _month.ToString() + "-"
                    + _day.ToString() + " "
                    + _hour.ToString() + ":"
                    + _minute.ToString() + ":"
                    + _second.ToString();

                DateTime result = DateTime.MinValue;

                //其他信息: 年、月和日参数描述无法表示的 DateTime, todo?
                if (DateTime.TryParse(strDate, out result))
                {
                    //DateTime dt = new DateTime(_year, _month, _day, _hour, _minute, _second);
                    dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = result.ToString();
                }
                else
                {
                    dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = "时间格式异常！";
                }  
            }

            //累计运行时间DWORD
            {
                dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = BitConverter.ToUInt32(msgbody, oft).ToString(); oft += 4;
            }

            //累计电量
            {
                //oft += 4;
            }

            //开灯时间
            {
                dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = BitConverter.ToUInt16(msgbody, oft).ToString("x4"); oft += 2;//4byte 占8个数字
            }

            //漏电
            {
                //电压
                //dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = BitConverter.ToUInt16(msgbody, oft).ToString(); oft += 2;
                //电流
                //dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = BitConverter.ToUInt16(msgbody, oft).ToString(); oft += 2;

            }

            //杂项[复位次数]
            {
                //水浸
                dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = msgbody[oft++]; 
             
                //复位次数
                dGV_esxStatus.Rows[row_DeviceStatus++].Cells[5].Value = msgbody[oft++];

                //环境光照度
                //dGV_esxStatus.Rows[8].Cells[5].Value = BitConverter.ToUInt16(msgbody, oft).ToString(); oft += 2;
            }

            int ChCol_n = msgbody[oft++];
            int _row_t = 0;
            int _col_t = 0;

            //灯盏状态[1...2]
            for (_col_t = 0; _col_t < ChCol_n; _col_t++)
            {
                _row_t = row_LampStatus;

                //灯盏回路号 范围（1~4）
                int _ch_t = msgbody[oft++];
                if (_ch_t < 1)
                {
                    return;
                }
                _ch_t -= 1;

                //"控制值byte";
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = msgbody[oft++].ToString();

                //"电压WORD";
                UInt16 u16Volt = BitConverter.ToUInt16(msgbody, oft); oft += 2;
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = u16Volt.ToString();

                //"电流WORD";
                UInt16 u16Current = BitConverter.ToUInt16(msgbody, oft); oft += 2;
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = u16Current.ToString();

                //"功率WORD";//单位0.1W
                UInt16 u16Power = BitConverter.ToUInt16(msgbody, oft); oft += 2;
                float fPower = u16Power / 10F;
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = u16Power.ToString("F1");

                //"电容故障bit0";
                //"光源损坏bit1";
                //"继电器故障bit2";
                //"过流bit3";
                //"灯灭bit4";
                byte Lalarm = msgbody[oft++];
                for (int i = 0; i < 5; i++)
                {
                    if ((Lalarm & 0x01) == 0x01)
                    {
                        dGV_esxStatus.Rows[_row_t + i].Cells[_ch_t].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        Color cl = dGV_esxStatus.Rows[_row_t + i].Cells[_ch_t].Style.BackColor = Color.White;
                    }

                    Lalarm >>= 1;
                }
                _row_t += 5;


                //"自熄灯次数bit5...7";
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = msgbody[oft++];

                //功率因数(有功 / 总功率)*100 
                UInt16 u16Tpower = (UInt16)(u16Volt * u16Current);
                UInt16 Qvalue = 0;

                if (u16Tpower != 0)
                {
                    Qvalue = (UInt16)(100 /*百分*/* u16Power / 10/*单位0.1w*/ * 1000/*电流ma*/ / (u16Volt * u16Current));
                }


                if (Qvalue > 100)
                {
                    Qvalue = 100;
                }
                dGV_esxStatus.Rows[_row_t++].Cells[_ch_t].Value = Qvalue.ToString();

                //预留
                oft += 2;
            }
            row_LampStatus = _row_t;

            //other
        }
        public void RefreshEsxTerminalCfgTable(byte[] msgbody)
        {
            int oft = 0;         
            oft += 2;//应答流水号                 
            byte par_cnt = msgbody[oft++];//包参数个数 BYTE  

            this.Invoke((EventHandler)(delegate
            {
                for (int i = 0; i < par_cnt; i++)
                {
                    UInt32 par_id = BitConverter.ToUInt32(msgbody, oft);
                    oft += 4;

                    byte par_len = msgbody[oft++];
                    switch (par_id)
                    {
                        case 0x00000001:
                            {//设备序列号
                                设备序列号txt.Text = Hex.ToString(msgbody, oft, par_len, " ", "");
                            }
                            break;
                        case 0x00000002:
                            {//版本号
                                //旧协议集中器协议版本号2字节,todo? 兼容模式
                                版本号Txt.Text = "";
                                for (int index = 0; index < par_len; index++)
                                {
                                    if (index == 0)
                                    {
                                        版本号Txt.AppendText(msgbody[oft+index].ToString("x2"));
                                    }
                                    else
                                    {
                                        版本号Txt.AppendText("." + msgbody[oft+index].ToString());
                                    }                                  
                                }                               
                            }
                            break;
                        case 0x00000003:
                            {//终端安装位置
                                安装位置Txt.Text = Hex.ToString(msgbody, oft, par_len, " ", "");
                            }
                            break;
                        case 0x00000004:
                            {//设备地址
                                设备地址Txt.Text = Hex.ToString(msgbody, oft, par_len, " ", "");
                            }
                            break;
                        default:
                            {                        
                            }
                            break;
                    }
                    //偏移增加参数len
                    oft += par_len;
                    if (oft >= msgbody.Length)
                    {
                        break;
                    }
                }
            }));
        }
        public void RefreshJwdTimeTable(byte[] msgbody)
        { 
             int oft = 0;         
            oft += 2;//应答流水号                 


            //0x18290530(开灯 18:29 关灯 5:30)
            this.Invoke((EventHandler)(delegate
            {
                int row = 0, col = 3;
                while (oft < msgbody.Length)
                {
                    DGV_JWD.Rows[row].Cells[col--].Value = BCD.ToByte(msgbody[oft++]);

                    if (col < 0)
                    {
                        col = 3;
                        row++;
                    }
                }
            }));        
        }

        public void RefreshTimeCtrlTable(byte[] msgbody)
        { 
            int oft = 0;         
            oft += 2;//应答流水号                 

            this.Invoke((EventHandler)(delegate
            {
                byte cfgByte = msgbody[oft++];

                TimingCtlEnable.Checked = Bits.GetbitValue(cfgByte, 0) == 1 ? true : false;
                TimingCtlDissable.Checked = !TimingCtlEnable.Checked;

                TimingCtlAbsolute.Checked = Bits.GetbitValue(cfgByte, 1) == 1 ? true : false;
                TimingCtlRelative.Checked = !TimingCtlAbsolute.Checked;

                //MessageBox.Show("时段数:" + ((byte)(cfgByte >> 4)).ToString());

                //时段选择标志位
                byte gradeMask = msgbody[oft++];
                //
                LampTimeCtrl.lampCtrlList.Clear();

                for (int i = 0; i < 8; i++)
                {
                    if (Bits.GetbitValue(gradeMask, i) == 1)
                    {
                        /*
                        0 路数选择标志位 BYTE 
                        1 时段策略 
                            0 0x00~0x23 小时 
                            1 0x00~0x59 分钟 
                            2 0x00~0xFF 第 1 路控制值 
                        */
                        byte channelMask = msgbody[oft++];

                        byte hour = msgbody[oft++];
                        if (hour <= 0x99)
                        {
                            hour = BCD.ToByte(hour);
                        }
                        byte min = msgbody[oft++];
                        if (min <= 0x99)
                        {
                            min = BCD.ToByte(min);
                        }

                        byte[] switchGear = new byte[8];
                        
                        for (int j = 0; j < 8; j++)
                        {
                            if (Bits.GetbitValue(channelMask, j) == 1)
                            {
                                switchGear[j] = msgbody[oft++];
                            }
                        }
                        LampTimeCtrl.lampCtrlList.Add(new LampTimeCtrl(i + 1) { 小时 = hour, 分钟 = min, CH1开关档位 = switchGear[0], CH2开关档位 = switchGear[1] });
                    }
                }
                EsxTimeCtrlGrid.RefreshDataSource();
            }));        
        }

        public void RefreshNetCfgTable(byte[] msgbody)
        { 
            int oft = 0;  
            
            //应答流水号    
            oft += 2;             
            //参数个数
            byte cfgCnt = msgbody[oft++];

            for (int i = 0; i < cfgCnt; i++)
            {
                //参数ID
                UInt32 cfgid = BitConverter.ToUInt32(msgbody, oft);
                oft += 4;
                //参数LEN
                byte cfgLen = msgbody[oft++];
                //参数VAULES
                byte[] values = new byte[cfgLen];
                Array.Copy(msgbody, oft, values, 0, cfgLen);
                oft += cfgLen; 
           
                this.Invoke((EventHandler)(delegate
                {
                    //对表已有行进行赋值
                    //dt.Rows[0][0] = "张三"; //通过索引赋值
                    //参数ID，遍历查找，判断参数长度
                    int index = 0;
                    for (index = 0; index < PraseNetCfg.cfgInfo.Length; index++)
                    {
                        if (PraseNetCfg.cfgInfo[index].cfgID == cfgid)
                        {
                            break;
                        }
                    }

                    if (index >= PraseNetCfg.cfgInfo.Length)
                    {
                        MessageBox.Show("未定义参数ID" + cfgid.ToString("x8"));
                        return;
                    }

                    DataTable dt = DT_网络参数;

                    if (PraseNetCfg.cfgInfo[index].cfgType == typeof(UInt32))
                    {
                        dt.Rows[index]["value"] = BitConverter.ToUInt32(values, 0).ToString();  
                    }
                    else if (PraseNetCfg.cfgInfo[index].cfgType == typeof(String))
                    {
                        dt.Rows[index]["value"] = Encoding.ASCII.GetString(values);
                    }
                    else if (PraseNetCfg.cfgInfo[index].cfgType == typeof(byte[]))
                    {
                        dt.Rows[index]["value"] = Hex.ToString(values, 0, values.Length, " ", "");
                    }
                    else
                    {
                        MessageBox.Show(PraseNetCfg.cfgInfo[index].cfgType.ToString() + "unkonow　type！");
                    }
                          

                    //dt.Rows[0]["column1"] = DateTime.Now;//通过名称赋值
                }));    
            }
        }
        

        public void PointCopyStatus(string endpoint)
        {
            byte[] tBuf = new byte[512];

            //消息体
            int oft = 0;

            //查询灯盏总数N
            tBuf[oft++] = 4;

            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_QUERY_REALTIME_DATA, msgbody, 0, endpoint);

    
        }

        public void PointSynTime(string endpoint, DateTime dt)
        {
            byte[] tBuf = new byte[512];
            int oft = 0;

            //DATETIME
            tBuf[oft++] = BCD.FromByte(dt.Year % 100);
            tBuf[oft++] = BCD.FromByte(dt.Month);
            tBuf[oft++] = BCD.FromByte(dt.Day);
            tBuf[oft++] = BCD.FromByte(dt.Hour);
            tBuf[oft++] = BCD.FromByte(dt.Minute);
            tBuf[oft++] = BCD.FromByte(dt.Second);

            //组包
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_RTC_SETTING, msgbody, 0);        
        }

        public void PointUserControl(string endpoint,  List<LampUserControl> lamplsit)
        {
            byte[] tBuf = new byte[512];
            int oft = 0;

            //消息体

            //参数总数 N 
            tBuf[oft++] = (byte)lamplsit.Count;
            for (int i = 0; i < lamplsit.Count; i++)
            {
                //参数i
                //0 FN BYTE FN见表A.8.21.3
                tBuf[oft++] = 9;//F9灯盏遥控

                //1 FN数据单元
                //灯序号/灯盏回路号 BIN 1
                tBuf[oft++] = (byte)lamplsit.ElementAt(i).灯盏序号;

                //开关档位 BIN 1
                tBuf[oft++] = (byte)lamplsit.ElementAt(i).开关档位;
            }
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_TERMINAL_CTL, msgbody, 0);        
        }


        private void btn_状态招测_Click(object sender, EventArgs e)
        {
            PointCopyStatus(cbClient.Text);
        }
        
        Thread ThreadQueryInterval = null;
        private void chk_定时读取_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_定时读取.Checked == true)
            {
                //QueryIntervalTime
                ThreadQueryInterval = new Thread(new ThreadStart(定时召测));
                ThreadQueryInterval.Priority = ThreadPriority.BelowNormal;
                ThreadQueryInterval.Start();
            }
            else
            {
                if (ThreadQueryInterval != null)
                { 
                    ThreadQueryInterval.Abort();
                } 
            }
        }


        //定时召测
        private void 定时召测()
        {
            int interval = -1;

            while (true)
            {
                this.Invoke((EventHandler)(delegate
                {
                    btn_状态招测.PerformClick();

                    interval = (int)QueryIntervalTime.Value;
                }));

                Thread.Sleep(interval);
            }
        }


        private void ToolStripConnectionSetup_Click(object sender, EventArgs e)
        {
            ConnectSetupForm testDialog = new ConnectSetupForm();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                
                //获取当前串口号
                SerialPort _sp = Transmission.cfg.settings.serialPort;
                cbSerial.SelectedIndex = cbSerial.Items.IndexOf(_sp.PortName);
            }
            else
            {

            }
            testDialog.Dispose();
        }

        private void ToolStripEcxStatusRead_Click(object sender, EventArgs e)
        {
            //Treelsit checkbox 选中的灯杆
            TreeListCheckedList("招测的设备手机号");

            //查字典，对应出灯杆socket 通讯的endpoint
            for (int i = 0; i < lstCheckedOfficeID.Count; i++)
            {               
                string telnum = lstCheckedOfficeID[i];
                string endpoint = _listEndPoint.Select(telnum);

                if (endpoint!=null)
                {//发送招测命令
                    PointCopyStatus(endpoint);
                }            
            }
        }

        private void ToolStripEcxTimeSyn_Click(object sender, EventArgs e)
        {
            //Treelsit checkbox 选中的灯杆
            TreeListCheckedList("同步时间的设备手机号");

            //查字典，对应出灯杆socket 通讯的endpoint
            for (int i = 0; i < lstCheckedOfficeID.Count; i++)
            {
                string telnum = lstCheckedOfficeID[i];
                string endpoint = _listEndPoint.Select(telnum);

                if (endpoint != null)
                {//发送招测命令
                    PointSynTime(cbClient.Text, DateTime.Now);
                }
            }
        }
        private void ToolStripEcxLampControl_Click(object sender, EventArgs e)
        {
            //Treelsit checkbox 选中的灯杆
            TreeListCheckedList("开关的设备手机号");

            EcxUserControl testDialog = new EcxUserControl();

            testDialog.StartPosition = FormStartPosition.CenterParent;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
                //查字典，对应出灯杆socket 通讯的endpoint
                for (int i = 0; i < lstCheckedOfficeID.Count; i++)
                {
                    string telnum = lstCheckedOfficeID[i];
                    string endpoint = _listEndPoint.Select(telnum);

                    if (endpoint != null)
                    {//发送招测命令
                        PointUserControl(endpoint, LampUserControl.lampCtrlList);
                    }
                }
                EsxUserCtrlGrid.RefreshDataSource();
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }

        private void btnQuickConnect_Click(object sender, EventArgs e)
        {
            SerialPort _sp = Transmission.cfg.settings.serialPort;
            if (_sp.IsOpen != true)//如果打开状态，则先关闭一下
            {
                _sp.Close();
            }

            try
            {
                COM port_com = new COM(_sp);
                List<Port> ports = new List<Port>();
                ports.Add(port_com);

                Transmission.Init(ports);
                Transmission.Run();
            }
            catch (System.Exception ex)
            {
                tsbtnDisconnect.Enabled = false;

                工具条_COM_状态.Text = ex.Message;
                工具条_COM_状态.ForeColor = Color.Red;

                MessageBox.Show("Error:" + ex.Message, "Error");
                return;
            }
            tsbtnQuickConnect.Enabled = false;
            tsbtnDisconnect.Enabled = true;

            工具条_COM_状态.Text = _sp.PortName + " OPENED, " + Profile.G_BAUDRATE + "," + Profile.G_DATABITS + "," + Profile.G_STOP + "," + Profile.G_PARITY;
            工具条_COM_状态.ForeColor = Color.Green;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            SerialPort _sp = Transmission.cfg.settings.serialPort;
            if (_sp.IsOpen == true)//如果打开状态，则先关闭一下
            {
                _sp.Close();
            }
            tsbtnQuickConnect.Enabled = true;
            tsbtnDisconnect.Enabled = false;

            工具条_COM_状态.Text = Profile.G_PORTNAME + " CLOSED";
            工具条_COM_状态.ForeColor = Color.Red;
        }

        public class praseEventArgs : EventArgs
       {
            public byte[] buf { get; set; }
        }

        public delegate void praseEventHandler(Object sender, praseEventArgs e);
        public static event praseEventHandler praseFrame;


        public static void cbFunc(byte[] pFrame)  //假设这个是静态的回调方法
        {
            praseEventArgs e = new praseEventArgs();
            e.buf = pFrame;


            praseFrame(new ServerForm(), e);
        }

        public void ProcEvent(Object o, praseEventArgs e)  //事件处理函数
        {
            OnReceiveMsgPrase("", e.buf);
        }

        #region calc Tool
        private void 计算CRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolCalcCrc8Form testDialog = new ToolCalcCrc8Form();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }

        private void 计算器ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo
            Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }

        private void 转换工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolConvertForm testDialog = new ToolConvertForm();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }
        private void bH1750透光率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolBH1750 testDialog = new ToolBH1750();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }
        #endregion

        private void Btn_TerCtl_Click(object sender, EventArgs e)
        {
            byte[] tBuf = new byte[512];
            int oft = 0;

            //参数个数N   BYTE
            tBuf[oft++] = 1;

            if (RB_集中器复位.Checked == true)
            {
               /*
                0 FN BYTE FN 见表 A.8.21.3
                1 PN WORD
                3 FN 数据单元
                */
                tBuf[oft++] = 1;                  
                
                //PN(网关模式--从节点灯盏序号)
                Bytes.FromUInt16((ushort)(0), tBuf, oft);
                oft += 2;

                //FN数据单元
                    /*
                    重启类别：0x01--完全初始化，重启设备；0x02保存当前运行数据，并重启
                    003保留参数清除历史数据重启设备
                    */
                tBuf[oft++] = 0x01;
            }
            else if (RB_主节点单灯复位.Checked == true)
            {
                //FN BYTE
                /*
                 F1 终端复位
                 F2 
                 */
                tBuf[oft++] = 1;

                //FN数据单元
                tBuf[oft++] = 0x01;
            }
            else
            {
                MessageBox.Show("未实现功能!");
                return;    
            }    
           
            //组包
            byte[] msgbody = tBuf.Take(oft).ToArray();
            PackageFrameAndSent(MsgID.MSG_TERMINAL_CTL, msgbody, 0);
        }

        #region 终端参数查询设置
        string[] cfgTab = { "终端参数","网络参数","节能策略","  临时开关灯时间","经纬度开关灯时间",};
        private void btn_设置参数_Click(object sender, EventArgs e)
        {
            byte[] tBuf = new byte[1024];
            int oft = 0;

            switch (tabControl_cfg.SelectedTab.Text)
            {
                case "临时开关灯时间":
                    {
                        /*
                        0 开灯时间 BCD[2] BCD[0]时 ，BCD[1]分
                        2 关灯时间 BCD[2] BCD[0]时 ，BCD[1]分
                        4 执行的开始日期 BCD[3] BCD[0]年，BCD[1]月，BCD[2]日
                        7 执行的天数 BYTE 注：value= 0xFF 表示一直有效！
                        */
                        tBuf[oft++] = BCD.FromByte(OnLightDtp.Value.Hour);
                        tBuf[oft++] = BCD.FromByte(OnLightDtp.Value.Minute);

                        tBuf[oft++] = BCD.FromByte(OffLightDtp.Value.Hour);
                        tBuf[oft++] = BCD.FromByte(OffLightDtp.Value.Minute);

                        tBuf[oft++] = BCD.FromByte(startDtp.Value.Year % 100);
                        tBuf[oft++] = BCD.FromByte(startDtp.Value.Month);
                        tBuf[oft++] = BCD.FromByte(startDtp.Value.Day);

                        tBuf[oft++] = (byte)ValidNumupdowm.Value;

                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_TMP_STRATEGY_SETTING, msgbody, 0);
                    }
                    break;

                case "经纬度开关灯时间":
                    {
                        /*
                        0 要写开关时间开始月 BYTE BCD
                        1 要写开关时间开始日 BYTE
                        2 要写开关时间天数 N WORD 366>=N>=1
                        4 第 1 天开关时间 DWORD
                        0x18290530(开灯 18:29 关灯
                        5:30)
                        8 第 2 天开关时间 DWORD
                        ; … …
                        4*N 第 N 天开关时间 DWORD                        
                        */
                        tBuf[oft++] = BCD.FromByte((byte)JWD_S_MONTH.Value);
                        tBuf[oft++] = BCD.FromByte((byte)JWD_S_DAY.Value);

                        Bytes.FromUInt16((UInt16)JWD_DAYS.Value, tBuf, oft);
                        oft += 2;

                        //month_1byte_bcd
                        for (int i = 0; i < JWD_DAYS.Value; i++)
                        {
                            //开关灯时间_4byte_0x17300500
                            //OFF MIN
                            //OFF HOUR

                            //ON MIN
                            //ON HOUR                
                            tBuf[oft++] = BCD.FromByte(Convert.ToByte(DGV_JWD.Rows[i].Cells[3].Value));
                            tBuf[oft++] = BCD.FromByte(Convert.ToByte(DGV_JWD.Rows[i].Cells[2].Value));
                            tBuf[oft++] = BCD.FromByte(Convert.ToByte(DGV_JWD.Rows[i].Cells[1].Value));
                            tBuf[oft++] = BCD.FromByte(Convert.ToByte(DGV_JWD.Rows[i].Cells[0].Value));
                        }

                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_JWD_STRATEGY_SETTING, msgbody, 0);
                    }
                    break;

                case "节能策略":
                    {
                        /*配置（启用标志， 相对/绝对时间）*/
                        byte TimmingCtlCfg = 0;
                        if (TimingCtlEnable.Checked == true)
                        {
                            TimmingCtlCfg |= (1 << 0);
                        }
                        if (TimingCtlAbsolute.Checked == true)
                        {
                            TimmingCtlCfg |= (1 << 1);
                        }
                        //启用时段数
                        TimmingCtlCfg |= (8 << 4);
                        tBuf[oft++] = TimmingCtlCfg;


                        //时段选择标志位(8段)
                        byte gradeMask = 0xFF;
                        tBuf[oft++] = gradeMask;

                        for (int i = 0; i < LampTimeCtrl.lampCtrlList.Count; i++)
                        {
                            //路数选择标志位
                            tBuf[oft++] = 0x03;

                            //小时BCD
                            tBuf[oft++] = BCD.FromByte(LampTimeCtrl.lampCtrlList[i].小时);
                            //分钟BCD
                            tBuf[oft++] = BCD.FromByte(LampTimeCtrl.lampCtrlList[i].分钟);    
                            
                            //CH1,CH2
                            tBuf[oft++] = LampTimeCtrl.lampCtrlList[i].CH1开关档位;
                            tBuf[oft++] = LampTimeCtrl.lampCtrlList[i].CH2开关档位;
                        }
                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_ESX_ENERGY_SAVE_SETTING, msgbody, 0); 
                    }
                    break;
                case "网络参数":
                    {
                        /*
                        0 包参数个数 BYTE
                        1 参数项列表
                        -参数 ID DWORD 参数 ID 定义及说明表 A.8.6.3
                        -参数长度 BYTE L>0
                        -参数值 DWORD 或 STRING，若为多值参数
                        */
                        int[] cfgItemSelected = gv.GetSelectedRows();
                        //参数个数
                        tBuf[oft++] =(byte)cfgItemSelected.Length;
                        //
                        for (int i = 0; i < cfgItemSelected.Length; i++)
                        {
                            int index = cfgItemSelected[i];
                            //参数 ID
                            Bytes.FromUInt32(PraseNetCfg.cfgInfo[index].cfgID, tBuf, oft);
                            oft += 4;

                            //byte[] Vaule;
                            if (PraseNetCfg.cfgInfo[index].cfgType == typeof(UInt32))
                            {
                                //参数长度
                                tBuf[oft++] = 4;
                                //参数值
                                UInt32 value = Convert.ToUInt32(gv.GetDataRow(index)["value"]);
                                byte[] byteArray = BitConverter.GetBytes(value);

                                Array.Copy(byteArray, 0, tBuf, oft, byteArray.Length);
                                oft += byteArray.Length;
                            }
                            else if (PraseNetCfg.cfgInfo[index].cfgType == typeof(String))
                            {
                                byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(gv.GetDataRow(index)["value"].ToString());
                                //参数长度
                                tBuf[oft++] = (byte)(byteArray.Length + 1);
                                //参数值
                                Array.Copy(byteArray, 0, tBuf, oft, byteArray.Length);
                                oft += byteArray.Length;
                                //-结束符号
                                tBuf[oft++] = 0;
                            }
                            else if (PraseNetCfg.cfgInfo[index].cfgType == typeof(byte[]))
                            {
                                byte[] byteArray = Bytes.FromStr(gv.GetDataRow(index)["value"].ToString());
                                //参数长度
                                tBuf[oft++] = (byte)(byteArray.Length);
                                //参数值
                                Array.Copy(byteArray, 0, tBuf, oft, byteArray.Length);
                                oft += byteArray.Length;                           
                            }
                            else
                            {
                                MessageBox.Show(PraseNetCfg.cfgInfo[index].cfgType.ToString() + "unkonow　type！");
                            }
                        } 

                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_NETWORK_SETTING, msgbody, 0);
                    }
                    break;
                default:
                    {
                        MessageBox.Show("设置->未实现功能!");
                    }
                    break;
            }
        }

        private void btn_查询参数_Click(object sender, EventArgs e)
        {
            byte[] tBuf = new byte[1024];
            int oft = 0;

            switch (tabControl_cfg.SelectedTab.Text)
            {
                case "终端参数":
                    {
                        /*查询终端网络参数 消息 ID：0x8101      
                        - 0 参数 ID 总数 N BYTE N=0,标识查询全部参数;
                        - 1 参数 ID---1 DWORD
                        - … …
                        - 1+ (N-1)*4 参数 ID---N DWORD
                        */
                        tBuf[oft++] = 4;

                        for (UInt32 i = 0; i < 4; i++)
                        {
                            Bytes.FromUInt32(i + 1, tBuf, oft);
                            oft += 4;
                        }

                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_QUERY_TERMINAL, msgbody, 0);
                    }
                    break;

                case "临时开关灯时间":
                    {
                        /*
                        查询终端临时开关灯策略消息体为空
                        */
                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_QUERY_TMP_STRATEGY, msgbody, 0);
                    }
                    break;
                case "节能策略":
                    {
                        /*
                        0 时段选择标志位   BYTE    Bit0~bit7 依次对位表示第 1~8 时段，置“1”有效                       
                        1 路数选择标志位   BYTE    Bit0~bit7 依次对位表示第 1~8 输出，置“1”有效
                        */
                        tBuf[oft++] = 0xFF;//8段
                        tBuf[oft++] = 0x03;//CH11,CH2


                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_QUERY_ESX_ENERGY_SAVE, msgbody, 0);
                    }
                    break;

                case "网络参数":
                    {
                        /*
                        0               参数 ID 总数 N BYTE N=0,标识查询全部参数;
                        1               参数 ID---1 DWORD
                        … …
                        1+ (N-1)*4      参数 ID---N DWORD
                        */
                        tBuf[oft++] = 0;//全部参数

                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_QUERY_NETWORK, msgbody, 0);
                    }
                    break;

                case "经纬度开关灯时间":
                    {
                        /*
                         0 开关时间开始月  BYTE    BCD
                         1 开关时间开始日  BYTE
                         2 开关时间天数N  WORD    366>=N>=1
                        */
                        tBuf[oft++] = BCD.FromByte((int)JWD_S_MONTH.Value);
                        tBuf[oft++] = BCD.FromByte((int)JWD_S_DAY.Value);

                        Bytes.FromUInt16((UInt16)JWD_DAYS.Value, tBuf, oft);
                        oft += 2;

                        
                        byte[] msgbody = tBuf.Take(oft).ToArray();
                        PackageFrameAndSent(MsgID.MSG_QUERY_JWD_STRATEGY, msgbody, 0);
                    }
                    break;

                default:
                    {
                        MessageBox.Show("查询->未实现功能!");
                    }   
                    break;
            }
        }
        #endregion


        private int PackageFrameAndSent(UInt16 msgid, byte[] msgbody, UInt16 sn, string endpoint)
        {
            JT808 jt808 = new JT808();

            //消息体长度
            jt808.message_head.msgLengthBit0_9 = (UInt16)msgbody.Length;


            jt808.TCPSent += Transmission.SocketSent;
            jt808.UARTSent += Transmission.UartSent;
            jt808.DataDis += AppendSendMsg;

            //组包
            return jt808.PackageFrame(msgid, msgbody, sn, false, endpoint);        
        }


        private int PackageFrameAndSent(UInt16 msgid, byte[] msgbody, UInt16 sn)
        {
            return PackageFrameAndSent(msgid, msgbody, sn, cbClient.Text);
        }

        private int PackageFrameAndAck(UInt16 msgid, byte[] msgbody, UInt16 sn, string endPoint)
        {
            JT808 jt808 = new JT808();

            //消息体长度
            jt808.message_head.msgLengthBit0_9 = (UInt16)msgbody.Length;


            jt808.TCPSent += Transmission.SocketSent;
            jt808.UARTSent += Transmission.UartSent;
            jt808.DataDis += AppendSendMsg;

            //组包

            return jt808.PackageFrame(msgid, msgbody, sn, true, endPoint);                
        }




        #region 经纬度时间属性方法
        private void DGV_JWD_Changed()
        {
            //行列数据清除
            DGV_JWD.Rows.Clear();

            DGV_JWD.RowCount = (int)JWD_DAYS.Value;
            DGV_JWD.RowHeadersWidth = 80;

            //开始月
            //开始日
            //天数
            byte _montu_t = (byte)JWD_S_MONTH.Value;
            byte _day_t = (byte)JWD_S_DAY.Value;

            /*
            const  uint8_t  _days_in_month[12] = {
               Jan  Feb  Mar  Apr  May  Jun  Jul  Aug  Sep  Oct  Nov  Dec 
                 
            };
            */

            byte[] _days_in_month = new byte[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 0; i < DGV_JWD.RowCount; i++)
            {
                DGV_JWD.Rows[i].HeaderCell.Value = _montu_t.ToString() + "-" + _day_t.ToString();//01-21

                if (_day_t == _days_in_month[_montu_t - 1])
                {
                    _day_t = 1;

                    if (_montu_t == 12)
                    {
                        _montu_t = 1;
                    }
                    else
                    {
                        _montu_t++;
                    }
                }
                else
                {
                    _day_t++;
                }
            }



            DGV_JWD.Update();

            //标定系数初始化值
            for (int row = 0; row < 2; row++)
            {
                for (int Col = 0; Col < 4; Col++)
                {
                    // DGV_JWD.Rows[row].Cells[Col].Value = "200";//电压，功率值 标定系数 byte
                }
            }

            for (int row = 2; row < 4; row++)
            {
                for (int Col = 0; Col < 4; Col++)
                {
                    //DGV_JWD.Rows[row].Cells[Col].Value = "2048";//电压，电流 基准系数 word
                }
            }
        }

        private void JWD_DAYS_ValueChanged(object sender, EventArgs e)
        {
            DGV_JWD_Changed();
        }

        private void JWD_S_DAY_ValueChanged(object sender, EventArgs e)
        {
            DGV_JWD_Changed();
        }

        private void JWD_S_MONTH_ValueChanged(object sender, EventArgs e)
        {
            DGV_JWD_Changed();
        }
        #endregion


        public void InitTreeList(DataTable dt)
        {
            lock (lockSqlTableObj)
            {
                //OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + exePath + @"\文件名.mdb");
                OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + "灯盏列表.mdb");
                //
                conn.Open();
                string sql = "select * from dtLamp";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                da.Fill(dt); 
                conn.Close();

                BindTreeListData(dt);
                SetTreelistProperties();
            }            
        }

        private void BindTreeListData(DataTable dt)
        { 
            this.Invoke((EventHandler)(delegate
            {
                this.tlOffice.DataSource = dt;
                tlOffice.KeyFieldName = "KeyFieldName";
                //tlOffice.DataMember = "通讯时间";
                tlOffice.Columns["NodeName"].Caption = "责任区";
                tlOffice.ParentFieldName = "ParentFieldName";
            }));
        }

        private void SetTreelistProperties()
        { 
            tlOffice.OptionsView.ShowCheckBoxes = true;//是否显示CheckBox
            tlOffice.OptionsBehavior.AllowIndeterminateCheckState = false;//true; //设置节点是否有中间状态，即一部分子节点选中，一部分子节点没有选中
            tlOffice.OptionsBehavior.Editable = false;            
            tlOffice.ExpandAll();//展开子节点
            tlOffice.BestFitColumns();
            //tlOffice.OptionsView.AutoWidth = true;

            //位置
            Point xy = new Point(0, 0);
            tlOffice.Location = xy;
            tlOffice.Width = splitContainerE1.Panel1.Width - 4;
            tlOffice.Height = splitContainerE1.Panel1.Height - 4;

        }

        #region 节点选中后事件
        private void tlOffice_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        #endregion 
 
        #region 设置子节点状态
        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        #endregion 
 
        #region 设置父节点状态
        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                if (b)
                {
                    node.ParentNode.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    node.ParentNode.CheckState = check;
                }
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        #endregion  
       
        #region 获取选中的复选框数据列表
        private List<string> lstCheckedOfficeID = new List<string>();//选择局ID集合
        /// <summary>
        /// 获取选择状态的数据主键ID集合
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        private void GetCheckedOfficeID(TreeListNode parentNode)
        {
            if (parentNode.Nodes.Count == 0)
            {
                return;//递归终止
            }

            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    DataRowView drv = tlOffice.GetDataRecordByNode(node) as DataRowView;//关键代码，就是不知道是这样获取数据而纠结了很久(鬼知道可以转换为DataRowView啊)
                    if (drv != null)
                    {
                        string OfficeID = (string)drv["手机号"];
                        lstCheckedOfficeID.Add(OfficeID);
                    }


                }
                GetCheckedOfficeID(node);
            }
        }       
        #endregion

        #region   更新状态到表dtLamp
        //UPDATE 表名称 SET 列名称 = 新值 WHERE 列名称 = 某值
        private void SQL_DTUpdateField(string table, string FieldName, string content, string telnum)
        {
            lock (lockSqlTableObj)
            {
                OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + "灯盏列表.mdb");
                conn.Open();

                //string sql = "update dtLamp set 通讯=\"逆天状态\"  where 手机号 = \"00013777840014\"";

                string sql = "update " + table + " set " + FieldName + "=\"" + content + "\" where 手机号 =\"" + telnum + "\"";

                OleDbDataAdapter daQ = new OleDbDataAdapter(sql, conn);
                DataTable dtQ = new DataTable();
                daQ.Fill(dtQ);

                conn.Close();
            }
             
        }


        private void SQL_DTInsertField(string table, string[] chinfo, string content, string telnum)
        {
            lock (lockSqlTableObj)
            {
                OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + "灯盏列表.mdb");
                conn.Open();

                // Persons VALUES ('Gates', 'Bill', 'Xuanwumen 10', 'Beijing')

                string sql = "INSERT INTO "
                    + table
                    + " VALUES ('"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    + "', '"
                    + telnum
                    + "', '"
                    + content
                    + "', '"
                    + chinfo[0]
                    + "', '"
                    + chinfo[1]
                    + "')";

                OleDbDataAdapter daQ = new OleDbDataAdapter(sql, conn);
                DataTable dtQ = new DataTable();
                daQ.Fill(dtQ);

                conn.Close();
            }
            
        }

        private void SQL_DTInsertField(string table, string[] values,  string telnum)
        {
            lock (lockSqlTableObj)
            { 
                OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + "灯盏列表.mdb");
                conn.Open();

                // Persons VALUES ('Gates', 'Bill', 'Xuanwumen 10', 'Beijing')

                string sql = "INSERT INTO " + table + " VALUES ('"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+ "', '" + telnum+ "'";

                for (int i = 0; i < values.Length; i++)
                {
                    sql += ", '" + values[i] + "'";
                }
                sql+=")";

                OleDbDataAdapter daQ = new OleDbDataAdapter(sql, conn);
                DataTable dtQ = new DataTable();
                daQ.Fill(dtQ);

                conn.Close();            
            }
        }


        private void DTUpdateField(DataTable dt , string FieldName, string content, string telnum)
        {
            lock (lockTreeListObj)
            { 
                int col = dt.Columns.IndexOf("手机号");
                //
                //DataRow[] drs = dt.Select("column0 = '李四'");
                DataRow[] drs = dt.Select("手机号 = '" + telnum + "'");
                if (drs.Length > 0)
                {
                    string Name = drs[0][FieldName].ToString();

                    drs[0][FieldName] = content;
                    //<font color=red><%#Eval("字段")%></font>
                    //drs[0][FieldName] = "<font color=red>" + content + "</font>";
                    //MessageBox.Show(Name);
                }            
            }
            try 
            {
                this.Invoke((EventHandler)(delegate
                {
                    //tlOffice.DataSource = dt;
                    tlOffice.Update();
                }));                       
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error");
            }
        }

        private void TreeListUpdateHeartBeat(string telnum, byte rssi)
        {
           
            SQL_DTUpdateField("dtLamp", "通讯", "通", telnum);
            SQL_DTUpdateField("dtLamp", "通讯时间", GetDateNow(), telnum);
            SQL_DTUpdateField("dtLamp", "信号强度", rssi.ToString(), telnum);
            


            DTUpdateField(DT_树形表格, "通讯", "通", telnum);
            DTUpdateField(DT_树形表格, "通讯时间", GetDateNow(), telnum);
            DTUpdateField(DT_树形表格, "信号强度", rssi.ToString(), telnum);


        }
        private void TreeListUpdateDevicDisconnected(string telnum)
        {
            SQL_DTUpdateField("dtLamp", "通讯", "断", telnum);
            DTUpdateField(DT_树形表格, "通讯", "断", telnum);
        }
        private void TreeListUpdatePointCopy(string telnum ,string[] chinfo, string rtcinfo)
        {
            for (int i = 0; i < 2; i++)
            {
                string field = "火" + (i+1).ToString() + "状态";
                DTUpdateField(DT_树形表格, field, chinfo[i], telnum);
            }
            DTUpdateField(DT_树形表格, "设备RTC", rtcinfo, telnum);
            DTUpdateField(DT_树形表格, "通讯时间", GetDateNow(), telnum);

            string[] vaules = new string[3];
            vaules[0] = rtcinfo;
            vaules[1] = chinfo[0];
            vaules[2] = chinfo[1];
            SQL_DTInsertField("record", vaules, telnum);
        }
        #endregion

        private void TreeListCheckedList(string title)
        {
            this.lstCheckedOfficeID.Clear();

            if (tlOffice.Nodes.Count > 0)
            {
                foreach (TreeListNode root in tlOffice.Nodes)
                {
                    GetCheckedOfficeID(root);
                }
            }

            string idStr = string.Empty;
            foreach (string id in lstCheckedOfficeID)
            {
                idStr += id + "\r\n";
            }
            MessageBox.Show(idStr, title);        
        }

        private void btn_开始清查_Click(object sender, EventArgs e)
        {
            TreeListCheckedList("选中的设备手机号");
        }
        
        private void EventInsert(string telnum, byte erc, string content)
        {
            string[] values = new string[2];
            values[0]= erc.ToString();
            values[1]= content;

            SQL_DTInsertField("event", values, telnum);
        }


        private void btn_界面切换_Click(object sender, EventArgs e)
        {
            if (tlOffice.Visible == true)
            {
                tlOffice.Visible = false;
                tabControl_Console.Visible = true;
            }
            else
            {
                tlOffice.Visible = true;
                tabControl_Console.Visible = false;                
            }
        }

        #region 线程
        /// <summary>
        /// 手机号码对应通讯时间与当前时间对比 ，大于5分钟，短线！
        /// </summary>
        private void Thread_设备连接更新()
        {          
            while (true)
            {
                #if false
                //根节点
                foreach (TreeListNode root in tlOffice.Nodes)
                {                
                    //从节点
                    foreach (TreeListNode node in root.Nodes)
                    {
                        //关键代码，就是不知道是这样获取数据而纠结了很久(鬼知道可以转换为DataRowView啊)
                        DataRowView drv = tlOffice.GetDataRecordByNode(node) as DataRowView;
                        if (drv != null)
                        {
                            DateTime vTime = DateTime.MinValue;
                        
                            if (drv["通讯时间"] != System.DBNull.Value)
                            { 
                                string dtime = (string)drv["通讯时间"];
                                vTime = Convert.ToDateTime(dtime);
                            }

                            TimeSpan span  = DateTime.Now - vTime;
                            if (span.TotalSeconds > 5 * 60)
                            {
                                TreeListUpdateDevicDisconnected((string)drv["手机号"]);
                            }
                        }
                    }
                #else
                //根节点
                for (int rootIndex = 0; rootIndex < tlOffice.Nodes.Count; rootIndex++)
                {
                    TreeListNode root = tlOffice.Nodes[rootIndex];

                    //从节点
                    for (int nodeIndex = 0; nodeIndex < root.Nodes.Count; nodeIndex++)
                    {
                        TreeListNode node = root.Nodes[nodeIndex];
                            
                        //关键代码，就是不知道是这样获取数据而纠结了很久(鬼知道可以转换为DataRowView啊)
                        DataRowView drv = tlOffice.GetDataRecordByNode(node) as DataRowView;
                        if (drv != null)
                        {
                            DateTime vTime = DateTime.MinValue;

                            if (drv["通讯时间"] != System.DBNull.Value)
                            {
                                string dtime = (string)drv["通讯时间"];
                                vTime = Convert.ToDateTime(dtime);
                            }

                            TimeSpan span = DateTime.Now - vTime;
                            if (span.TotalSeconds > 5 * 60)
                            {
                                TreeListUpdateDevicDisconnected((string)drv["手机号"]);
                            }
                        }
                    }

                }
                #endif
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Treelist 在线的（通），手机号码 检索出endpoint， 然后进行PointCopy
        /// </summary>
        private void Thread_批量定时招测()
        { 
            int oldHour =-1;
             
            while (true)
            {
                if (oldHour != DateTime.Now.Hour)
                {
                    oldHour = DateTime.Now.Hour;
                    
                    this.Invoke((EventHandler)(delegate
                    {
                        //非调式界面模式下进行;
                        if (tlOffice.Visible == true)
                        {                        
                            for (int index = 0; index < cbClient.Items.Count; index++)
                            {
                                cbClient.SelectedIndex = index;

                                string endpoint = cbClient.Text;
                                txtMsg.AppendText("批量招测" + endpoint);
                
                                PointCopyStatus(endpoint);
                            }                        
                        }
                    }));
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        private void btn_重新加载_Click(object sender, EventArgs e)
        {
            //InitTreeList();
            //UpdataTreeList(checkBox5.Checked, treeDebug_手机号码.Text,0);

            //tlOffice.Update();

            // DTUpdateField(DT_树形表格, "通讯时间", GetDateNow(), treeDebug_手机号码.Text);

            /*
            foreach (var endpoint in cbClient.Items)
            {

                cbClient.SelectedIndex = 0;
                
                MessageBox.Show(endpoint.ToString());
            }
             */


            /*
            1、如果comboBox里的值是你自己手动加进去的，就用comboBox1.selectedItem
            2、如果comboBox里的值是从数据库里接收的，就用comboBox1.Text
            3、如果是取comboBox里的隐藏值，就用comboBox1.selectedValue              
             */
            /*
            for (int index = 0; index < comboBox1.Items.Count; index++)
            {
                comboBox1.SelectedIndex = index;

                string endpoint;

                //endpoint = comboBox1.SelectedItem.ToString();
                //MessageBox.Show(endpoint);

                endpoint = (string)comboBox1.SelectedValue;
                //MessageBox.Show(endpoint);

                //endpoint = (string)comboBox1.Text;
                MessageBox.Show(endpoint);

            }
            */

            //SQL_DTInsertField("record", "", "111", "13777922001");
            string telnum = "00013777840014";

            UInt16 eventcount = 1;
            PraseEvent.EventClass[] eventrecord = new PraseEvent.EventClass[eventcount];

            eventrecord[0].erc = 101;
            byte[] numbers = new byte[5]{0x00, 0x11, 0x22, 0x33,0x44};

            eventrecord[0].content = numbers;

            //
            for (int i = 0; i < eventcount; i++)
            {
                EventInsert(telnum, eventrecord[i].erc, Hex.ToString(eventrecord[i].content));
            }

        }

        private void tlOffice_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            //定时刷新通讯字体颜色
            if (e.Column == tlOffice.Columns["通讯"])
            {
                if (e.CellValue.ToString() == "断")
                {
                    //e.Appearance.BackColor = Color.Red;
                    //e.Appearance.Options.UseBackColor = true;

                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.Options.UseForeColor = true;
                }
                else 
                {
                    e.Appearance.ForeColor = Color.Green;
                    e.Appearance.Options.UseForeColor = true;                
                }
            }

        }


    }
}
