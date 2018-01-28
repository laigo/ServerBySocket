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
    public partial class EcxUserControl : Form
    {
        public EcxUserControl()
        {
            InitializeComponent();
        }

        private void EcxUserControl_Load(object sender, EventArgs e)
        {
            InitEsxUserControlTable();
        }

        public void InitEsxUserControlTable()
        {
            numericUpDown1.Value = LampUserControl.lampCtrlList.Count;
            EsxUserCtrlGrid.DataSource = LampUserControl.lampCtrlList;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LampUserControl.lampCtrlList.Clear();

            LampUserControl.lampId = 1;

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                LampUserControl.lampCtrlList.Add(new LampUserControl(LampUserControl.lampId++) { 开关档位 = 100 });
            }
            EsxUserCtrlGrid.RefreshDataSource();
        }

        private void btn_单灯遥控_Click(object sender, EventArgs e)
        {

        }
    }
}
