using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class LampTimeCtrl
    {
        public LampTimeCtrl(int id)
        {
            时段序号 = id;
        }

        public int 时段序号 { get; set; }


        public int 小时 { get; set; }
        public int 分钟 { get; set; }


        public byte CH1开关档位 { get; set; }
        public byte CH2开关档位 { get; set; }



        public static int gradeNo = 1;

        public static List<LampTimeCtrl> lampCtrlList = new List<LampTimeCtrl>();


    }
}
