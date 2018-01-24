using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ThreadServer);
            ThreadPool.QueueUserWorkItem(ThreadClient2);
            ThreadPool.QueueUserWorkItem(ThreadClient1);

            Console.ReadKey();
        }

        static void ThreadServer(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.1.1.1"), 2048);
            server.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(ClientConnected, client);
            }
            Thread.Sleep(100);
        }

        static void ThreadClient1(Object stateInfo)
        {
            byte[] sendMessage = new byte[128];
            byte[] receiveMessage = new byte[128];

            sendMessage = new ASCIIEncoding().GetBytes("Wiadomosc Klienta 1");

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.1.1.1"), 2048));

            client.GetStream().Write(sendMessage, 0, sendMessage.Length);

            client.GetStream().Read(receiveMessage, 0, 128);

            if (receiveMessage.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Klient 1: Wiadomosc odebrana : {0}", Encoding.UTF8.GetString(receiveMessage));
                Console.ResetColor();
            }
            Thread.Sleep(100);
        }

        static void ThreadClient2(Object stateInfo)
        {
            byte[] sendMessage = new byte[128];
            byte[] receiveMessage = new byte[128];

            sendMessage = new ASCIIEncoding().GetBytes("Wiadomosc Klienta 2");

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.1.1.1"), 2048));

            client.GetStream().Write(sendMessage, 0, sendMessage.Length);

            client.GetStream().Read(receiveMessage, 0, 128);

            if (receiveMessage.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Klient 2: Wiadomosc odebrana : {0}", Encoding.UTF8.GetString(receiveMessage));
                Console.ResetColor();
            }
            Thread.Sleep(100);
        }

        static void ClientConnected(Object client)
        {
            TcpClient TClient = (TcpClient)client;

            byte[] buffer = new byte[128];

            TClient.GetStream().Read(buffer, 0, 128);

            string receivedMessage = Encoding.UTF8.GetString(buffer);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Serwer: Wiadomosc odebrana : {0}", receivedMessage);
            Console.ResetColor();

            byte[] sendMessage = new byte[1024];
            sendMessage = new ASCIIEncoding().GetBytes("Wiadomosc serwerowa");
            TClient.GetStream().Write(sendMessage, 0, sendMessage.Length);

            TClient.Close();

            Thread.Sleep(100);
        }
    }
}