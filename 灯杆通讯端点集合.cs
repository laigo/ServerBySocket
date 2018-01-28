using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBySocket
{
    class 灯杆通讯端点集合
    {
        public Dictionary<string, string> _list灯杆通讯端点集合 = null;

        public 灯杆通讯端点集合()
        {
            _list灯杆通讯端点集合 = new Dictionary<string, string>();       
        }

        public void UpdateInsert(string telnum, string endpoint)
        {
            //检索出是否字典中是否已经存在对应ID号的
            bool isExist = _list灯杆通讯端点集合.ContainsKey(telnum);

            if (isExist)
            {//IF YES  更新endpint 
                _list灯杆通讯端点集合[telnum] = endpoint;

            }
            else
            {//ELSE NO 添加到集合
                _list灯杆通讯端点集合.Add(telnum, endpoint);
            }           
        }

        public void Remove(string endpoint)
        {
            if (_list灯杆通讯端点集合.ContainsKey(endpoint))
            {
                _list灯杆通讯端点集合.Remove(endpoint);
            }
        }

        public string Select(string telnum)
        {
            if (_list灯杆通讯端点集合.ContainsKey(telnum))
            {//发送招测命令
                string endpoint = _list灯杆通讯端点集合[telnum];
                return endpoint;
            }
            return null;
        }

    }
}
