using SplitContainerEx;
namespace ServerBySocket
{
    partial class ServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.工具条_COM_状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.工具条_RTC_状态 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.tlOffice = new DevExpress.XtraTreeList.TreeList();
            this.tsddbtnOption = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripConnectionSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripEcxStatusRead = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripEcxTimeSyn = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripEcxLampControl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbtnTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.转换工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算CRCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bH1750透光率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnQuickConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.cbSerial = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.button侦听 = new System.Windows.Forms.ToolStripButton();
            this.button停止 = new System.Windows.Forms.ToolStripButton();
            this.comboBoxIP = new System.Windows.Forms.ToolStripComboBox();
            this.TxtPort = new System.Windows.Forms.ToolStripTextBox();
            this.cbClient = new System.Windows.Forms.ToolStripComboBox();
            this.btn_界面切换 = new System.Windows.Forms.ToolStripButton();
            this.splitContainerE1 = new SplitContainerEx.SplitContainerE();
            this.tabControl_Console = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dGV_esxStatus = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelFailpercent = new System.Windows.Forms.Label();
            this.labelOKpercent = new System.Windows.Forms.Label();
            this.labelTotalCnt = new System.Windows.Forms.Label();
            this.labelFailCnt = new System.Windows.Forms.Label();
            this.labelOKcnt = new System.Windows.Forms.Label();
            this.chk_定时读取 = new System.Windows.Forms.CheckBox();
            this.QueryIntervalTime = new System.Windows.Forms.NumericUpDown();
            this.btn_状态招测 = new System.Windows.Forms.Button();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_OK = new System.Windows.Forms.Label();
            this.label_Fail = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EsxUserCtrlGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_单灯遥控 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label控制灯盏数 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_查询参数 = new System.Windows.Forms.Button();
            this.btn_设置参数 = new System.Windows.Forms.Button();
            this.tabControl_cfg = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.设备地址Txt = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.安装位置Txt = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.版本号Txt = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.设备序列号txt = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.EsxNetGrid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.EsxTimeCtrlGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.TimingCtlAbsolute = new System.Windows.Forms.RadioButton();
            this.TimingCtlRelative = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.TimingCtlEnable = new System.Windows.Forms.RadioButton();
            this.TimingCtlDissable = new System.Windows.Forms.RadioButton();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.startDtp = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ValidNumupdowm = new System.Windows.Forms.NumericUpDown();
            this.OffLightDtp = new System.Windows.Forms.DateTimePicker();
            this.OnLightDtp = new System.Windows.Forms.DateTimePicker();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.DGV_JWD = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.JWD_DAYS = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.JWD_S_DAY = new System.Windows.Forms.NumericUpDown();
            this.JWD_S_MONTH = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label_文件大小 = new System.Windows.Forms.Label();
            this.label_版本号 = new System.Windows.Forms.Label();
            this.Btn_固件升级 = new System.Windows.Forms.Button();
            this.DevModelTxt = new System.Windows.Forms.TextBox();
            this.textBinFileSize = new System.Windows.Forms.TextBox();
            this.textBinVerNO = new System.Windows.Forms.TextBox();
            this.BinPathTxt = new System.Windows.Forms.TextBox();
            this.textTryCnt = new System.Windows.Forms.TextBox();
            this.textTryTimeout = new System.Windows.Forms.TextBox();
            this.label_终端型号 = new System.Windows.Forms.Label();
            this.剩余时间label = new System.Windows.Forms.Label();
            this.固件升级进度条 = new System.Windows.Forms.ProgressBar();
            this.FirmwarePackedSizeCmb = new System.Windows.Forms.ComboBox();
            this.label_数据包大小 = new System.Windows.Forms.Label();
            this.label_重试次数 = new System.Windows.Forms.Label();
            this.btn_浏览BIN文件 = new System.Windows.Forms.Button();
            this.label_超时时间 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_重新加载 = new System.Windows.Forms.Button();
            this.btn_时钟查询 = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox设备操作 = new System.Windows.Forms.GroupBox();
            this.Btn_TerCtl = new System.Windows.Forms.Button();
            this.RB_从节点单灯复位 = new System.Windows.Forms.RadioButton();
            this.RB_主节点单灯复位 = new System.Windows.Forms.RadioButton();
            this.RB_集中器复位 = new System.Windows.Forms.RadioButton();
            this.btn_时钟设置 = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btn_数据发送 = new System.Windows.Forms.Button();
            this.Chk_Format十六进制 = new System.Windows.Forms.CheckBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_协议解析 = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlOffice)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerE1)).BeginInit();
            this.splitContainerE1.Panel1.SuspendLayout();
            this.splitContainerE1.Panel2.SuspendLayout();
            this.splitContainerE1.SuspendLayout();
            this.tabControl_Console.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_esxStatus)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueryIntervalTime)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxUserCtrlGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl_cfg.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxNetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxTimeCtrlGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidNumupdowm)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_JWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_DAYS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_S_DAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_S_MONTH)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox设备操作.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具条_COM_状态,
            this.工具条_RTC_状态});
            this.statusStrip.Location = new System.Drawing.Point(0, 680);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1095, 26);
            this.statusStrip.TabIndex = 61;
            this.statusStrip.Text = "底部状态栏";
            // 
            // 工具条_COM_状态
            // 
            this.工具条_COM_状态.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.工具条_COM_状态.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.工具条_COM_状态.Name = "工具条_COM_状态";
            this.工具条_COM_状态.Size = new System.Drawing.Size(50, 21);
            this.工具条_COM_状态.Text = "CLOSE";
            this.工具条_COM_状态.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // 工具条_RTC_状态
            // 
            this.工具条_RTC_状态.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.工具条_RTC_状态.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.工具条_RTC_状态.Name = "工具条_RTC_状态";
            this.工具条_RTC_状态.Size = new System.Drawing.Size(1030, 21);
            this.工具条_RTC_状态.Spring = true;
            this.工具条_RTC_状态.Text = "系统时间:";
            this.工具条_RTC_状态.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsg.Location = new System.Drawing.Point(3, 3);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtMsg.Size = new System.Drawing.Size(1067, 271);
            this.txtMsg.TabIndex = 62;
            this.txtMsg.Text = "";
            // 
            // tlOffice
            // 
            this.tlOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlOffice.Location = new System.Drawing.Point(10, 3);
            this.tlOffice.Name = "tlOffice";
            this.tlOffice.OptionsBehavior.Editable = false;
            this.tlOffice.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlOffice.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlOffice.Size = new System.Drawing.Size(1060, 21);
            this.tlOffice.TabIndex = 60;
            this.tlOffice.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlOffice_AfterCheckNode);
            this.tlOffice.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tlOffice_CustomDrawNodeCell);
            // 
            // tsddbtnOption
            // 
            this.tsddbtnOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripConnectionSetup,
            this.ToolStripEcxStatusRead,
            this.ToolStripEcxTimeSyn,
            this.ToolStripEcxLampControl});
            this.tsddbtnOption.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsddbtnOption.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtnOption.Image")));
            this.tsddbtnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsddbtnOption.ImageTransparentColor = System.Drawing.Color.White;
            this.tsddbtnOption.Name = "tsddbtnOption";
            this.tsddbtnOption.Size = new System.Drawing.Size(115, 50);
            this.tsddbtnOption.Text = "Option Set";
            // 
            // ToolStripConnectionSetup
            // 
            this.ToolStripConnectionSetup.Name = "ToolStripConnectionSetup";
            this.ToolStripConnectionSetup.Size = new System.Drawing.Size(178, 22);
            this.ToolStripConnectionSetup.Text = "Connection Setup";
            this.ToolStripConnectionSetup.Click += new System.EventHandler(this.ToolStripConnectionSetup_Click);
            // 
            // ToolStripEcxStatusRead
            // 
            this.ToolStripEcxStatusRead.Name = "ToolStripEcxStatusRead";
            this.ToolStripEcxStatusRead.Size = new System.Drawing.Size(178, 22);
            this.ToolStripEcxStatusRead.Text = "EcxStatus Read ";
            this.ToolStripEcxStatusRead.Click += new System.EventHandler(this.ToolStripEcxStatusRead_Click);
            // 
            // ToolStripEcxTimeSyn
            // 
            this.ToolStripEcxTimeSyn.Name = "ToolStripEcxTimeSyn";
            this.ToolStripEcxTimeSyn.Size = new System.Drawing.Size(178, 22);
            this.ToolStripEcxTimeSyn.Text = "EcxTime Syn";
            this.ToolStripEcxTimeSyn.Click += new System.EventHandler(this.ToolStripEcxTimeSyn_Click);
            // 
            // ToolStripEcxLampControl
            // 
            this.ToolStripEcxLampControl.Name = "ToolStripEcxLampControl";
            this.ToolStripEcxLampControl.Size = new System.Drawing.Size(178, 22);
            this.ToolStripEcxLampControl.Text = "EcxLamp Control";
            this.ToolStripEcxLampControl.Click += new System.EventHandler(this.ToolStripEcxLampControl_Click);
            // 
            // tsddbtnTool
            // 
            this.tsddbtnTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.转换工具ToolStripMenuItem,
            this.计算CRCToolStripMenuItem,
            this.计算器ToolStripMenuItem,
            this.bH1750透光率ToolStripMenuItem});
            this.tsddbtnTool.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtnTool.Image")));
            this.tsddbtnTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsddbtnTool.Name = "tsddbtnTool";
            this.tsddbtnTool.RightToLeftAutoMirrorImage = true;
            this.tsddbtnTool.Size = new System.Drawing.Size(107, 50);
            this.tsddbtnTool.Text = "Calc Tool";
            this.tsddbtnTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 转换工具ToolStripMenuItem
            // 
            this.转换工具ToolStripMenuItem.Name = "转换工具ToolStripMenuItem";
            this.转换工具ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.转换工具ToolStripMenuItem.Text = "转换工具";
            this.转换工具ToolStripMenuItem.Click += new System.EventHandler(this.转换工具ToolStripMenuItem_Click);
            // 
            // 计算CRCToolStripMenuItem
            // 
            this.计算CRCToolStripMenuItem.Name = "计算CRCToolStripMenuItem";
            this.计算CRCToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.计算CRCToolStripMenuItem.Text = "计算CRC";
            this.计算CRCToolStripMenuItem.Click += new System.EventHandler(this.计算CRCToolStripMenuItem_Click);
            // 
            // 计算器ToolStripMenuItem
            // 
            this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
            this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.计算器ToolStripMenuItem.Text = "计算器";
            this.计算器ToolStripMenuItem.Click += new System.EventHandler(this.计算器ToolStripMenuItem_Click_1);
            // 
            // bH1750透光率ToolStripMenuItem
            // 
            this.bH1750透光率ToolStripMenuItem.Name = "bH1750透光率ToolStripMenuItem";
            this.bH1750透光率ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.bH1750透光率ToolStripMenuItem.Text = "计算BH1750透光率";
            this.bH1750透光率ToolStripMenuItem.Click += new System.EventHandler(this.bH1750透光率ToolStripMenuItem_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 50);
            this.toolStripLabel2.Text = "open port";
            // 
            // tsbtnQuickConnect
            // 
            this.tsbtnQuickConnect.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnQuickConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnQuickConnect.Image")));
            this.tsbtnQuickConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnQuickConnect.Name = "tsbtnQuickConnect";
            this.tsbtnQuickConnect.Size = new System.Drawing.Size(128, 50);
            this.tsbtnQuickConnect.Text = "Quick Connect";
            this.tsbtnQuickConnect.Click += new System.EventHandler(this.btnQuickConnect_Click);
            // 
            // tsbtnDisconnect
            // 
            this.tsbtnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDisconnect.Image")));
            this.tsbtnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisconnect.Name = "tsbtnDisconnect";
            this.tsbtnDisconnect.Size = new System.Drawing.Size(107, 50);
            this.tsbtnDisconnect.Text = "Disconnect";
            this.tsbtnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(101, 53);
            this.cbSerial.DropDown += new System.EventHandler(this.cbSerial_DropDown);
            this.cbSerial.SelectedIndexChanged += new System.EventHandler(this.cbSerial_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbtnOption,
            this.tsddbtnTool,
            this.toolStripLabel2,
            this.tsbtnQuickConnect,
            this.tsbtnDisconnect,
            this.cbSerial,
            this.toolStripSeparator1,
            this.button侦听,
            this.button停止,
            this.comboBoxIP,
            this.TxtPort,
            this.cbClient,
            this.btn_界面切换});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1095, 53);
            this.toolStrip.TabIndex = 60;
            this.toolStrip.Text = "顶部工具条";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // button侦听
            // 
            this.button侦听.Image = ((System.Drawing.Image)(resources.GetObject("button侦听.Image")));
            this.button侦听.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button侦听.Name = "button侦听";
            this.button侦听.Size = new System.Drawing.Size(77, 50);
            this.button侦听.Text = "Listen";
            this.button侦听.Click += new System.EventHandler(this.btnSocketStartListen_Click);
            // 
            // button停止
            // 
            this.button停止.Image = ((System.Drawing.Image)(resources.GetObject("button停止.Image")));
            this.button停止.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button停止.Name = "button停止";
            this.button停止.Size = new System.Drawing.Size(71, 50);
            this.button停止.Text = "Stop";
            this.button停止.Click += new System.EventHandler(this.btnSocketStopListen_Click);
            // 
            // comboBoxIP
            // 
            this.comboBoxIP.Name = "comboBoxIP";
            this.comboBoxIP.Size = new System.Drawing.Size(121, 53);
            // 
            // TxtPort
            // 
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(50, 53);
            this.TxtPort.Text = "6802";
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(150, 53);
            // 
            // btn_界面切换
            // 
            this.btn_界面切换.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_界面切换.Image = ((System.Drawing.Image)(resources.GetObject("btn_界面切换.Image")));
            this.btn_界面切换.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_界面切换.Name = "btn_界面切换";
            this.btn_界面切换.Size = new System.Drawing.Size(36, 50);
            this.btn_界面切换.Text = "界面切换";
            this.btn_界面切换.Click += new System.EventHandler(this.btn_界面切换_Click);
            // 
            // splitContainerE1
            // 
            this.splitContainerE1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerE1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerE1.Location = new System.Drawing.Point(12, 56);
            this.splitContainerE1.Name = "splitContainerE1";
            this.splitContainerE1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerE1.Panel1
            // 
            this.splitContainerE1.Panel1.Controls.Add(this.tlOffice);
            this.splitContainerE1.Panel1.Controls.Add(this.tabControl_Console);
            this.splitContainerE1.Panel1MinSize = 0;
            // 
            // splitContainerE1.Panel2
            // 
            this.splitContainerE1.Panel2.Controls.Add(this.txtMsg);
            this.splitContainerE1.Panel2MinSize = 0;
            this.splitContainerE1.Size = new System.Drawing.Size(1074, 619);
            this.splitContainerE1.SplitterDistance = 322;
            this.splitContainerE1.SplitterWidth = 9;
            this.splitContainerE1.TabIndex = 63;
            // 
            // tabControl_Console
            // 
            this.tabControl_Console.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_Console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Console.Controls.Add(this.tabPage6);
            this.tabControl_Console.Controls.Add(this.tabPage3);
            this.tabControl_Console.Controls.Add(this.tabPage2);
            this.tabControl_Console.Controls.Add(this.tabPage4);
            this.tabControl_Console.Controls.Add(this.tabPage5);
            this.tabControl_Console.Controls.Add(this.tabPage12);
            this.tabControl_Console.Location = new System.Drawing.Point(7, 30);
            this.tabControl_Console.Name = "tabControl_Console";
            this.tabControl_Console.SelectedIndex = 0;
            this.tabControl_Console.Size = new System.Drawing.Size(1067, 278);
            this.tabControl_Console.TabIndex = 69;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dGV_esxStatus);
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1059, 252);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "状态查询";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dGV_esxStatus
            // 
            this.dGV_esxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_esxStatus.BackgroundColor = System.Drawing.Color.White;
            this.dGV_esxStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_esxStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_esxStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_esxStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_esxStatus.Location = new System.Drawing.Point(0, 12);
            this.dGV_esxStatus.Name = "dGV_esxStatus";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_esxStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_esxStatus.RowTemplate.Height = 23;
            this.dGV_esxStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dGV_esxStatus.Size = new System.Drawing.Size(833, 237);
            this.dGV_esxStatus.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelFailpercent);
            this.groupBox1.Controls.Add(this.labelOKpercent);
            this.groupBox1.Controls.Add(this.labelTotalCnt);
            this.groupBox1.Controls.Add(this.labelFailCnt);
            this.groupBox1.Controls.Add(this.labelOKcnt);
            this.groupBox1.Controls.Add(this.chk_定时读取);
            this.groupBox1.Controls.Add(this.QueryIntervalTime);
            this.groupBox1.Controls.Add(this.btn_状态招测);
            this.groupBox1.Controls.Add(this.label_Total);
            this.groupBox1.Controls.Add(this.label_OK);
            this.groupBox1.Controls.Add(this.label_Fail);
            this.groupBox1.Location = new System.Drawing.Point(853, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 229);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "招测";
            // 
            // labelFailpercent
            // 
            this.labelFailpercent.AutoSize = true;
            this.labelFailpercent.Location = new System.Drawing.Point(99, 114);
            this.labelFailpercent.Name = "labelFailpercent";
            this.labelFailpercent.Size = new System.Drawing.Size(23, 12);
            this.labelFailpercent.TabIndex = 29;
            this.labelFailpercent.Text = "0 %";
            // 
            // labelOKpercent
            // 
            this.labelOKpercent.AutoSize = true;
            this.labelOKpercent.Location = new System.Drawing.Point(99, 86);
            this.labelOKpercent.Name = "labelOKpercent";
            this.labelOKpercent.Size = new System.Drawing.Size(23, 12);
            this.labelOKpercent.TabIndex = 28;
            this.labelOKpercent.Text = "0 %";
            // 
            // labelTotalCnt
            // 
            this.labelTotalCnt.AutoSize = true;
            this.labelTotalCnt.Location = new System.Drawing.Point(55, 143);
            this.labelTotalCnt.Name = "labelTotalCnt";
            this.labelTotalCnt.Size = new System.Drawing.Size(11, 12);
            this.labelTotalCnt.TabIndex = 27;
            this.labelTotalCnt.Text = "0";
            // 
            // labelFailCnt
            // 
            this.labelFailCnt.AutoSize = true;
            this.labelFailCnt.Location = new System.Drawing.Point(55, 114);
            this.labelFailCnt.Name = "labelFailCnt";
            this.labelFailCnt.Size = new System.Drawing.Size(11, 12);
            this.labelFailCnt.TabIndex = 26;
            this.labelFailCnt.Text = "0";
            // 
            // labelOKcnt
            // 
            this.labelOKcnt.AutoSize = true;
            this.labelOKcnt.Location = new System.Drawing.Point(55, 86);
            this.labelOKcnt.Name = "labelOKcnt";
            this.labelOKcnt.Size = new System.Drawing.Size(11, 12);
            this.labelOKcnt.TabIndex = 25;
            this.labelOKcnt.Text = "0";
            // 
            // chk_定时读取
            // 
            this.chk_定时读取.AutoSize = true;
            this.chk_定时读取.Location = new System.Drawing.Point(6, 39);
            this.chk_定时读取.Name = "chk_定时读取";
            this.chk_定时读取.Size = new System.Drawing.Size(84, 16);
            this.chk_定时读取.TabIndex = 1;
            this.chk_定时读取.Text = "查询间隔ms";
            this.chk_定时读取.UseVisualStyleBackColor = true;
            this.chk_定时读取.CheckedChanged += new System.EventHandler(this.chk_定时读取_CheckedChanged);
            // 
            // QueryIntervalTime
            // 
            this.QueryIntervalTime.Location = new System.Drawing.Point(90, 38);
            this.QueryIntervalTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.QueryIntervalTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.QueryIntervalTime.Name = "QueryIntervalTime";
            this.QueryIntervalTime.Size = new System.Drawing.Size(58, 21);
            this.QueryIntervalTime.TabIndex = 24;
            this.QueryIntervalTime.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // btn_状态招测
            // 
            this.btn_状态招测.Location = new System.Drawing.Point(57, 201);
            this.btn_状态招测.Name = "btn_状态招测";
            this.btn_状态招测.Size = new System.Drawing.Size(73, 22);
            this.btn_状态招测.TabIndex = 2;
            this.btn_状态招测.Text = "招测";
            this.btn_状态招测.UseVisualStyleBackColor = true;
            this.btn_状态招测.Click += new System.EventHandler(this.btn_状态招测_Click);
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Location = new System.Drawing.Point(13, 143);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(41, 12);
            this.label_Total.TabIndex = 5;
            this.label_Total.Text = "Total:";
            // 
            // label_OK
            // 
            this.label_OK.AutoSize = true;
            this.label_OK.Location = new System.Drawing.Point(13, 86);
            this.label_OK.Name = "label_OK";
            this.label_OK.Size = new System.Drawing.Size(23, 12);
            this.label_OK.TabIndex = 3;
            this.label_OK.Text = "OK:";
            // 
            // label_Fail
            // 
            this.label_Fail.AutoSize = true;
            this.label_Fail.Location = new System.Drawing.Point(14, 114);
            this.label_Fail.Name = "label_Fail";
            this.label_Fail.Size = new System.Drawing.Size(35, 12);
            this.label_Fail.TabIndex = 4;
            this.label_Fail.Text = "Fail:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1059, 252);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "控制";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.EsxUserCtrlGrid);
            this.panel1.Controls.Add(this.btn_单灯遥控);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label控制灯盏数);
            this.panel1.Location = new System.Drawing.Point(14, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 226);
            this.panel1.TabIndex = 4;
            // 
            // EsxUserCtrlGrid
            // 
            this.EsxUserCtrlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EsxUserCtrlGrid.Location = new System.Drawing.Point(5, 56);
            this.EsxUserCtrlGrid.MainView = this.gridView1;
            this.EsxUserCtrlGrid.Name = "EsxUserCtrlGrid";
            this.EsxUserCtrlGrid.Size = new System.Drawing.Size(1011, 144);
            this.EsxUserCtrlGrid.TabIndex = 3;
            this.EsxUserCtrlGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView4});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.EsxUserCtrlGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.EsxUserCtrlGrid;
            this.gridView4.Name = "gridView4";
            // 
            // btn_单灯遥控
            // 
            this.btn_单灯遥控.Location = new System.Drawing.Point(180, 19);
            this.btn_单灯遥控.Name = "btn_单灯遥控";
            this.btn_单灯遥控.Size = new System.Drawing.Size(124, 22);
            this.btn_单灯遥控.TabIndex = 2;
            this.btn_单灯遥控.Text = "单灯遥控";
            this.btn_单灯遥控.UseVisualStyleBackColor = true;
            this.btn_单灯遥控.Click += new System.EventHandler(this.btn_单灯遥控_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(77, 20);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown控制灯盏数_ValueChanged);
            // 
            // label控制灯盏数
            // 
            this.label控制灯盏数.AutoSize = true;
            this.label控制灯盏数.Location = new System.Drawing.Point(3, 24);
            this.label控制灯盏数.Name = "label控制灯盏数";
            this.label控制灯盏数.Size = new System.Drawing.Size(65, 12);
            this.label控制灯盏数.TabIndex = 0;
            this.label控制灯盏数.Text = "控制灯盏数";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_查询参数);
            this.tabPage2.Controls.Add(this.btn_设置参数);
            this.tabPage2.Controls.Add(this.tabControl_cfg);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1059, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_查询参数
            // 
            this.btn_查询参数.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_查询参数.Location = new System.Drawing.Point(804, 138);
            this.btn_查询参数.Name = "btn_查询参数";
            this.btn_查询参数.Size = new System.Drawing.Size(61, 26);
            this.btn_查询参数.TabIndex = 2;
            this.btn_查询参数.Text = "查询";
            this.btn_查询参数.UseVisualStyleBackColor = true;
            this.btn_查询参数.Click += new System.EventHandler(this.btn_查询参数_Click);
            // 
            // btn_设置参数
            // 
            this.btn_设置参数.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_设置参数.Location = new System.Drawing.Point(804, 25);
            this.btn_设置参数.Name = "btn_设置参数";
            this.btn_设置参数.Size = new System.Drawing.Size(61, 26);
            this.btn_设置参数.TabIndex = 1;
            this.btn_设置参数.Text = "设置";
            this.btn_设置参数.UseVisualStyleBackColor = true;
            this.btn_设置参数.Click += new System.EventHandler(this.btn_设置参数_Click);
            // 
            // tabControl_cfg
            // 
            this.tabControl_cfg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_cfg.Controls.Add(this.tabPage7);
            this.tabControl_cfg.Controls.Add(this.tabPage8);
            this.tabControl_cfg.Controls.Add(this.tabPage9);
            this.tabControl_cfg.Controls.Add(this.tabPage10);
            this.tabControl_cfg.Controls.Add(this.tabPage11);
            this.tabControl_cfg.Location = new System.Drawing.Point(6, 6);
            this.tabControl_cfg.Multiline = true;
            this.tabControl_cfg.Name = "tabControl_cfg";
            this.tabControl_cfg.SelectedIndex = 0;
            this.tabControl_cfg.Size = new System.Drawing.Size(766, 240);
            this.tabControl_cfg.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox5);
            this.tabPage7.Controls.Add(this.groupBox4);
            this.tabPage7.Controls.Add(this.groupBox3);
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(758, 214);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "终端参数";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.设备地址Txt);
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Location = new System.Drawing.Point(14, 127);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(625, 33);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "设备地址:";
            // 
            // 设备地址Txt
            // 
            this.设备地址Txt.Location = new System.Drawing.Point(169, 8);
            this.设备地址Txt.Name = "设备地址Txt";
            this.设备地址Txt.Size = new System.Drawing.Size(198, 21);
            this.设备地址Txt.TabIndex = 1;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(4, 11);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.安装位置Txt);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Location = new System.Drawing.Point(14, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(625, 33);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "终端安装位置:";
            // 
            // 安装位置Txt
            // 
            this.安装位置Txt.Location = new System.Drawing.Point(169, 10);
            this.安装位置Txt.Name = "安装位置Txt";
            this.安装位置Txt.Size = new System.Drawing.Size(198, 21);
            this.安装位置Txt.TabIndex = 1;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(4, 11);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.版本号Txt);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(14, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 31);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "版本号:";
            // 
            // 版本号Txt
            // 
            this.版本号Txt.Location = new System.Drawing.Point(169, 10);
            this.版本号Txt.Name = "版本号Txt";
            this.版本号Txt.ReadOnly = true;
            this.版本号Txt.Size = new System.Drawing.Size(198, 21);
            this.版本号Txt.TabIndex = 1;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(4, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.设备序列号txt);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(14, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 32);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "设备序列号(6 BCD):";
            // 
            // 设备序列号txt
            // 
            this.设备序列号txt.Location = new System.Drawing.Point(169, 8);
            this.设备序列号txt.Name = "设备序列号txt";
            this.设备序列号txt.ReadOnly = true;
            this.设备序列号txt.Size = new System.Drawing.Size(198, 21);
            this.设备序列号txt.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(4, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.EsxNetGrid);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(758, 214);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "网络参数";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // EsxNetGrid
            // 
            this.EsxNetGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EsxNetGrid.Location = new System.Drawing.Point(3, 3);
            this.EsxNetGrid.MainView = this.gv;
            this.EsxNetGrid.Name = "EsxNetGrid";
            this.EsxNetGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.EsxNetGrid.Size = new System.Drawing.Size(623, 208);
            this.EsxNetGrid.TabIndex = 4;
            this.EsxNetGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gridView3});
            // 
            // gv
            // 
            this.gv.GridControl = this.EsxNetGrid;
            this.gv.Name = "gv";
            this.gv.OptionsSelection.MultiSelect = true;
            this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.EsxNetGrid;
            this.gridView3.Name = "gridView3";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.EsxTimeCtrlGrid);
            this.tabPage9.Controls.Add(this.groupBox10);
            this.tabPage9.Controls.Add(this.groupBox9);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(758, 214);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "节能策略";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // EsxTimeCtrlGrid
            // 
            this.EsxTimeCtrlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EsxTimeCtrlGrid.Location = new System.Drawing.Point(0, 38);
            this.EsxTimeCtrlGrid.MainView = this.gridView2;
            this.EsxTimeCtrlGrid.Name = "EsxTimeCtrlGrid";
            this.EsxTimeCtrlGrid.Size = new System.Drawing.Size(605, 173);
            this.EsxTimeCtrlGrid.TabIndex = 5;
            this.EsxTimeCtrlGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.EsxTimeCtrlGrid;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.TimingCtlAbsolute);
            this.groupBox10.Controls.Add(this.TimingCtlRelative);
            this.groupBox10.Location = new System.Drawing.Point(150, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(183, 36);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            // 
            // TimingCtlAbsolute
            // 
            this.TimingCtlAbsolute.AutoSize = true;
            this.TimingCtlAbsolute.Location = new System.Drawing.Point(106, 13);
            this.TimingCtlAbsolute.Name = "TimingCtlAbsolute";
            this.TimingCtlAbsolute.Size = new System.Drawing.Size(71, 16);
            this.TimingCtlAbsolute.TabIndex = 1;
            this.TimingCtlAbsolute.Text = "绝对时间";
            this.TimingCtlAbsolute.UseVisualStyleBackColor = true;
            // 
            // TimingCtlRelative
            // 
            this.TimingCtlRelative.AutoSize = true;
            this.TimingCtlRelative.Checked = true;
            this.TimingCtlRelative.Location = new System.Drawing.Point(6, 13);
            this.TimingCtlRelative.Name = "TimingCtlRelative";
            this.TimingCtlRelative.Size = new System.Drawing.Size(71, 16);
            this.TimingCtlRelative.TabIndex = 0;
            this.TimingCtlRelative.TabStop = true;
            this.TimingCtlRelative.Text = "相对时间";
            this.TimingCtlRelative.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.TimingCtlEnable);
            this.groupBox9.Controls.Add(this.TimingCtlDissable);
            this.groupBox9.Location = new System.Drawing.Point(3, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(115, 36);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            // 
            // TimingCtlEnable
            // 
            this.TimingCtlEnable.AutoSize = true;
            this.TimingCtlEnable.Checked = true;
            this.TimingCtlEnable.Location = new System.Drawing.Point(59, 13);
            this.TimingCtlEnable.Name = "TimingCtlEnable";
            this.TimingCtlEnable.Size = new System.Drawing.Size(47, 16);
            this.TimingCtlEnable.TabIndex = 1;
            this.TimingCtlEnable.TabStop = true;
            this.TimingCtlEnable.Text = "启用";
            this.TimingCtlEnable.UseVisualStyleBackColor = true;
            // 
            // TimingCtlDissable
            // 
            this.TimingCtlDissable.AutoSize = true;
            this.TimingCtlDissable.Location = new System.Drawing.Point(6, 13);
            this.TimingCtlDissable.Name = "TimingCtlDissable";
            this.TimingCtlDissable.Size = new System.Drawing.Size(47, 16);
            this.TimingCtlDissable.TabIndex = 0;
            this.TimingCtlDissable.Text = "禁用";
            this.TimingCtlDissable.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.label27);
            this.tabPage10.Controls.Add(this.startDtp);
            this.tabPage10.Controls.Add(this.label12);
            this.tabPage10.Controls.Add(this.label10);
            this.tabPage10.Controls.Add(this.label11);
            this.tabPage10.Controls.Add(this.ValidNumupdowm);
            this.tabPage10.Controls.Add(this.OffLightDtp);
            this.tabPage10.Controls.Add(this.OnLightDtp);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(758, 214);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "临时开关灯时间";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 12);
            this.label27.TabIndex = 24;
            this.label27.Text = "执行日期:";
            // 
            // startDtp
            // 
            this.startDtp.CustomFormat = "yyyy-MM-dd";
            this.startDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDtp.Location = new System.Drawing.Point(24, 51);
            this.startDtp.Name = "startDtp";
            this.startDtp.Size = new System.Drawing.Size(193, 21);
            this.startDtp.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "关灯时间:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "有效天数:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "开灯时间:";
            // 
            // ValidNumupdowm
            // 
            this.ValidNumupdowm.Location = new System.Drawing.Point(89, 165);
            this.ValidNumupdowm.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ValidNumupdowm.Name = "ValidNumupdowm";
            this.ValidNumupdowm.Size = new System.Drawing.Size(75, 21);
            this.ValidNumupdowm.TabIndex = 17;
            // 
            // OffLightDtp
            // 
            this.OffLightDtp.CustomFormat = "HH:mm";
            this.OffLightDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.OffLightDtp.Location = new System.Drawing.Point(89, 129);
            this.OffLightDtp.Name = "OffLightDtp";
            this.OffLightDtp.ShowUpDown = true;
            this.OffLightDtp.Size = new System.Drawing.Size(75, 21);
            this.OffLightDtp.TabIndex = 19;
            // 
            // OnLightDtp
            // 
            this.OnLightDtp.CustomFormat = "HH:mm";
            this.OnLightDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.OnLightDtp.Location = new System.Drawing.Point(89, 88);
            this.OnLightDtp.Name = "OnLightDtp";
            this.OnLightDtp.ShowUpDown = true;
            this.OnLightDtp.Size = new System.Drawing.Size(75, 21);
            this.OnLightDtp.TabIndex = 18;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.DGV_JWD);
            this.tabPage11.Controls.Add(this.label49);
            this.tabPage11.Controls.Add(this.label50);
            this.tabPage11.Controls.Add(this.JWD_DAYS);
            this.tabPage11.Controls.Add(this.label51);
            this.tabPage11.Controls.Add(this.JWD_S_DAY);
            this.tabPage11.Controls.Add(this.JWD_S_MONTH);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(758, 214);
            this.tabPage11.TabIndex = 5;
            this.tabPage11.Text = "经纬度开关灯时间";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // DGV_JWD
            // 
            this.DGV_JWD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_JWD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_JWD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_JWD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_JWD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column9,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_JWD.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_JWD.Location = new System.Drawing.Point(9, 41);
            this.DGV_JWD.Name = "DGV_JWD";
            this.DGV_JWD.RowTemplate.Height = 23;
            this.DGV_JWD.Size = new System.Drawing.Size(687, 167);
            this.DGV_JWD.TabIndex = 31;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "开灯_时";
            this.Column6.Name = "Column6";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "开灯_分";
            this.Column9.Name = "Column9";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "关灯_时";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "关灯_分";
            this.Column8.Name = "Column8";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(31, 14);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(47, 12);
            this.label49.TabIndex = 25;
            this.label49.Text = "开始月:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(177, 14);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(47, 12);
            this.label50.TabIndex = 26;
            this.label50.Text = "开始日:";
            // 
            // JWD_DAYS
            // 
            this.JWD_DAYS.Location = new System.Drawing.Point(353, 12);
            this.JWD_DAYS.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.JWD_DAYS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_DAYS.Name = "JWD_DAYS";
            this.JWD_DAYS.Size = new System.Drawing.Size(66, 21);
            this.JWD_DAYS.TabIndex = 30;
            this.JWD_DAYS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_DAYS.ValueChanged += new System.EventHandler(this.JWD_DAYS_ValueChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(312, 14);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(35, 12);
            this.label51.TabIndex = 27;
            this.label51.Text = "天数:";
            // 
            // JWD_S_DAY
            // 
            this.JWD_S_DAY.Location = new System.Drawing.Point(221, 14);
            this.JWD_S_DAY.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.JWD_S_DAY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_S_DAY.Name = "JWD_S_DAY";
            this.JWD_S_DAY.Size = new System.Drawing.Size(66, 21);
            this.JWD_S_DAY.TabIndex = 29;
            this.JWD_S_DAY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_S_DAY.ValueChanged += new System.EventHandler(this.JWD_S_DAY_ValueChanged);
            // 
            // JWD_S_MONTH
            // 
            this.JWD_S_MONTH.Location = new System.Drawing.Point(76, 14);
            this.JWD_S_MONTH.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.JWD_S_MONTH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_S_MONTH.Name = "JWD_S_MONTH";
            this.JWD_S_MONTH.Size = new System.Drawing.Size(66, 21);
            this.JWD_S_MONTH.TabIndex = 28;
            this.JWD_S_MONTH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.JWD_S_MONTH.ValueChanged += new System.EventHandler(this.JWD_S_MONTH_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label_文件大小);
            this.tabPage4.Controls.Add(this.label_版本号);
            this.tabPage4.Controls.Add(this.Btn_固件升级);
            this.tabPage4.Controls.Add(this.DevModelTxt);
            this.tabPage4.Controls.Add(this.textBinFileSize);
            this.tabPage4.Controls.Add(this.textBinVerNO);
            this.tabPage4.Controls.Add(this.BinPathTxt);
            this.tabPage4.Controls.Add(this.textTryCnt);
            this.tabPage4.Controls.Add(this.textTryTimeout);
            this.tabPage4.Controls.Add(this.label_终端型号);
            this.tabPage4.Controls.Add(this.剩余时间label);
            this.tabPage4.Controls.Add(this.固件升级进度条);
            this.tabPage4.Controls.Add(this.FirmwarePackedSizeCmb);
            this.tabPage4.Controls.Add(this.label_数据包大小);
            this.tabPage4.Controls.Add(this.label_重试次数);
            this.tabPage4.Controls.Add(this.btn_浏览BIN文件);
            this.tabPage4.Controls.Add(this.label_超时时间);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1059, 252);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "固件升级";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label_文件大小
            // 
            this.label_文件大小.AutoSize = true;
            this.label_文件大小.Location = new System.Drawing.Point(28, 34);
            this.label_文件大小.Name = "label_文件大小";
            this.label_文件大小.Size = new System.Drawing.Size(53, 12);
            this.label_文件大小.TabIndex = 40;
            this.label_文件大小.Text = "文件大小";
            // 
            // label_版本号
            // 
            this.label_版本号.AutoSize = true;
            this.label_版本号.Location = new System.Drawing.Point(181, 34);
            this.label_版本号.Name = "label_版本号";
            this.label_版本号.Size = new System.Drawing.Size(41, 12);
            this.label_版本号.TabIndex = 41;
            this.label_版本号.Text = "版本号";
            // 
            // Btn_固件升级
            // 
            this.Btn_固件升级.Location = new System.Drawing.Point(534, 149);
            this.Btn_固件升级.Name = "Btn_固件升级";
            this.Btn_固件升级.Size = new System.Drawing.Size(67, 23);
            this.Btn_固件升级.TabIndex = 56;
            this.Btn_固件升级.Text = "开始";
            this.Btn_固件升级.UseVisualStyleBackColor = true;
            this.Btn_固件升级.Click += new System.EventHandler(this.Btn_固件升级_Click);
            // 
            // DevModelTxt
            // 
            this.DevModelTxt.Location = new System.Drawing.Point(381, 34);
            this.DevModelTxt.Name = "DevModelTxt";
            this.DevModelTxt.ReadOnly = true;
            this.DevModelTxt.Size = new System.Drawing.Size(98, 21);
            this.DevModelTxt.TabIndex = 51;
            // 
            // textBinFileSize
            // 
            this.textBinFileSize.Location = new System.Drawing.Point(87, 31);
            this.textBinFileSize.Name = "textBinFileSize";
            this.textBinFileSize.ReadOnly = true;
            this.textBinFileSize.Size = new System.Drawing.Size(62, 21);
            this.textBinFileSize.TabIndex = 42;
            // 
            // textBinVerNO
            // 
            this.textBinVerNO.Location = new System.Drawing.Point(225, 31);
            this.textBinVerNO.Name = "textBinVerNO";
            this.textBinVerNO.ReadOnly = true;
            this.textBinVerNO.Size = new System.Drawing.Size(71, 21);
            this.textBinVerNO.TabIndex = 43;
            // 
            // BinPathTxt
            // 
            this.BinPathTxt.Location = new System.Drawing.Point(123, 149);
            this.BinPathTxt.Name = "BinPathTxt";
            this.BinPathTxt.Size = new System.Drawing.Size(391, 21);
            this.BinPathTxt.TabIndex = 37;
            // 
            // textTryCnt
            // 
            this.textTryCnt.Location = new System.Drawing.Point(240, 83);
            this.textTryCnt.Name = "textTryCnt";
            this.textTryCnt.Size = new System.Drawing.Size(53, 21);
            this.textTryCnt.TabIndex = 49;
            this.textTryCnt.Text = "3";
            // 
            // textTryTimeout
            // 
            this.textTryTimeout.Location = new System.Drawing.Point(87, 83);
            this.textTryTimeout.Name = "textTryTimeout";
            this.textTryTimeout.Size = new System.Drawing.Size(57, 21);
            this.textTryTimeout.TabIndex = 48;
            this.textTryTimeout.Text = "3500";
            // 
            // label_终端型号
            // 
            this.label_终端型号.AutoSize = true;
            this.label_终端型号.Location = new System.Drawing.Point(317, 34);
            this.label_终端型号.Name = "label_终端型号";
            this.label_终端型号.Size = new System.Drawing.Size(53, 12);
            this.label_终端型号.TabIndex = 47;
            this.label_终端型号.Text = "终端型号";
            // 
            // 剩余时间label
            // 
            this.剩余时间label.AutoSize = true;
            this.剩余时间label.Location = new System.Drawing.Point(16, 218);
            this.剩余时间label.Name = "剩余时间label";
            this.剩余时间label.Size = new System.Drawing.Size(65, 12);
            this.剩余时间label.TabIndex = 39;
            this.剩余时间label.Text = "剩余时间: ";
            // 
            // 固件升级进度条
            // 
            this.固件升级进度条.Location = new System.Drawing.Point(18, 205);
            this.固件升级进度条.Name = "固件升级进度条";
            this.固件升级进度条.Size = new System.Drawing.Size(513, 10);
            this.固件升级进度条.TabIndex = 38;
            // 
            // FirmwarePackedSizeCmb
            // 
            this.FirmwarePackedSizeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirmwarePackedSizeCmb.FormattingEnabled = true;
            this.FirmwarePackedSizeCmb.Items.AddRange(new object[] {
            "64",
            "128",
            "256"});
            this.FirmwarePackedSizeCmb.Location = new System.Drawing.Point(394, 82);
            this.FirmwarePackedSizeCmb.Name = "FirmwarePackedSizeCmb";
            this.FirmwarePackedSizeCmb.Size = new System.Drawing.Size(64, 20);
            this.FirmwarePackedSizeCmb.TabIndex = 46;
            // 
            // label_数据包大小
            // 
            this.label_数据包大小.AutoSize = true;
            this.label_数据包大小.Location = new System.Drawing.Point(317, 85);
            this.label_数据包大小.Name = "label_数据包大小";
            this.label_数据包大小.Size = new System.Drawing.Size(65, 12);
            this.label_数据包大小.TabIndex = 50;
            this.label_数据包大小.Text = "数据包大小";
            // 
            // label_重试次数
            // 
            this.label_重试次数.AutoSize = true;
            this.label_重试次数.Location = new System.Drawing.Point(181, 86);
            this.label_重试次数.Name = "label_重试次数";
            this.label_重试次数.Size = new System.Drawing.Size(53, 12);
            this.label_重试次数.TabIndex = 44;
            this.label_重试次数.Text = "重试次数";
            // 
            // btn_浏览BIN文件
            // 
            this.btn_浏览BIN文件.Location = new System.Drawing.Point(33, 149);
            this.btn_浏览BIN文件.Name = "btn_浏览BIN文件";
            this.btn_浏览BIN文件.Size = new System.Drawing.Size(75, 23);
            this.btn_浏览BIN文件.TabIndex = 36;
            this.btn_浏览BIN文件.Text = "浏览";
            this.btn_浏览BIN文件.UseVisualStyleBackColor = true;
            this.btn_浏览BIN文件.Click += new System.EventHandler(this.btn_浏览BIN文件_Click);
            // 
            // label_超时时间
            // 
            this.label_超时时间.AutoSize = true;
            this.label_超时时间.Location = new System.Drawing.Point(28, 86);
            this.label_超时时间.Name = "label_超时时间";
            this.label_超时时间.Size = new System.Drawing.Size(53, 12);
            this.label_超时时间.TabIndex = 45;
            this.label_超时时间.Text = "超时时间";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_重新加载);
            this.tabPage5.Controls.Add(this.btn_时钟查询);
            this.tabPage5.Controls.Add(this.dateTimePicker);
            this.tabPage5.Controls.Add(this.groupBox设备操作);
            this.tabPage5.Controls.Add(this.btn_时钟设置);
            this.tabPage5.Controls.Add(this.txtSend);
            this.tabPage5.Controls.Add(this.btn_数据发送);
            this.tabPage5.Controls.Add(this.Chk_Format十六进制);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1059, 252);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "调式";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_重新加载
            // 
            this.btn_重新加载.Location = new System.Drawing.Point(942, 138);
            this.btn_重新加载.Name = "btn_重新加载";
            this.btn_重新加载.Size = new System.Drawing.Size(70, 24);
            this.btn_重新加载.TabIndex = 70;
            this.btn_重新加载.Text = "debug";
            this.btn_重新加载.UseVisualStyleBackColor = true;
            this.btn_重新加载.Click += new System.EventHandler(this.btn_重新加载_Click);
            // 
            // btn_时钟查询
            // 
            this.btn_时钟查询.Location = new System.Drawing.Point(938, 71);
            this.btn_时钟查询.Name = "btn_时钟查询";
            this.btn_时钟查询.Size = new System.Drawing.Size(70, 21);
            this.btn_时钟查询.TabIndex = 2;
            this.btn_时钟查询.Text = "查询";
            this.btn_时钟查询.UseVisualStyleBackColor = true;
            this.btn_时钟查询.Click += new System.EventHandler(this.btn_时钟查询_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(729, 34);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(150, 21);
            this.dateTimePicker.TabIndex = 28;
            // 
            // groupBox设备操作
            // 
            this.groupBox设备操作.Controls.Add(this.Btn_TerCtl);
            this.groupBox设备操作.Controls.Add(this.RB_从节点单灯复位);
            this.groupBox设备操作.Controls.Add(this.RB_主节点单灯复位);
            this.groupBox设备操作.Controls.Add(this.RB_集中器复位);
            this.groupBox设备操作.Location = new System.Drawing.Point(3, 3);
            this.groupBox设备操作.Name = "groupBox设备操作";
            this.groupBox设备操作.Size = new System.Drawing.Size(400, 137);
            this.groupBox设备操作.TabIndex = 7;
            this.groupBox设备操作.TabStop = false;
            this.groupBox设备操作.Text = "设备操作";
            // 
            // Btn_TerCtl
            // 
            this.Btn_TerCtl.Location = new System.Drawing.Point(313, 29);
            this.Btn_TerCtl.Name = "Btn_TerCtl";
            this.Btn_TerCtl.Size = new System.Drawing.Size(70, 21);
            this.Btn_TerCtl.TabIndex = 6;
            this.Btn_TerCtl.Text = "执行";
            this.Btn_TerCtl.UseVisualStyleBackColor = true;
            this.Btn_TerCtl.Click += new System.EventHandler(this.Btn_TerCtl_Click);
            // 
            // RB_从节点单灯复位
            // 
            this.RB_从节点单灯复位.AutoSize = true;
            this.RB_从节点单灯复位.Location = new System.Drawing.Point(17, 115);
            this.RB_从节点单灯复位.Name = "RB_从节点单灯复位";
            this.RB_从节点单灯复位.Size = new System.Drawing.Size(107, 16);
            this.RB_从节点单灯复位.TabIndex = 5;
            this.RB_从节点单灯复位.Text = "从节点单灯复位";
            this.RB_从节点单灯复位.UseVisualStyleBackColor = true;
            // 
            // RB_主节点单灯复位
            // 
            this.RB_主节点单灯复位.AutoSize = true;
            this.RB_主节点单灯复位.Location = new System.Drawing.Point(17, 70);
            this.RB_主节点单灯复位.Name = "RB_主节点单灯复位";
            this.RB_主节点单灯复位.Size = new System.Drawing.Size(107, 16);
            this.RB_主节点单灯复位.TabIndex = 4;
            this.RB_主节点单灯复位.Text = "主节点单灯复位";
            this.RB_主节点单灯复位.UseVisualStyleBackColor = true;
            // 
            // RB_集中器复位
            // 
            this.RB_集中器复位.AutoSize = true;
            this.RB_集中器复位.Checked = true;
            this.RB_集中器复位.Location = new System.Drawing.Point(17, 29);
            this.RB_集中器复位.Name = "RB_集中器复位";
            this.RB_集中器复位.Size = new System.Drawing.Size(83, 16);
            this.RB_集中器复位.TabIndex = 3;
            this.RB_集中器复位.TabStop = true;
            this.RB_集中器复位.Text = "集中器复位";
            this.RB_集中器复位.UseVisualStyleBackColor = true;
            // 
            // btn_时钟设置
            // 
            this.btn_时钟设置.Location = new System.Drawing.Point(938, 36);
            this.btn_时钟设置.Name = "btn_时钟设置";
            this.btn_时钟设置.Size = new System.Drawing.Size(70, 21);
            this.btn_时钟设置.TabIndex = 1;
            this.btn_时钟设置.Text = "设置";
            this.btn_时钟设置.UseVisualStyleBackColor = true;
            this.btn_时钟设置.Click += new System.EventHandler(this.btn_时钟设置_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(3, 169);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(876, 80);
            this.txtSend.TabIndex = 69;
            // 
            // btn_数据发送
            // 
            this.btn_数据发送.Location = new System.Drawing.Point(942, 216);
            this.btn_数据发送.Name = "btn_数据发送";
            this.btn_数据发送.Size = new System.Drawing.Size(66, 23);
            this.btn_数据发送.TabIndex = 9;
            this.btn_数据发送.Text = "发送";
            this.btn_数据发送.UseVisualStyleBackColor = true;
            this.btn_数据发送.Click += new System.EventHandler(this.btn_数据发送_Click);
            // 
            // Chk_Format十六进制
            // 
            this.Chk_Format十六进制.AutoSize = true;
            this.Chk_Format十六进制.Location = new System.Drawing.Point(864, 218);
            this.Chk_Format十六进制.Name = "Chk_Format十六进制";
            this.Chk_Format十六进制.Size = new System.Drawing.Size(72, 16);
            this.Chk_Format十六进制.TabIndex = 59;
            this.Chk_Format十六进制.Text = "十六进制";
            this.Chk_Format十六进制.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.textBox2);
            this.tabPage12.Controls.Add(this.btn_协议解析);
            this.tabPage12.Location = new System.Drawing.Point(4, 4);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(1059, 252);
            this.tabPage12.TabIndex = 7;
            this.tabPage12.Text = "协议解析";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(31, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(448, 66);
            this.textBox2.TabIndex = 57;
            this.textBox2.Text = "0x7E, 0x03, 0x82, 0x06, 0x00, 0x00, 0x01, 0x33, 0x62, 0x18, 0x23, 0x71, 0x02, 0x0" +
    "0, 0x17, 0x07, 0x11, 0x09, 0x56, 0x56, 0x8C, 0x2D, 0x7E";
            // 
            // btn_协议解析
            // 
            this.btn_协议解析.Location = new System.Drawing.Point(31, 128);
            this.btn_协议解析.Name = "btn_协议解析";
            this.btn_协议解析.Size = new System.Drawing.Size(77, 25);
            this.btn_协议解析.TabIndex = 58;
            this.btn_协议解析.Text = "协议解析";
            this.btn_协议解析.UseVisualStyleBackColor = true;
            this.btn_协议解析.Click += new System.EventHandler(this.btn_协议解析_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1095, 706);
            this.Controls.Add(this.splitContainerE1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "ServerForm";
            this.Text = "JT通讯工具20171121-V1.X[]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlOffice)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerE1.Panel1.ResumeLayout(false);
            this.splitContainerE1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerE1)).EndInit();
            this.splitContainerE1.ResumeLayout(false);
            this.tabControl_Console.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_esxStatus)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueryIntervalTime)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxUserCtrlGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl_cfg.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EsxNetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EsxTimeCtrlGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidNumupdowm)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_JWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_DAYS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_S_DAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JWD_S_MONTH)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox设备操作.ResumeLayout(false);
            this.groupBox设备操作.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel 工具条_RTC_状态;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.ToolStripStatusLabel 工具条_COM_状态;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnOption;
        private System.Windows.Forms.ToolStripMenuItem ToolStripConnectionSetup;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnTool;
        private System.Windows.Forms.ToolStripMenuItem 转换工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算CRCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbtnQuickConnect;
        private System.Windows.Forms.ToolStripButton tsbtnDisconnect;
        private System.Windows.Forms.ToolStripComboBox cbSerial;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem bH1750透光率ToolStripMenuItem;
        private DevExpress.XtraTreeList.TreeList tlOffice;
        private System.Windows.Forms.ToolStripComboBox comboBoxIP;
        private System.Windows.Forms.ToolStripTextBox TxtPort;
        private System.Windows.Forms.ToolStripButton button侦听;
        private System.Windows.Forms.ToolStripButton button停止;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private SplitContainerE splitContainerE1;
        private System.Windows.Forms.GroupBox groupBox设备操作;
        private System.Windows.Forms.Button Btn_TerCtl;
        private System.Windows.Forms.RadioButton RB_从节点单灯复位;
        private System.Windows.Forms.RadioButton RB_主节点单灯复位;
        private System.Windows.Forms.RadioButton RB_集中器复位;
        private System.Windows.Forms.ToolStripButton btn_界面切换;
        private System.Windows.Forms.TabControl tabControl_Console;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dGV_esxStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFailpercent;
        private System.Windows.Forms.Label labelOKpercent;
        private System.Windows.Forms.Label labelTotalCnt;
        private System.Windows.Forms.Label labelFailCnt;
        private System.Windows.Forms.Label labelOKcnt;
        private System.Windows.Forms.CheckBox chk_定时读取;
        private System.Windows.Forms.NumericUpDown QueryIntervalTime;
        private System.Windows.Forms.Button btn_状态招测;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_OK;
        private System.Windows.Forms.Label label_Fail;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl EsxUserCtrlGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btn_单灯遥控;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label控制灯盏数;
        private System.Windows.Forms.Button btn_时钟查询;
        private System.Windows.Forms.Button btn_时钟设置;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_查询参数;
        private System.Windows.Forms.Button btn_设置参数;
        private System.Windows.Forms.TabControl tabControl_cfg;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox 设备地址Txt;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox 安装位置Txt;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox 版本号Txt;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox 设备序列号txt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage8;
        private DevExpress.XtraGrid.GridControl EsxNetGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.TabPage tabPage9;
        private DevExpress.XtraGrid.GridControl EsxTimeCtrlGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton TimingCtlAbsolute;
        private System.Windows.Forms.RadioButton TimingCtlRelative;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton TimingCtlEnable;
        private System.Windows.Forms.RadioButton TimingCtlDissable;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker startDtp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown ValidNumupdowm;
        private System.Windows.Forms.DateTimePicker OffLightDtp;
        private System.Windows.Forms.DateTimePicker OnLightDtp;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.DataGridView DGV_JWD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.NumericUpDown JWD_DAYS;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown JWD_S_DAY;
        private System.Windows.Forms.NumericUpDown JWD_S_MONTH;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label_文件大小;
        private System.Windows.Forms.Label label_版本号;
        private System.Windows.Forms.Button Btn_固件升级;
        private System.Windows.Forms.TextBox DevModelTxt;
        private System.Windows.Forms.TextBox textBinFileSize;
        private System.Windows.Forms.TextBox textBinVerNO;
        private System.Windows.Forms.TextBox BinPathTxt;
        private System.Windows.Forms.TextBox textTryCnt;
        private System.Windows.Forms.TextBox textTryTimeout;
        private System.Windows.Forms.Label label_终端型号;
        private System.Windows.Forms.Label 剩余时间label;
        private System.Windows.Forms.ProgressBar 固件升级进度条;
        private System.Windows.Forms.ComboBox FirmwarePackedSizeCmb;
        private System.Windows.Forms.Label label_数据包大小;
        private System.Windows.Forms.Label label_重试次数;
        private System.Windows.Forms.Button btn_浏览BIN文件;
        private System.Windows.Forms.Label label_超时时间;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btn_数据发送;
        private System.Windows.Forms.CheckBox Chk_Format十六进制;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_协议解析;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btn_重新加载;
        private System.Windows.Forms.ToolStripComboBox cbClient;
        private System.Windows.Forms.ToolStripMenuItem ToolStripEcxStatusRead;
        private System.Windows.Forms.ToolStripMenuItem ToolStripEcxTimeSyn;
        private System.Windows.Forms.ToolStripMenuItem ToolStripEcxLampControl;


    }
}

