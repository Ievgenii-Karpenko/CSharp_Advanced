using System;
using System.Collections;
using System.Collections.Generic;

namespace _01_Collections
{

    class Student : IComparable<Student>
    {
        public string Name;
        int Age;

        public int CompareTo(Student other)
        {
            throw new NotImplementedException();
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

    class Program
    {
        static void Main(string[] args)
        {

            //IList<T>
            //ArrayList
            {
                //int[] asdas = new int[5];

                List<int> coll = new List<int>();

                //// Создадим новую коллекцию чисел длиной 8
                ////ArrayList coll = new ArrayList(8);
                //Console.WriteLine("Initial collection: ");
                //ShowCollection(coll);

                ////coll.Add("abc");

                //// Добавим еще несколько элементов
                //Random ran = new Random();
                //for (int j = 0; j < 5; j++)
                //    coll.Add(ran.Next(1, 50));
                //Console.WriteLine("Added 5 elements: ");
                //ShowCollection(coll);



                //// Удалим пару элементов
                //coll.RemoveRange(2, 2);
                //Console.WriteLine("After removing 2 elements: ");
                //ShowCollection(coll);

                ////Отсортируем теперь коллекцию
                ////coll.Sort(new Comparator());
                //Console.WriteLine("Sorted collection: ");
                //ShowCollection(coll);
            }

            //Hashtable
            {
                //Hashtable ht = new Hashtable();

                //// Добавим несколько записей
                //ht.Add("alex85", "12345");
                //ht.Add("fg230404", "12ldsd");
                //ht.Add("I_best_user", "12349");

                //Console.WriteLine(ht["fg230404"]);

                //// Считаем коллекцию ключей
                //ICollection keys = ht.Keys;

                //foreach (string s in keys)
                //    Console.WriteLine(s + ": " + ht[s]);

                //// Считаем коллекцию значений
                //ICollection vals = ht.Values;
                //Console.WriteLine("--- Just Values ---");
                //ShowCollection(vals);
            }

            //Stack
            {
                //var MyStack = new Stack<char>();
                //MyStack.Push('A');
                //MyStack.Push('B');
                //MyStack.Push('C');
                //MyStack.Push('D');
                ////MyStack.Push(6);

                //Console.WriteLine("Initial stack: ");
                //ShowCollection(MyStack);

                //// Can't modify collection inside foreach loop
                ////foreach (var item in MyStack)   
                ////{
                ////    Console.WriteLine("Pop -> {0}", MyStack.Pop());
                ////}

                //Console.WriteLine(MyStack.Pop());
                //Console.WriteLine(MyStack.Pop());
                //Console.WriteLine(MyStack.Pop());
                //Console.WriteLine("-------");
                //ShowCollection(MyStack);

                //while (MyStack.Count > 0)
                //{
                //    Console.WriteLine("Pop -> {0}", MyStack.Peek());
                //}

                //if (MyStack.Count == 0)
                //    Console.WriteLine("\nStack is empty!");
            }

            //Queue
            {
                Queue<int> qe = new Queue<int>();
                //Random ran = new Random();

                //for (int i = 0; i < 10; i++)
                //    qe.Enqueue(i);

                //Console.WriteLine("Queue: \n");
                //ShowCollection(qe);

                //var deq = qe.Dequeue();
                //Console.WriteLine($"Get element from q: {deq}");
                //Console.WriteLine("After Dequeue:");
                //foreach (var item in qe)
                //{
                //    Console.WriteLine(qe.Dequeue());
                //}
                //ShowCollection(qe);
                //while (qe.Count > 0)
                //{
                //    Console.WriteLine($"Get element from q: {qe.Dequeue()}");
                //}
            }

            //LinkedList
            {
                //LinkedList<string> link = new LinkedList<string>();

                //// Добавим несколько элементов
                //link.AddFirst("Alex");
                //link.AddFirst("Jack");
                //link.AddFirst("Bob");
                //link.AddFirst("Don");

                //var bobElement = link.Find("Bob");
                //link.AddAfter(bobElement, "Daniel");

                //// Отобразим элементы в прямом направлении
                //LinkedListNode<string> node;
                //Console.WriteLine("Elements: ");
                //for (node = link.First; node != null; node = node.Next)
                //    Console.Write(node.Value + "\t");

                ////Same way
                ////ShowCollection(link);

                //// Отобразить элементы в обратном направлении
                //Console.WriteLine("\n\nReversed elements: ");
                //for (node = link.Last; node != null; node = node.Previous)
                //    Console.Write(node.Value + "\t");
            }

            //SortedList
            {
                //SortedList<string, string> UserInfo = new SortedList<string, string>();

                ////Добавим несколько элементов в коллекию
                //UserInfo.Add("Zack", "12345");
                //UserInfo.Add("Den", "23456");
                //UserInfo.Add("Alex", "13562");
                //UserInfo.Add("John", "87693");
                //UserInfo.Add("Elhm", "23423");
                //UserInfo.Add("Lamar", "98741");

                ////Коллекция ключей
                //ICollection<string> keys = UserInfo.Keys;

                ////Теперь используем ключи, для получения значений
                //foreach (string s in keys)
                //    Console.WriteLine("User: {0}, Password: {1}", s, UserInfo[s]);
            }

            //Dictionary
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                Console.WriteLine("Write names: \n");
                string s;
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"Name{j} --> ");
                    //s = Console.ReadLine();
                    dic.Add(j, j.ToString());
                    Console.Clear();
                }
                //dic.Add(1, "asdf");

                Console.WriteLine("Dictionary: ");
                foreach (int j in dic.Keys)
                    Console.WriteLine($"ID -> {j}  Name -> {dic[j]}");
            }

            //Set
            {
                //HashSet<Student> s1 = new HashSet<Student>();
                //s1.Add(new Student() { Name = "A"});
                //s1.Add(new Student() { Name = "B" });

                //foreach (var item in s1)
                //{
                //    Console.WriteLine(item.Name);
                //}

                //ISet<char> ss = new SortedSet<char>();
                //ISet<char> ss1 = new HashSet<char>();

                //ss.Add('A');
                //ss.Add('B');
                //ss.Add('C');
                //ss.Add('Z');
                //Console.WriteLine("First set");
                //ShowCollection(ss);

                //ss1.Add('X');
                //ss1.Add('Y');
                //ss1.Add('Z');
                //Console.WriteLine("Second set");
                //ShowCollection(ss1);

                //ss.IntersectWith(ss1);
                //Console.WriteLine("IntersectWith");
                //ShowCollection(ss);

                //ss.UnionWith(ss1);
                //Console.WriteLine("Sets union");
                //ShowCollection(ss);

                //ss.ExceptWith(ss1);
                //Console.WriteLine("Sets except");
                //ShowCollection(ss);
            }

            //IEnumerable implementation
            {
                IntArr mi = new IntArr();

                //ShowCollection(mi);
                foreach (int i in mi)
                    Console.Write(i + "\t");

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
