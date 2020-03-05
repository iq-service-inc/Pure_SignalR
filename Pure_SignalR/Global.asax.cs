using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Pure_SignalR
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Long Polling 最長連接時間，預設為 110 秒。時間到將重新發起連結 (Reconnect Event)
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);

            // 失去連線最多等待時間，預設為 30 秒，超過該時間將中斷連結 (Disconnected Event)
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);

            // 若不是使用 Long Polling 連線，SignalR 將每隔 10 秒 (預設) 發起 keepalive 封包來確認連線狀態
            // 這個數值不可超過 DisconnectTimeout 的 1/3 
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}