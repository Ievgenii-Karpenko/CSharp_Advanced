using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleServerChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Thread serverThread = new Thread(new ThreadStart(server.ListenToHost));
            serverThread.Start();
            Console.WriteLine("Hello World!");
        }
    }

    class Server
    {
        List<Client> clients = new List<Client>();
        TcpListener tcpListener;

        public void ListenToHost()
        {
            tcpListener = new TcpListener(8080);
            tcpListener.Start();

            while(true)
            {
                TcpClient clientTcp = tcpListener.AcceptTcpClient();

                Client client = new Client(clientTcp, this);
                clients.Add(client);

                Thread clientThread = new Thread(new ThreadStart(client.Procces));
                clientThread.Start();
            }
        }

        public void Broadcast(string msg)
        {
            // 1) decode string to bytes
            byte[] data = new byte[64]; // need to implement
            foreach (var item in clients)
            {
                item.Stream.Write(data, 0, data.Length);
            }
        }
    }

    class Client
    {
        string ip = "192.168.0.103";
        int port = 8080;
        public TcpClient clientTcp;
        public NetworkStream Stream;
        public Server server;

        public Client(TcpClient clientTcp, Server server)
        {
            this.clientTcp = clientTcp;
            this.server = server;
        }

        public void Procces()
        {
            Stream = clientTcp.GetStream();
            string msg = GetMessage();

            server.Broadcast(msg);
        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder sb = new StringBuilder();

            do
            {
                int v = Stream.Read(data, 0, data.Length);
                sb.Append(Encoding.Unicode.GetString(data, 0, v));
            }
            while (Stream.DataAvailable);

            return sb.ToString();
        }
    }

}
