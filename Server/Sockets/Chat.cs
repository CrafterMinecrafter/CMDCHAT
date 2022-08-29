using Newtonsoft.Json;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;
using MyChat.Structure;
using System.Threading;
using System.Reactive.Linq;

namespace Server.Sockets
{
    public class Chat : WebSocketBehavior
    {
        private string _suffix;

        public Chat()
          : this(null)
        {/*
            Observable.Interval(TimeSpan.FromSeconds(30)).Subscribe(t =>
            Sessions.Broadcast(new Message("Server", "Now in chat - " + Sessions.Count, true).ToString()));*/
        }

        public Chat(string suffix)
        {
            _suffix = suffix ?? String.Empty;
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            var m = Message.GetMessage(e.Data);
            Console.WriteLine(m.toChatFormat());
            if (m.toChatFormat().ToLower().Contains("lgbt")) m.isRainbow = true;
            Sessions.Broadcast(m.ToString());
        }
    }
}