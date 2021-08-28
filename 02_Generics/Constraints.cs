using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics
{
    public class UserInfo
    {
        public UserInfo(string Name, int Age) 
        {
            this.Name = Name;
            this.Age = Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"User info: \n{Name} {Age}\n";
    }

    internal class User
    {
        public User(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"User info: \n{Name} {Age}\n";
    }

    // Создадим класс, унаследованный от UserInfo
    class FamilyInfoUser : UserInfo
    {
        public FamilyInfoUser(string Family, string Name, int Age)
            : base(Name, Age)
        {
            this.Family = Family;
        }

        public string Family { get; set; }

        public override string ToString() => $"User info: \n{Name} {Family} {Age}\n";
    }

    // Обобщенный класс использующий ограничение на базовый класс
    class Info<T> where T : UserInfo
    {
        T[] UserList;
        int i;

        public Info()
        {
            UserList = new T[6];
            i = 0;
        }

        public void Add(T obj)
        {
            UserList[i] = obj;
            i++;
        }

        public void ReWrite()
        {
            foreach (T t in UserList)
                Console.WriteLine(t.ToString());
        }
    }
}
