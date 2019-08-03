using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace BaoTaApi.BtApi
{
    public class HttpPostCookie
    {
        String url;
        String cookieStr;
        String postData;
        public HttpPostCookie(String urls,String cookie,String post) {
            url = urls;
            cookieStr = cookie;
            postData = post;
        }
        public String GetBaoTaData() {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
                request.Headers.Add("Cookie", cookieStr);
                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                String content = reader.ReadToEnd();
                return content;
            }
            catch (Exception)
            {
                throw;  
            }
        }
    }
}