using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task with parameter
            {
                //Task[] taskArray = new Task[10];
                //for (int i = 0; i < taskArray.Length; i++)
                //{
                //    taskArray[i] = Task.Factory.StartNew((object obj) =>
                //    {
                //        //CustomData data = obj as CustomData;
                //        //if (data == null)
                //        //    return;

                //        if(!(obj is CustomData))
                //            return;

                //        CustomData data = (CustomData) obj;

                //        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                //    },
                //    new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
                //}

                //Task.WaitAll(taskArray);

                //foreach (var task in taskArray)
                //{
                //    var data = task.AsyncState as CustomData;
                //    if (data != null)
                //        Console.WriteLine($"Task #{data.Name} created at {data.CreationTime}, ran on thread #{data.ThreadNum}.");
                //}
            }

            // Continue with
            {
                //{
                //    Task<int[]> getData = Task.Factory.StartNew(() => {
                //        Random rnd = new Random();
                //        int[] values = new int[100];
                //        for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
                //            values[ctr] = rnd.Next(0, 100);

                //        return values;
                //    });


                //    Task<(int n, long sum, double mean)> processData = getData.ContinueWith((x) => {
                //        int n = x.Result.Length;
                //        long sum = 0;
                //        double mean;

                //        for (int ctr = 0; ctr <= x.Result.GetUpperBound(0); ctr++)
                //            sum += x.Result[ctr];

                //        mean = sum / (double)n;
                //        return (n, sum, mean);
                //    });


                //    var displayData = processData.ContinueWith((x) => {
                //        return $"N={x.Result.Item1:N0}, Total = {x.Result.Item2:N0}, Mean = {x.Result.Item3:N2}";
                //    });
                //    Console.WriteLine(displayData.Result);
                //}
            }

            // Cancel
            {
                //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                //CancellationToken token = cancelTokenSource.Token;

                //Task task1 = new Task(() => Factorial(5, token));
                //task1.Start();

                //Console.WriteLine("Press \"Y\" for cancel:");
                //string s = Console.ReadLine();
                //if (s == "Y")
                //{ 
                //    cancelTokenSource.Cancel();
                //    Console.WriteLine("Cancel requested");
                //}

                //task1.Wait();

            }

            //Paralell
            {
                //Parallel.Invoke(
                //    Display,
                //    () =>
                //        {
                //            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                //            Thread.Sleep(3000);
                //        },
                //    () => Factorial(5)
                //);

                //For
                //Parallel.For(1, 10, Factorial);

                //// Foreach
                //ParallelLoopResult result = Parallel.ForEach(
                //    new List<int>() { 1, 3, 5, 8 }, Factorial);

                int[] numbers = new int[] { -2, -1, 0, 1, 2, 4, 3, 5, 6, 7, 8, };
                (from n in numbers.AsParallel()
                 where n > 0
                 select Factorial(n))
                 .ForAll(Console.WriteLine);

                //if (!result.IsCompleted)
                //    Console.WriteLine($"Execution ends on {result.LowestBreakIteration}");
            }
        }

        static void Factorial(int x, CancellationToken token)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                Thread.Sleep(5000);
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Operation cancelled");
                    return;
                }

                result *= i;
                
                Console.WriteLine($"{x}! = {result}");
                
            }
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            //Console.WriteLine($"Current task {Task.CurrentId}");
            //Console.WriteLine($"{x}! = {result}");
            //Thread.Sleep(3000);
            return result;
        }

        //static void Factorial(int x, ParallelLoopState pls)
        //{
        //    int result = 1;

        //    for (int i = 1; i <= x; i++)
        //    {
        //        result *= i;
        //        if (i == 5)
        //            pls.Break();
        //    }
        //    Console.WriteLine($"Current task {Task.CurrentId}");
        //    Console.WriteLine($"{x}! = {result}");
        //}

        static void Display()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }
    }

    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }

}
