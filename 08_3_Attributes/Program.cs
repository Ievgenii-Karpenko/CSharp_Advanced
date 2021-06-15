using System;

namespace _08_3_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User("Tom", 35);
            User bob = new User("Bob", 16);
            bool tomIsValid = ValidateUser(tom);    // true
            bool bobIsValid = ValidateUser(bob);    // false

            Console.WriteLine($"Validation result for Tom: {tomIsValid}");
            Console.WriteLine($"Validation result for Bob: {bobIsValid}");


            // Restrictions
            //[AttributeUsage(AttributeTargets.Class)]
        }
        static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (Attribute attr in attrs)
            {
                if (attr is AgeValidationAttribute ageAttr)
                { 
                    if (user.Age >= ageAttr.Age) 
                        return true;
                    else 
                        return false;
                }
            }
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        { }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }

    [AgeValidation(18)]
    public class User
    {

        //[AgeValidation(18)]
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
    }
}
