using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    using System;

    namespace ClassLibrary1
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            private int myInt; // private fields are ignored

            //public Company Company { get; set; }

            // we need default c-tor for work
            public Person()
            { }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void SetMyInt(int val)
            {
                myInt = val;
            }
        }
    }

}
