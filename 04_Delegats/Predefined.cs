using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Delegats
{
    class ArrSort
    {
        // Реализуем обобщенный метод сортировки
        public static void Sort<T>(IList<T> sortArray, Func<T, T, bool> res)
        {
            bool mySort = true;
            do
            {
                mySort = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (res(sortArray[i + 1], sortArray[i]))
                    {
                        T j = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = j;
                        mySort = true;
                    }
                }
            } while (mySort);
        }
    }

    class UserInfo
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public decimal Salary { get; private set; }

        public UserInfo(string Name, string Family, decimal Salary)
        {
            this.Name = Name;
            this.Family = Family;
            this.Salary = Salary;
        }

        // Переопределим метод ToString
        public override string ToString()
        {
            return $"{Name} {Family}, {Salary, 2:C}";
        }

        // Данный метод введен для соответствия сигнатуре 
        // делегата Func
        public static bool UserSalary(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Salary < obj2.Salary;
        }

        public static int UserName(UserInfo obj1, UserInfo obj2)
        {
            return obj1.Name.CompareTo(obj2.Name);
        }

        public static bool UserExist(UserInfo obj)
        {
            return obj.Name == "Jeff";
        }
    }
}
