using System;

namespace _04_Delegats
{
    delegate int IntOperation(int i, int j);

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

            { 
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
            }

            //Grouping
            {
                //int[] myArr = new int[6] { 2, -4, 10, 5, -6, 9 };

                //// Структуируем делегаты
                //OpStroke MyDelegate;
                //OpStroke Wr = ArrayOperations.WriteArray;
                //OpStroke OnSortArr = ArrayOperations.IncrementSort;
                //OpStroke OffSortArr = ArrayOperations.DecrementSort;
                //OpStroke ChArr = ArrayOperations.ChetArr;
                //OpStroke NeChArr = ArrayOperations.NeChetArr;

                //// Групповая адресация
                //MyDelegate = Wr;
                //MyDelegate += OnSortArr;
                //MyDelegate += ChArr;
                //MyDelegate += OffSortArr;
                //MyDelegate += NeChArr;

                ////MyDelegate = ArrayOperations.WriteArray;
                ////MyDelegate += ArrayOperations.IncrementSort;
                ////MyDelegate += ArrayOperations.DecrementSort;
                ////MyDelegate += ArrayOperations.ChetArr;
                ////MyDelegate += ArrayOperations.NeChetArr;


                //// Выполняем делегат
                //MyDelegate(ref myArr);
            }

            //Action, Func
            {
                //UserInfo[] userinfo = { new UserInfo("Jeff","Bezos",50000000000),
                //                  new UserInfo("Alex","Smith",100),
                //                  new UserInfo("John","Colborn",40000),
                //                  new UserInfo("Wiley","Coyote",1000000)};

                //Func<UserInfo, UserInfo, bool> MyFunc = UserInfo.UserSalary;
                //ArrSort.Sort(userinfo, MyFunc);

                //Console.WriteLine("Sort users by revenu: \n" +
                //    "-------------------------------------\n");
                //foreach (var ui in userinfo)
                //    Console.WriteLine(ui);
            }

            //Anonymous methods
            {
                //int res
                //Sum del = delegate (int number)
                //{
                //    for (int i = 0; i <= number; i++)
                //        result += i;
                //    return result;
                //};


            }

            Console.ReadLine();
        }

        delegate void OpStroke(ref int[] arr);
        delegate int Sum(int number);
    }
}
