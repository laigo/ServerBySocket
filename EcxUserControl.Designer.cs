namespace ServerBySocket
{
    partial class EcxUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.EsxUserCtrlGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_单灯遥控 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label控制灯盏数 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxUserCtrlGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 231);
            this.panel1.TabIndex = 5;
            // 
            // EsxUserCtrlGrid
            // 
            this.EsxUserCtrlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EsxUserCtrlGrid.Location = new System.Drawing.Point(5, 56);
            this.EsxUserCtrlGrid.MainView = this.gridView1;
            this.EsxUserCtrlGrid.Name = "EsxUserCtrlGrid";
            this.EsxUserCtrlGrid.Size = new System.Drawing.Size(507, 149);
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
            this.btn_单灯遥控.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
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
            // EcxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 255);
            this.Controls.Add(this.panel1);
            this.Name = "EcxUserControl";
            this.Text = "EcxUserControl";
            this.Load += new System.EventHandler(this.EcxUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EsxUserCtrlGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl EsxUserCtrlGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.Button btn_单灯遥控;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label控制灯盏数;
    }
}