using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace TwitchIRC
{
    class Program
    {
       // TO DO Uporzadkowac to wszystko w klasy. 
       // TO DO Osobny thread do odczytywania wiadomosci.

        static void Main(string[] args)
        {
        string adressURL = "irc.chat.twitch.tv";
        int port = 6667;
        string pw = File.ReadAllText("pw.txt");
        TcpClient tcpClient = new TcpClient(adressURL, port);
       
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter writer = new StreamWriter(tcpClient.GetStream());

            writer.WriteLine($"PASS {pw}");
            writer.Flush();
            writer.WriteLine("NICK bargaw");
            writer.Flush();
            writer.WriteLine("JOIN #bargaw");
            writer.Flush();
            writer.WriteLine("PRIVMSG #bargaw :Hello World!");
            writer.Flush();

            while (tcpClient.Connected)
            {
                Console.WriteLine(reader.ReadLine());
                Thread.Sleep(100);
            }
        



        }
    }
}
