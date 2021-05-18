using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics
{
    struct UI
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
    class UserInfo<T> where T : struct
    {
        T obj;

        public UserInfo(T ob)
        {
            obj = ob;
        }
    }
}
