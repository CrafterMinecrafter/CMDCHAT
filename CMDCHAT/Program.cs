using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp;
using MyChat.Structure;

namespace CMDCHAT
{
    class Program
    {
        private static string nickname = "lmao";
        [STAThread]
        static async Task Main(string[] args)
        {
            Console.WriteLine("pls put you nickname:\n");
            nickname = await Task.FromResult(Console.ReadLine());
            Console.WriteLine("connecting...");

            using (var ws = new WebSocket("ws://26.22.168.32:7777/Chat"))
            {
                ws.OnMessage += (sender, e) =>
                {
                    var m = Message.GetMessage(e.Data);
                    var data = m.toChatFormat();
                    Random rand = null;
                    if (m.isRainbow)
                    {
                        rand = new Random(strtools.StrToMD5(data));
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    if (data.Contains(nickname))
                    {
                        var i = strtools.FindSubStrings(data, nickname);
                        for (int i1 = 0; i1 < data.Length; i1++)
                        {
                            if (data[i1] == ' ')
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            if (i.Contains(i1))
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(data[i1]);
                            }
                            else
                            {
                                if (m.isRainbow)
                                    Console.ForegroundColor = (ConsoleColor)rand.Next(1, 15);
                                Console.Write(data[i1]);
                            }
                        }
                        Console.Write("\n");

                    }
                    else
                    {
                        if (!m.isRainbow)
                        {
                            Console.WriteLine(data);
                        }
                        else
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                Console.ForegroundColor = (ConsoleColor)rand.Next(1, 15);
                                Console.Write(data[i]);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n");

                        }
                    }
                };
                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("he sayed fuck you");
                    ws.Close(CloseStatusCode.Normal);
                };
                ws.Connect();
                Console.WriteLine("connected.");

                for (; ; )
                {
                    Console.Title = "Press Enter To write";
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Console.Title = "Press Enter To Send msg";


                        ws.Send(new Message(nickname, Console.ReadLine(), false).ToString());
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}