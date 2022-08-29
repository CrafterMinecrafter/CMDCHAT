using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Structure
{
    public class Message
    {
        public string User;
        public string Text;
        public bool isRainbow;


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string toChatFormat()
        {
            return User + ": " + Text;
        }
        public static Message GetMessage(string json)
        {
            return JsonConvert.DeserializeObject <Message> (json);
        }
        public Message(string user, string text, bool isRainbows)
        {
            User = user;
            Text = text;
            isRainbow = isRainbows;
        }
    }
}
