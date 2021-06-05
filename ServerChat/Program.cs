using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerChat
{
    class Program
    {
        static TcpClient client;
        static NetworkStream str;

        static void Main(string[] args)
        {
            client = new TcpClient();
            client.Connect("192.168.0.111", 5454);
            str = client.GetStream();

            //string message = "";
            //byte[] data = Encoding.Unicode.GetBytes(message);
            //str.Write(data, 0, data.Length);

            // запускаем новый поток для получения данных
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //старт потока

            //SendMessage();
        }

        static void SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                str.Write(data, 0, data.Length);
            }
        }

        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = str.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (str.DataAvailable);

                    string message = builder.ToString();
                    Console.WriteLine(message);//вывод сообщения
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    //Disconnect();
                }
            }
        }
    }
}
