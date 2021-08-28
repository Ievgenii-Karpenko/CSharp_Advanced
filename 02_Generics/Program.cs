using _01_Collections;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _02_Generics
{
    class MyObj<T>
    {
        public T obj1;

        public MyObj(T obj1)
        {
            this.obj1 = obj1;
        }

        public void ObjectInfo()
        {
            Console.WriteLine("\nObject value: " + obj1);
            Console.WriteLine("\nObject type: " + obj1.GetType());
        }
    }

    class MyObj2<T, K> where T : IEnumerable
    {
        public T obj1;
        public K obj2;

        public MyObj2(T obj1, K o2)
        {
            this.obj1 = obj1;
            this.obj2 = o2;
        }

        public K GetKValue<E>(E obj)
        {
            Console.WriteLine(obj);
            return obj2;
        }

        public void ObjectInfo()
        {
            foreach (var item in obj1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nObject value: " + obj1);
            Console.WriteLine("\nObject type: " + obj1.GetType());

            Console.WriteLine("\nObject value: " + obj2);
            Console.WriteLine("\nObject type: " + obj2.GetType());
        }
    }


    //class MyObjects<T, V, E>
    //{
    //    T obj1;
    //    V obj2;
    //    E obj3;

    //    public MyObjects(T obj1, V obj2, E obj3)
    //    {
    //        this.obj1 = obj1;
    //        this.obj2 = obj2;
    //        this.obj3 = obj3;
    //    }

    //    public void ObjectInfo()
    //    {
    //        Console.WriteLine("\nObject type 1: " + typeof(T) +
    //            "\nObject type 2: " + typeof(V) +
    //            "\nObject type 3: " + typeof(E));
    //    }
    //}

    class Program
    {
        static void Main()
        {
            //Generics
            {
                //MyObj<int> obj1 = new MyObj<int>(3);
                //obj1.ObjectInfo();

                //MyObj<double> obj2 = new MyObj<double>(6.2);
                //obj2.ObjectInfo();

                //MyObj2<int, string> my = new MyObj2<int, string>(2, "sdf");
                //my.ObjectInfo();


                //MyObj2<double, float> my2 = new MyObj2<double, float>(2.3, 5.3f);
                //my2.ObjectInfo();

                //var s = my2.GetKValue<string>("54.5f");


                //MyObj<string, string> my2 = new MyObj<string, string>();
                //my2.Set("dsfsdf");

                //MyObj<MyCl> obj1 = new MyObj<MyCl>();
                //obj1.ObjectInfo();

                //MyObj<double> obj2 = new MyObj<double>(25.5);
                //obj2.ObjectInfo();

                //MyObj<string> obj3 = new MyObj<string>("asasdasd");
                //obj3.ObjectInfo();

                //MyObjects<string, byte, decimal> obj2 = new MyObjects<string, byte, decimal>("John", 26, 12.423m);
                //obj2.ObjectInfo();
            }

            //Constraints
            {
                Info<UserInfo> database1 = new Info<UserInfo>();

                database1.Add(new FamilyInfoUser(Name: "Alex", Family: "Smith", Age: 26));
                database1.Add(new FamilyInfoUser(Name: "Donald", Family: "Johnson", Age: 28));
                database1.Add(new FamilyInfoUser(Name: "Mishel", Family: "Obama", Age: 50));

                database1.Add(new UserInfo(Name: "Alex", Age: 26));
                database1.Add(new UserInfo(Name: "Donald", Age: 28));
                database1.Add(new UserInfo(Name: "Mishel", Age: 50));
                //database1.Add(new User(Name: "Mishel", Age: 50)); // Compile error

                database1.ReWrite();
            }

            //Constraints_2
            {
                UI user1 = new UI(Name: "Alexandr", Age: 26);
                UserInfo2<UI> user = new UserInfo2<UI>(user1);
                //UserInfo2<int> user2 = new UserInfo2<int>(123);
            }

            //Default
            {
                Class1<string> a = new Class1<string>();
                Class1<short> b = new Class1<short>();
                Class1<double> c = new Class1<double>();

                if (a.SomeField == null)
                    Console.WriteLine("a.obj = null");

                if (b.SomeField.GetType() == typeof(int))
                { 
                    Console.WriteLine("b.obj = 0");
                    b.SomeField = 18;
                }
            }

            //Static field
            {
                StaticDemo<string>.X = 4;
                StaticDemo<User>.X = 6;
                StaticDemo<UserInfo>.X = 7;
                StaticDemo<int>.X = 5;
                Console.WriteLine(StaticDemo<string>.X);
                Console.WriteLine(StaticDemo<int>.X);
                Console.WriteLine(StaticDemo<User>.X);
                Console.WriteLine(StaticDemo<UserInfo>.X);
            }

            //Nullable
            {
                int? a = null;
                //Console.WriteLine($"a = {a.Value}");
                //if (!a.HasValue)
                //    a = 5;

                //Console.WriteLine($"a = {a.Value}");

                Nullable<int> x = default;
                x = 4;

                Console.WriteLine($"x = {x}");
                //if (!x.HasValue)
                //    x = 5;

                ShowValue((int)x);

                Console.ReadLine();
            }

            Console.ReadLine();
        }

        public static void ShowValue(int a)
        {
            Console.WriteLine(a);
        }
    }

    public class StaticDemo<T>
    {
        public static int X;
        //public static T Y;
    }
}


//Common
// IMassage
//   -- From
//   -- ToWhom
//   -- Text
//   -- TimeStamp
// optional
//   -- Color, textFormat etc

// Client:
// SendMessage(IMessage msg)
// ConnectToServer(IP, Port)
// ReceiveMessage(IMessage msg)


// Server
// GetMessage
// NotifyAll(IMessage msg)
// NotifyAll(Client, IMessage msg)
// List of Clients


