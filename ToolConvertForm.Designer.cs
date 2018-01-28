namespace ServerBySocket
{
    partial class ToolConvertForm
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
            this.TxtHex_0x = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtHex_Space = new System.Windows.Forms.TextBox();
            this.TxtHex_null = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtHex = new System.Windows.Forms.TextBox();
            this.TxtUnicode = new System.Windows.Forms.TextBox();
            this.TxtAscii = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtHex_0x
            // 
            this.TxtHex_0x.Location = new System.Drawing.Point(80, 57);
            this.TxtHex_0x.Margin = new System.Windows.Forms.Padding(0);
            this.TxtHex_0x.Name = "TxtHex_0x";
            this.TxtHex_0x.ReadOnly = true;
            this.TxtHex_0x.Size = new System.Drawing.Size(437, 21);
            this.TxtHex_0x.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ascii";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "unicode";
            // 
            // TxtHex_Space
            // 
            this.TxtHex_Space.Location = new System.Drawing.Point(80, 77);
            this.TxtHex_Space.Margin = new System.Windows.Forms.Padding(0);
            this.TxtHex_Space.Name = "TxtHex_Space";
            this.TxtHex_Space.ReadOnly = true;
            this.TxtHex_Space.Size = new System.Drawing.Size(437, 21);
            this.TxtHex_Space.TabIndex = 4;
            // 
            // TxtHex_null
            // 
            this.TxtHex_null.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtHex_null.Location = new System.Drawing.Point(80, 97);
            this.TxtHex_null.Margin = new System.Windows.Forms.Padding(0);
            this.TxtHex_null.Name = "TxtHex_null";
            this.TxtHex_null.ReadOnly = true;
            this.TxtHex_null.Size = new System.Drawing.Size(437, 21);
            this.TxtHex_null.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtHex);
            this.groupBox1.Controls.Add(this.TxtUnicode);
            this.groupBox1.Controls.Add(this.TxtAscii);
            this.groupBox1.Controls.Add(this.TxtHex_null);
            this.groupBox1.Controls.Add(this.TxtHex_Space);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtHex_0x);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "转换工具";
            // 
            // TxtHex
            // 
            this.TxtHex.Location = new System.Drawing.Point(80, 23);
            this.TxtHex.Margin = new System.Windows.Forms.Padding(0);
            this.TxtHex.Name = "TxtHex";
            this.TxtHex.Size = new System.Drawing.Size(437, 21);
            this.TxtHex.TabIndex = 0;
            this.TxtHex.TextChanged += new System.EventHandler(this.TxtHex_TextChanged);
            // 
            // TxtUnicode
            // 
            this.TxtUnicode.Location = new System.Drawing.Point(80, 150);
            this.TxtUnicode.Margin = new System.Windows.Forms.Padding(0);
            this.TxtUnicode.Name = "TxtUnicode";
            this.TxtUnicode.Size = new System.Drawing.Size(437, 21);
            this.TxtUnicode.TabIndex = 2;
            this.TxtUnicode.TextChanged += new System.EventHandler(this.TxtUnicode_TextChanged);
            // 
            // TxtAscii
            // 
            this.TxtAscii.Location = new System.Drawing.Point(80, 130);
            this.TxtAscii.Margin = new System.Windows.Forms.Padding(0);
            this.TxtAscii.Name = "TxtAscii";
            this.TxtAscii.Size = new System.Drawing.Size(437, 21);
            this.TxtAscii.TabIndex = 1;
            this.TxtAscii.TextChanged += new System.EventHandler(this.TxtAscii_TextChanged);
            // 
            // ToolConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 220);
            this.Controls.Add(this.groupBox1);
            this.Name = "ToolConvertForm";
            this.Text = "ToolConvertForm";
            this.Load += new System.EventHandler(this.ToolConvertForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHex_0x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtHex_Space;
        private System.Windows.Forms.TextBox TxtHex_null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtUnicode;
        private System.Windows.Forms.TextBox TxtAscii;
        private System.Windows.Forms.TextBox TxtHex;
    }
}