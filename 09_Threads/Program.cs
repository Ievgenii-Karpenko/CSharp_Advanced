using System;
using System.Threading;
using System.Threading.Tasks;

namespace _09_Threads
{
    class Person
    {
        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Thread info
            {
                //Thread t = Thread.CurrentThread;

                ////Get thread name
                //Console.WriteLine($"Имя потока: {t.Name}");
                //t.Name = "-- Main thread --";
                //Console.WriteLine($"Имя потока: {t.Name}");

                //Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
                //Console.WriteLine($"Приоритет потока: {t.Priority}");
                //Console.WriteLine($"Статус потока: {t.ThreadState}");

                //// Get thread domain
                //Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");

                Task<string> t1 = Task.Factory.StartNew(() => "Hello!");
                Task t2 = new Task(Count1);

                Task[] tasks = new Task[4]
                {
                    new Task(() => Console.WriteLine("Hello 1!")),
                    new Task(() => Console.WriteLine("Hello 2!")),
                    new Task(() => Console.WriteLine("Hello 3!")),
                    new Task(() => Console.WriteLine("Hello 4!")),
                };

                foreach (var item in tasks)
                {
                    item.Start();
                }

                //t1.Wait();
                Task.WaitAll(tasks);

                Console.WriteLine(t1.Result);
            }

            // Create a thread
            {
                //Thread myThread = new Thread(Count1); // using of ThreadStart delegate
                //myThread.Start(); // run thread
                //myThread.IsBackground = true;
                //myThread.Priority = ThreadPriority.

                //for (int i = 1; i < 30; i++)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine($"Main Thread: {i}");
                //    //Thread.Sleep(300);
                //}
            }

            // Parameterized Thread
            {
                //int number = 4;
                //// создаем новый поток
                //Thread myThread = new Thread(Count);
                //myThread.Start(new object[] { 28, number });

                //for (int i = 1; i < 9; i++)
                //{
                //    Console.WriteLine("Главный поток:");
                //    Console.WriteLine(i * i);
                //    Thread.Sleep(300);
                //}

                //What if we need more then one parameter?
            }

            //Better way to use Parameterized Thread
            {
                //Counter counter = new Counter(5, 4);

                //Thread myThread = new Thread(counter.Count);
                //myThread.Start();
            }
        }

        public static void Count1()
        {
            for (int i = 1; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Second Thread: {i}");
                //Thread.Sleep(400);
            }
        }

        public static void Count(object number)
        {
            var N = (number as object[])[0];
            var count = (number as object[])[1];
            for (int i = 1; i < (int)count; i++)
            {
                Console.WriteLine($"{N} Thread: {i * i}");
                Thread.Sleep(400);
            }
        }
    }

    public class Counter
    {
        private int x;
        private int y;

        public Counter(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public void Count()
        {
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Второй поток:");
                Console.WriteLine(i * x * y);
                Thread.Sleep(400);
            }
        }
    }
}
