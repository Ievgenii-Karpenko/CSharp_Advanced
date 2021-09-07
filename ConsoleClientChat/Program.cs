using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientChat
{
    class Program
    {
        private static TcpClient client;
        private static NetworkStream stream;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            client = new TcpClient("192.168.0.103", 8080);
            stream = client.GetStream();

            string msg = "Hello from client";
            byte[] bytes = Encoding.Unicode.GetBytes(msg);
            stream.Write(bytes, 0, bytes.Length);

            Console.ReadLine();
            
        }

        //static byte[] GetMsgInBytes(string msg)
        //{

        //}
    }
}
