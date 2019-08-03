using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using BaoTaApi.Modular;

namespace BaoTaApi.BtApi
{
    class BtConfigApi
    {
        protected String BT_KEY;  //接口密钥
        protected String BT_PANEL;      //面板地址
    
        protected BtConfigApi(String key,String panel)
        {
            BT_KEY = key;
            BT_PANEL = panel;
        }
        /// <summary>
        /// 构造带有签名的关联数组
        /// </summary>
        /// <returns></returns>
        protected String[] GetKeyData() {
            String request_time = tools.GetUnixDate();
            String request_token = tools.GetMD5(request_time + tools.GetMD5(BT_KEY,""),"");
            String[] arr = {request_token,request_time };
            return arr;
        }
        
    }
}
