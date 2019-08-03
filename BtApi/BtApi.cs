using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaoTaApi.BtApi
{
     class BtApi : BtConfigApi
    {
        /// <summary>
        /// 传入宝塔面板的信息
        /// </summary>
        /// <param name="key">接口密钥</param>
        /// <param name="panel">面板地址</param>
        public BtApi(String key, String panel):base(key,panel)
        {
            this.BT_PANEL = key;
            this.BT_PANEL = panel;
        }
        #region 系统状态相关接口
        /// <summary>
        /// 获取系统基础统计
        /// </summary>
        /// <returns>系统基础统计数据</returns>
        public String GetSystemTotal() {
            String url = this.BT_PANEL + "/system?action=GetSystemTotal";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}", temp[0], temp[1]);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        /// <summary>
        /// 获取磁盘分区信息
        /// </summary>
        /// <returns></returns>
        public String GetDiskInfo()
        {
            String url = this.BT_PANEL + "/system?action=GetDiskInfo";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}", temp[0], temp[1]);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        /// <summary>
        /// 获取实时状态信息(CPU、内存、网络、负载)
        /// </summary>
        /// <returns></returns>
        public String GetNetWork()
        {
            String url = this.BT_PANEL + "/system?action=GetNetWork";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}", temp[0], temp[1]);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        /// <summary>
        /// 检查是否有安装任务
        /// </summary>
        /// <returns></returns>
        public String GetTaskCount()
        {
            String url = this.BT_PANEL + "/ajax?action=GetTaskCount";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}", temp[0], temp[1]);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        /// <summary>
        /// 检查面板更新
        /// </summary>
        /// <returns></returns>
        public String UpdatePanel()
        {
            String url = this.BT_PANEL + "/ajax?action=UpdatePanel";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}", temp[0], temp[1]);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        #endregion

        #region 网站管理
            /// <summary>
        /// 获取网站列表
        /// </summary>
        /// <param name="limit">取回的数据行数 [必传]</param>
        /// <param name="p">当前分页 [可选]</param>
        /// <param name="type">分类标识, -1: 分部分类 0: 默认分类 [可选]</param>
        /// <param name="order">排序规则 使用 id 降序：id desc 使用名称升序：name desc [可选]</param>
        /// <param name="tojs">分页 JS 回调,若不传则构造 URI 分页连接 [可选]</param>
        /// <param name="search">搜索内容 [可选]</param>
        /// <returns></returns>
        public String getDataSite(int limit, int p = 1, int type = -1,String order = "id desc", String tojs = "get_site_list", String search = "")
        {
            String url = this.BT_PANEL + "/data?action=getData&table=sites";
            String[] temp = this.GetKeyData();//取签名
            String PostData = String.Format("request_token={0}&request_time={1}&p={2}&limit={3}&type={4}&order={5}&tojs={6}&search={7}", temp[0], temp[1],p,limit,type,order,tojs,search);//准备POST数据
            HttpPostCookie h = new HttpPostCookie(url, "", PostData);
            String res = h.GetBaoTaData();
            return res;
        }
        #endregion


    }
}
