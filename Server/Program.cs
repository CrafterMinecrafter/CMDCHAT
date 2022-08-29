using Server.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace CMDCHAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer(IPAddress.Parse("26.22.168.32"),7777);
            wssv.AddWebSocketService<Chat>("/Chat");
            wssv.Start();
            Console.ReadKey(true);
        }
    }
}
