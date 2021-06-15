using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Lesson
{
    public class Class1
    {
        public Class1()
        {
#if EXPERIMENTAL
            Console.WriteLine("Inside EXPERIMENTAL");
#elif !EXPERIMENTAL
            Console.WriteLine("NOT Inside EXPERIMENTAL");
#endif
        }
    }
}
