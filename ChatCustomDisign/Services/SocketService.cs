using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ChatCustomDisign.Services
{
    public class SocketService
    {
        public SocketService()
        {

        }

        public void Socket()
        {
            using (var ws = new WebSocket("wss://"))
            {
                ws.CustomHeaders = new Dictionary<string, string> {
                    {"Authorization", ""},
                };
           }
        }
    }
}
