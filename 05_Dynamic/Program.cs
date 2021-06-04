using System;
using System.Collections.Generic;

namespace _05_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dynamic variables
            { 
                object x = 3; // тут x - це int
                Console.WriteLine(x);

                x = "Hello World"; // x змінює свій тип на string
                Console.WriteLine(x);

                x = new Person() { Name = "Tom", Age = 23 }; // x - об'єкт типу Person
                Console.WriteLine(x);
            }

            {
                object obj = 24;
                dynamic dyn = 24;
                //obj += 4; // заборонена операція
                dyn += 4; // дозволена
            }

            // Dynamic members
            {
                dynamic person1 = new Worker() { Name = "Tom", Age = 27 };
                Console.WriteLine(person1);

                //person1 = 234;
                Console.WriteLine(person1.getSalary(28.09, "int"));

                dynamic person2 = new Worker() { Name = "John", Age = "Twenty six years" };
                Console.WriteLine(person2);
                Console.WriteLine(person2.getSalary(30, "string"));
            }

            //ExpandoObject
            {
                dynamic viewbag = new System.Dynamic.ExpandoObject();
                viewbag.Name = "Tom";
                viewbag.Age = 46;
                viewbag.Languages = new List<string> { "english", "german", "french" };
                Console.WriteLine($"{viewbag.Name} - {viewbag.Age}");
                foreach (var lang in viewbag.Languages)
                    Console.WriteLine(lang);

                // объявляем метод
                viewbag.IncrementAge = (Action<int>)(x => viewbag.Age += x);

                viewbag.IncrementAge(6); // увеличиваем возраст на 6 лет

                Console.WriteLine($"{viewbag.Name} - {viewbag.Age}");
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }

    class Worker
    {
        public string Name { get; set; }
        public dynamic Age { get; set; }

        // виводимо зарплату в залежності від формату
        public dynamic getSalary(dynamic value, string type)
        {
            switch (type)
            {
                case "int":
                    return value + " $";
                case "string":
                    return value;
                default:
                    return 0.0;
            }
        }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }
}
