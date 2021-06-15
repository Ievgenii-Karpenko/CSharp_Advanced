//#define EXPERIMENTAL
#define MY_DIRECTIVE
#undef DEBUG
#undef MY_DIRECTIVE

//#pragma warning disable 0219

using Printer = System.Console;
using static System.Math;


//#define EXPERIMENTAL

namespace _08_Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.WriteLine("Hello World!");
            #line 100
            int a = 12;
            #line default
            int b = 12;

            var res = Pow(2, 4);
            System.Console.WriteLine("2^4 = " + res);
            Printer.Write("Pi = " + PI);


            var myObj = new Foo.Boo.Baz();

            var myObj2 = new Foo.Baz();

#if !MY_DIRECTIVE
//#error "We had an error"
#endif

#warning Warn!!!



#if EXPERIMENTAL
            Printer.WriteLine("Inside EXPERIMENTAL");
#elif !EXPERIMENTAL
            Printer.WriteLine("NOT Inside EXPERIMENTAL");
#endif

        }
    }
}

namespace Foo
{
    namespace Boo
    {
        class Baz
        {

        }
    }

    class Baz
    {

    }
}
