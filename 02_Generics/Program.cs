using System;

namespace _02_Generics
{
    class MyObj<T>
    {
        T obj;

        public MyObj(T obj)
        {
            this.obj = obj;
        }

        public void objectType()
        {
            Console.WriteLine("Object type: " + typeof(T));
        }
    }

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

        public void objectsType()
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
                //MyObj<int> obj1 = new MyObj<int>(25);
                //obj1.objectType();

                //MyObjects<string, byte, decimal> obj2 = new MyObjects<string, byte, decimal>("John", 26, 12.423m);
                //obj2.objectsType();
            }

            //Constraints
            {
                //Info<FamilyInfoUser> database1 = new Info<FamilyInfoUser>();
                //database1.Add(new FamilyInfoUser(Name: "Alex", Family: "Smith", Age: 26));
                //database1.Add(new FamilyInfoUser(Name: "Donald", Family: "Johnson", Age: 28));
                //database1.Add(new FamilyInfoUser(Name: "Mishel", Family: "Obama", Age: 50));

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
                Nullable<int> x;
                x = 4;

                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }

    public class StaticDemo<T>
    {
        public static int x;
    }
}
