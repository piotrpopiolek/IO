using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(ThreadServer);
        //Klienci
        ThreadPool.QueueUserWorkItem(ThreadClient);
        ThreadPool.QueueUserWorkItem(ThreadClient2);
        Thread.Sleep(1000);

        Console.ReadKey();
    }

    static void ThreadServer(Object stateInfo)
    {
        TcpListener server = new TcpListener(IPAddress.Any, 2048);
        server.Start();
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            byte[] buffer = new byte[128];
            client.GetStream().Read(buffer, 0, 128);
            writeConsoleMessage(Encoding.UTF8.GetString(buffer), ConsoleColor.Blue);
            client.GetStream().Write(buffer, 0, buffer.Length);
            client.Close();
        }
        Thread.Sleep(500);
    }
    static void ThreadClient(Object stateInfo)
    {

        TcpClient client = new TcpClient();
        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
        byte[] message = new byte[128];
        message = new ASCIIEncoding().GetBytes("Klient 1");
        NetworkStream stream = client.GetStream();
        client.GetStream().Write(message, 0, message.Length);
    }
    static void ThreadClient2(Object stateInfo)
    {

        TcpClient client = new TcpClient();
        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
        byte[] message = new byte[128];
        message = new ASCIIEncoding().GetBytes("Klient 2");
        NetworkStream stream = client.GetStream();
        client.GetStream().Write(message, 0, message.Length);
    }
    static void writeConsoleMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}