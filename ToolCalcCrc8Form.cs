
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

namespace QF
{
    public partial class ToolCalcCrc8Form : Form
    {
        
        //ContextMenuStrip  cms = new  ContextMenuStrip();  //实例化一个
        //MenuStrip menuStrip1 = new MenuStrip();
      
        public ToolCalcCrc8Form()
        {
            InitializeComponent();
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            
            byte[] Data = Hex.FromHEXString(Calc_data_RTxt.Text);



            byte calcCrc8 = ServerBySocket.CRC.CRC8(Data, 0, Data.Length);

            CalcCrc_value_Txt.Text = calcCrc8.ToString("x2");

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolCalcCrc8Form_Load(object sender, EventArgs e)
        {
            Calc_data_RTxt.ContextMenuStrip = contextMenuStrip1;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Calc_data_RTxt.Copy(); //复制

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Calc_data_RTxt.Paste(); //粘贴
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Calc_data_RTxt.Cut(); //剪切
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Calc_data_RTxt.SelectAll();//全选
        }


#if false
        private void ToolCalcCrc8Form_Load(object sender, EventArgs e)
        {
            //添加菜单一
            ToolStripMenuItem subItem;
            subItem = AddContextMenu("Copy", menuStrip1.Items, null);
            cms.Items.Add(subItem);
            
            //添加子菜单
            //AddContextMenu("添加入库", subItem.DropDownItems, new EventHandler(MenuClicked));
            //AddContextMenu("入库管理", subItem.DropDownItems, new EventHandler(MenuClicked));

            //添加菜单二
            subItem = AddContextMenu("Paste", menuStrip1.Items, null);
            //添加子菜单
            //AddContextMenu("添加出库", subItem.DropDownItems, new EventHandler(MenuClicked));
           // AddContextMenu("出库管理", subItem.DropDownItems, new EventHandler(MenuClicked));

            cms.Items.Add(subItem);

            Calc_data_RTxt.ContextMenuStrip = cms;
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
        /// <param name="cms">要添加到的子菜单集合</param>
        /// <param name="callback">点击时触发的事件</param>
        /// <returns>生成的子菜单，如果为分隔条则返回null</returns>

        ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                tsmi.Tag = text + "TAG";
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);

                return tsmi;
            }

            return null;
        }


        /*
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            this.toolStripMenuItem_delete.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_delete.Text = "删除";
            this.toolStripMenuItem_delete.Click += new System.EventHandler(this.toolStripMenuItem_delete_Click);
            // 
            // toolStripMenuItem_clear
            // 
            this.toolStripMenuItem_clear.Name = "toolStripMenuItem_clear";
            this.toolStripMenuItem_clear.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_clear.Text = "清空";
            this.toolStripMenuItem_clear.Click += new System.EventHandler(this.toolStripMenuItem_clear_Click);        
         

         */


        /*
                 private void toolStripMenuItem_delete_Click(object sender, EventArgs e)

         */
#endif
    }
}
