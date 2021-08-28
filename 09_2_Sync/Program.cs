using System;
using System.Threading;

namespace _09_2_Sync
{

    public class A
    {
        public int x = 0;
        public object sync = new object();

        public void Count()
        {
            lock (sync)
            {
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }

            // What the compiler do?
            {
                bool acquiredLock = false;
                try
                {
                    Monitor.Enter(sync, ref acquiredLock);
                    x = 1;
                    for (int i = 1; i < 9; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(sync);
                }
            }
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            A a = new A();
            A b = new A();
            // lock
            { 
                //Create 5 threads with common resource
                for (int i = 0; i < 5; i++)
                {
                    Thread myThread = new Thread(a.Count);
                    myThread.Name = "Thread " + i.ToString();
                    myThread.Start();

                    Thread myThread2 = new Thread(b.Count);
                    myThread2.Name = "Thread2 ---- " + i.ToString();
                    myThread2.Start();
                }
            }

        }



    }
}
