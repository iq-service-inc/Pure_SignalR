using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pure_SignalR.Hubs
{
    [HubName("messaging")] // Hub 名稱
    public class MsgHub : Hub
    {
        // 可複寫，OnConnected 事件發生時會觸發
        public override Task OnConnected()  
        {
            // 取出 Connection ID
            Trace.WriteLine("ConnectionId: " + Context.ConnectionId);

            // 取出 header , cookie, query string
            var header = Context.Request.Headers;
            var cookies = Context.RequestCookies;
            var q = Context.Request.QueryString;
            Trace.WriteLine("Header: " + JsonConvert.SerializeObject(header));
            Trace.WriteLine("Cookies: " + JsonConvert.SerializeObject(cookies));
            Trace.WriteLine("Query: " + JsonConvert.SerializeObject(q));
      
            return base.OnConnected();
        }


        // 傳送訊息(後端推送到前端)
        public void Send(string name, string message)
        {
            // 對所有人廣播訊息
            Clients.All.broadcastMessage(name, message);
        }


        //public override Task OnReconnected() { } // 可複寫，OnReconnected 事件發生時會觸發
        //public override Task OnDisconnected(bool stopCalled) { } // 可複寫，OnDisconnected 事件發生時會觸發
    }
}