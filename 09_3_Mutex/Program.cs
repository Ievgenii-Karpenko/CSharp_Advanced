using System;
using System.Threading;

namespace _09_3_Mutex
{
    class Program
    {
        static Semaphore sem = new Semaphore(3,3);
        static Mutex mutexObj = new Mutex();
        static int x = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = $"Thread {i}";
                myThread.Start();
            }

            Console.ReadLine();
        }
        public static void Count()
        {
            sem.WaitOne();
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                x++;
                Thread.Sleep(100);
            }
            sem.Release();
        }
    }
}
