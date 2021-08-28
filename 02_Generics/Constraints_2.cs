using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics
{
    class UI
    {
        public UI(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public string Name;
        public int Age;
    }

    // Обобщенный класс, использующий ограничение на тип значения
    struct UserInfo2<T> where T : class
    {
        T obj;

        public UserInfo2(T ob)
        {
            obj = ob;
        }
    }
}
