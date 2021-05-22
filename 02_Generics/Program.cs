using _01_Collections;
using System;
using System.Collections;

namespace _02_Generics
{
    class MyObj
    {
        int obj1;
    }

    //<MyObj>
    //    <obj1></obj1>
    //</MyObj>

    class MyObjects<T, V, E>
    {
        T obj1;
        V obj2;
        E obj3;

        public MyObjects(T obj1, V obj2, E obj3)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.obj3 = obj3;
        }

        public void ObjectInfo()
        {
            Console.WriteLine("\nObject type 1: " + typeof(T) +
                "\nObject type 2: " + typeof(V) +
                "\nObject type 3: " + typeof(E));
        }
    }

    class Program
    {
        static void Main()
        {
            //Generics
            {
                //MyObj<int, string> my = new MyObj<int, string>();
                //my.Set("dsfsdf");
                //my.Set(123);

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
                //Info<UserInfo> database1 = new Info<UserInfo>();
                //database1.Add(new FamilyInfoUser(Name: "Alex", Family: "Smith", Age: 26));
                //database1.Add(new FamilyInfoUser(Name: "Donald", Family: "Johnson", Age: 28));
                //database1.Add(new FamilyInfoUser(Name: "Mishel", Family: "Obama", Age: 50));
                //database1.Add(new UserInfo(Name: "Alex", Age: 26));
                //database1.Add(new UserInfo(Name: "Donald", Age: 28));
                //database1.Add(new UserInfo(Name: "Mishel", Age: 50));

                //database1.ReWrite();
            }

            //Constraints_2
            {
                //UI user1 = new UI(Name: "Alexandr", Age: 26);
                //UserInfo<UI> user = new UserInfo<UI>(user1);
            }

            //Default
            {
                //Class1<string> a = new Class1<string>();
                //Class1<int> b = new Class1<int>();

                //if (a.SomeField == null)
                //    Console.WriteLine("a.obj = null");

                //if (b.SomeField == 0)
                //    Console.WriteLine("b.obj = 0");
            }

            //Static field
            {
                //StaticDemo<string>.x = 4;
                //StaticDemo<int>.x = 5;
                //Console.WriteLine(StaticDemo<string>.x);
                //Console.WriteLine(StaticDemo<int>.x);
            }

            //Nullable
            {
                //int a = null;
                //Console.WriteLine($"a = {a}");
                //if (!a.HasValue)
                //    a = 5;

                //Console.WriteLine($"a = {a.Value}");

                //Nullable<int> x = default;
                ////x = 4;

                //Console.WriteLine($"x = {x}");
                //if (!x.HasValue)
                //    x = 5;

                //Console.WriteLine($"x = {x.Value}");

                //Console.ReadLine();
            }

            Console.ReadLine();
        }
    }

    public class StaticDemo<T>
    {
        public static int x;
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
// ReciveMessage(IMessage msg)


// Server
// GetMessage
// NotifyAll(IMessage msg)
// NotifyAll(Client, IMessage msg)
// List of Clients


