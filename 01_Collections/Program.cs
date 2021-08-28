using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01_Collections
{

    public class Student : IComparable<Student>
    {
        public string Name;
        int Age;

        public Student(string name)
        {
            Name = name;
            Console.WriteLine($"Student {Name} Created");
        }

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }

    class Comparator : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare(x.ToString(), y.ToString());
        }
    }

    class ComparatorS : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return 0 - string.Compare(x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //IList<T>
            //ArrayList
            {
                int[] asdas = new int[5];

                // Создадим новую коллекцию чисел длиной 8
                ArrayList coll = new ArrayList();
                Console.WriteLine("Initial collection: ");
                ShowCollection(coll);

                int a = 123;

                coll.Add(a);
                coll.Add('a');
                coll.Add('b');

                // Добавим еще несколько элементов
                Random ran = new Random();
                for (int j = 0; j < 5; j++)
                    coll.Add(ran.Next(1, 50));
                Console.WriteLine("Added 5 elements: ");
                ShowCollection(coll);

                // Удалим пару элементов
                coll.RemoveRange(2, 2);
                Console.WriteLine("After removing 2 elements: ");
                ShowCollection(coll);

                //Отсортируем теперь коллекцию
                coll.Sort(new Comparator());
                Console.WriteLine("Sorted collection: ");
                ShowCollection(coll);
            }

            //Hashtable
            {
                Hashtable ht = new Hashtable();

                // Добавим несколько записей
                ht.Add("alex85", "12345");
                ht.Add("fg230404", "12ldsd");
                ht.Add("I_best_user", "12349");

                if (!ht.ContainsKey("alex85"))
                {
                    ht.Add("alex85", "12345");
                }

                Console.WriteLine(ht["fg230404"]);
                Console.WriteLine(ht["111"]);

                // Считаем коллекцию ключей
                ICollection keys = ht.Keys;

                foreach (string s in keys)
                    Console.WriteLine(s + ": " + ht[s]);

                // Считаем коллекцию значений
                ICollection vals = ht.Values;
                Console.WriteLine("--- Just Values ---");
                ShowCollection(vals);
            }

            //Stack
            {
                var MyStack = new Stack<char>();
                MyStack.Push('A');
                MyStack.Push('B');
                MyStack.Push('C');
                MyStack.Push('D');
                //MyStack.Push(51);

                Console.WriteLine("Initial stack: ");
                ShowCollection(MyStack);

                // Can't modify collection inside foreach loop
                //foreach (var item in MyStack)
                //{
                //    Console.WriteLine("Pop -> {0}", MyStack.Pop());
                //}

                Console.WriteLine(MyStack.Pop());
                Console.WriteLine(MyStack.Pop());
                Console.WriteLine(MyStack.Pop());
                Console.WriteLine("-------");
                ShowCollection(MyStack);

                while (MyStack.Count > 0)
                {
                    Console.WriteLine("Pop -> {0}", MyStack.Pop());
                }

                if (MyStack.Count == 0)
                    Console.WriteLine("\nStack is empty!");
            }

            //Queue
            {
                Queue<int> qe = new Queue<int>();
                //PriorityQueue<int> df = new PriorityQueue<int>();
                Random ran = new Random();

                for (int i = 0; i < 10; i++)
                    qe.Enqueue(i);

                Console.WriteLine("Queue: \n");
                ShowCollection(qe);

                var deq = qe.Dequeue();
                Console.WriteLine($"Get element from q: {deq}");
                Console.WriteLine("After Dequeue:");
                foreach (var item in qe)
                {
                    Console.WriteLine(item);
                }
                ShowCollection(qe);
                while (qe.Count > 0)
                {
                    Console.WriteLine($"Get element from q: {qe.Dequeue()}");
                }
            }

            //LinkedList
            {
                //List<string> link = new List<string>();

                LinkedList<string> link = new LinkedList<string>();

                // Добавим несколько элементов
                link.AddFirst("Alex");
                link.AddFirst("Jack");
                link.AddFirst("Bob");
                link.AddFirst("Don");

                var bobElement = link.Find("Bob");
                link.AddAfter(bobElement, "Daniel");

                // Отобразим элементы в прямом направлении
                LinkedListNode<string> node;
                Console.WriteLine("Elements: ");
                for (node = link.First; node != null; node = node.Next)
                    Console.Write(node.Value + "\t");

                //Same way
                //ShowCollection(link);

                // Отобразить элементы в обратном направлении
                Console.WriteLine("\n\nReversed elements: ");
                for (node = link.Last; node != null; node = node.Previous)
                    Console.Write(node.Value + "\t");
            }

            //SortedList
            {
                SortedList<int, string> UserInfo = new SortedList<int, string>();

                //Добавим несколько элементов в коллекию
                UserInfo.Add(3, "12345");
                UserInfo.Add(5, "23456");
                UserInfo.Add(2, "13562");
                UserInfo.Add(1, "87693");
                UserInfo.Add(6, "23423");
                UserInfo.Add(4, "98741");
                // UserInfo.Add("98741"); // Compile error
                //UserInfo.Add("Lamar", "98741");


                //Коллекция ключей
                ICollection<int> keys = UserInfo.Keys;

                //Теперь используем ключи, для получения значений
                foreach (var s in keys)
                    Console.WriteLine("User: {0}, Password: {1}", s, UserInfo[s]);
            }

            //Dictionary
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                Console.WriteLine("Write names: \n");
                //string s;
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"Name{j} --> ");
                    //s = Console.ReadLine();
                    dic.Add(j, j.ToString());
                }
                //dic.Add(1, "asdf");

                Console.WriteLine("Dictionary: ");
                foreach (int j in dic.Keys)
                    Console.WriteLine($"ID -> {j}  Name -> {dic[j]}");

                // Console.WriteLine($"{dic[55]}"); // Get exception
                var tr1 = dic.GetValueOrDefault(55);
                if (!dic.TryGetValue(55, out var tr2))
                {
                    Console.WriteLine("There is no element with key 55");
                }
            }

            //Set
            {
                SortedSet<Student> s1 = new SortedSet<Student>();
                s1.Add(new Student("Z"));
                s1.Add(new Student("A"));
                s1.Add(new Student("B"));

                foreach (var item in s1)
                {
                    Console.WriteLine(item.Name);
                }

                ISet<char> ss = new SortedSet<char>();
                ISet<char> ss1 = new HashSet<char>();

                ss.Add('A');
                ss.Add('B');
                ss.Add('C');
                ss.Add('Z');
                Console.WriteLine("First set");
                ShowCollection(ss);

                ss1.Add('X');
                ss1.Add('Y');
                ss1.Add('Z');
                Console.WriteLine("Second set");
                ShowCollection(ss1);

                ss.IntersectWith(ss1);
                Console.WriteLine("IntersectWith");
                ShowCollection(ss);

                ss.UnionWith(ss1);
                Console.WriteLine("Sets union");
                ShowCollection(ss);

                ss.ExceptWith(ss1);
                Console.WriteLine("Sets except");
                ShowCollection(ss);
            }

            //IEnumerable implementation
            {
                IntArr mi = new IntArr();

                //ShowCollection(mi);
                //var st = Students.GetStudents().ElementAt(3);
                //Console.WriteLine(st.Name);
                foreach (var i in Students.GetStudents().Take(2))
                {
                    Console.Write(i.Name + " ");
                    if (i.Name == "B")
                        break;
                }

            }

            //DateTime
            {
                DateTime date1 = new DateTime();
                Console.WriteLine(DateTime.MinValue);
                Console.WriteLine(date1); // 01.01.0001 0:00:00

                date1 = new DateTime(2021, 7, 20); // год - месяц - день
                Console.WriteLine(date1); // 20.07.2021 0:00:00

                date1 = new DateTime(2021, 7, 20, 18, 30, 25, DateTimeKind.Utc); // год - месяц - день - час - минута - секунда
                Console.WriteLine(date1); // 20.07.2021 18:30:25

                // adding of date
                Console.WriteLine(date1.AddHours(3)); // 20.07.2021 21:30:25

                DateTime date2 = new DateTime(2021, 7, 20, 15, 30, 25); // 20.07.2021 15:30:25
                Console.WriteLine(date1.Subtract(date2)); // 03:00:00

                Console.WriteLine(date1.AddHours(-3)); // 20.07.2021 15:30:25

                Console.WriteLine(date1.ToLocalTime()); // 20.07.2021 21:30:25
                Console.WriteLine(date1.ToUniversalTime()); // 20.07.2021 15:30:25
                Console.WriteLine(date1.ToLongDateString()); // 20 июля 2021 г.
                Console.WriteLine(date1.ToShortDateString()); // 20.07.2021
                Console.WriteLine(date1.ToLongTimeString()); // 18:30:25
                Console.WriteLine(date1.ToShortTimeString()); // 18:30


                var unix = DateTime.UnixEpoch;
                var b1 = unix.ToBinary();
                var b2 = DateTime.MinValue.ToBinary();
            }
            Console.ReadLine();
        }

        public static void ShowCollection(ICollection arr)
        {
            foreach (var a in arr)
                Console.Write($"{a}  ");
            Console.WriteLine("\n");
        }

        public static void ShowCollection<T>(ICollection<T> arr)
        {
            foreach (var a in arr)
                Console.Write($"{a}  ");
            Console.WriteLine("\n");
        }
    }
}
