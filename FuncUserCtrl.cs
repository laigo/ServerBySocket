using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    public class LampUserControl
    {
        public LampUserControl(int id)
        {
            灯盏序号 = id;
        }
        //学号
        //public int 灯盏序号 { get; private set; }
        public int 灯盏序号 { get; set; }

        public int 开关档位 { get; set; }


        //姓名
        //public string Name { get; set; }
        //课程
        //public string Course { get; set; }
        //成绩
        //public float Score { get; set; }

        public static int lampId = 1;

        public static List<LampUserControl> lampCtrlList = new List<LampUserControl>();
    }
}
