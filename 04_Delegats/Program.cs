using System;

namespace _04_Delegats
{
    delegate int IntOperation(int i, int j);
    delegate void IntOperation2(int i, int j, float s);
    //int asd = 10;

    public class A
    {
        public int AINT = 10;
        public B bObj = null;

        public void DoSmthWithB()
        {
            Console.WriteLine(bObj.BINT);
            bObj.ShowInfoAboutA(this);
        }
    }


    public class B
    {
        public int BINT = 20;
        public void ShowInfoAboutA(A obj)
        {
            Console.WriteLine(obj.AINT);
        }
    }


    class Program
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static int Mult(int x, int y) => x * y;

        static int Devision(int x, int y) => x / y;

        static void Main()
        {
            A a = new A();
            B b = new B();

            b.ShowInfoAboutA(a);


            {
                //Delegate
                // Make delegate
                IntOperation op1 = new IntOperation(Sum);

                int result = op1(5, 10);
                Console.WriteLine("Sum: " + result);

                // Change delegate reference
                op1 = new IntOperation(Mult);
                result = op1(5, 10);
                Console.WriteLine("Multiplication: " + result);

                op1 = Devision; // Simplified way to change delegate reference
                result = op1(5, 10);
                Console.WriteLine("Devision: " + result);

                //Base type for all delegats:
                //MulticastDelegate
            }

            //Grouping
            {
                int[] myArr = new int[6] { 2, -4, 10, 5, -6, 9 };

                //Структуируем делегаты
                //OpStroke MyDelegate;
                //OpStroke Wr = ArrayOperations.WriteArray;
                //OpStroke OnSortArr = ArrayOperations.IncrementSort;
                //OpStroke OffSortArr = ArrayOperations.DecrementSort;
                //OpStroke ChArr = ArrayOperations.ChetArr;
                //OpStroke NeChArr = ArrayOperations.NeChetArr;

                ////// Групповая адресация
                //MyDelegate = Wr;
                //MyDelegate += OnSortArr;
                //MyDelegate += ChArr;
                //MyDelegate += OffSortArr;
                //MyDelegate += NeChArr;

                OpStroke MyDelegate = ArrayOperations.WriteArray;
                MyDelegate += ArrayOperations.IncrementSort;
                MyDelegate += ArrayOperations.DecrementSort;
                MyDelegate += ArrayOperations.ChetArr;
                MyDelegate += ArrayOperations.NeChetArr;
                // MyDelegate += Console.WriteLine; - getting error


                // Выполняем делегат
                MyDelegate(ref myArr);
            }

            //Action, Func
            {
                UserInfo[] userinfo = { new UserInfo("Jeff","Bezos",50000000000),
                                  new UserInfo("Alex","Smith",100),
                                  new UserInfo("John","Colborn",40000),
                                  new UserInfo("Wiley","Coyote",1000000)};

                Func<UserInfo, UserInfo, bool> MyFunc = UserInfo.UserSalary;
                Action<UserInfo, int> myAct = ShowUser;

                bool reac = MyFunc(userinfo[0], userinfo[1]);

                Predicate<UserInfo> myPredicate = UserInfo.UserExist;

                ArrSort.Sort(userinfo, UserInfo.UserSalary);
                ArrSort.Sort(userinfo, (obj1, obj2) => obj1.Salary < obj2.Salary);

                Array.Sort(userinfo, UserInfo.UserName);

                bool isJeffInside1 = Array.Exists(userinfo, myPredicate);
                bool isJeffInside2 = Array.Exists(userinfo, (o) => o.Name == "Jeff"); // lambda expression
                bool isJeffInside3 = Array.Exists(userinfo, (o) => 
                {
                    Console.WriteLine(o.Name);
                    return o.Name == "Jeff";
                }); // lambda method

                //Console.WriteLine("Sort users by revenu: \n" +
                //    "-------------------------------------\n");
                foreach (var ui in userinfo)
                {
                    //Console.WriteLine(ui);
                    myAct(ui, 10);
                }
            }

            //Anonymous methods
            Func<int, int> del;
            {
                int result = 0;
                //Summa del = new delegate (int n);
                del = (n) =>
                {
                    for (int i = 0; i <= n; i++)
                        result += i;
                    return result;
                };

                Console.WriteLine(del(10));
            }
            //del = anotherMethod;
            //Console.WriteLine(del(10));

            Console.ReadLine();
        }

        public static void ShowUser(UserInfo obj, int a)
        {
            Console.WriteLine(obj.Family);
        }

        delegate void OpStroke(ref int[] arr);
        //delegate int Summa(int number);
    }
}
