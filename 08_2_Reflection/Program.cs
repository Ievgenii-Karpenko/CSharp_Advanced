using System;
using System.Reflection;

namespace _08_2_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 variant to get type info
            Type myType = typeof(User);

            Console.WriteLine(myType.ToString());

            // 2 variant to get type info
            User user = new User("Tom", 30);
            Type myType2 = user.GetType();

            // 3 variant to get type info
            Type myType3 = Type.GetType("_08_2_Reflection.User", false, true);

            //MemberInfo
            //{
            //    foreach (MemberInfo mi in myType.GetMembers())
            //    {
            //        Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
            //    }
            //    Console.WriteLine();
            //}

            //Methods
            {
                //Console.WriteLine("Methods:");
                //foreach (MethodInfo method in myType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)) 
                //{
                //    string modificator = "";
                //    if (method.IsStatic)
                //        modificator += "static ";
                //    if (method.IsVirtual)
                //        modificator += "virtual";
                //    Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");

                //    //get all params
                //    ParameterInfo[] parameters = method.GetParameters();
                //    for (int i = 0; i < parameters.Length; i++)
                //    {
                //        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                //        if (i + 1 < parameters.Length) Console.Write(", ");
                //    }
                //    Console.WriteLine(")");
                //}
                //Console.WriteLine();
                // Let's configure methods info
                // BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
            }

            //C-tors
            //{
            ////    Console.WriteLine("C-tors:");
            ////    foreach (ConstructorInfo ctor in myType.GetConstructors())
            ////    {
            ////        Console.Write(myType.Name + " (");
            ////        ParameterInfo[] parameters = ctor.GetParameters();
            ////        for (int i = 0; i < parameters.Length; i++)
            ////        {
            ////            Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
            ////            if (i + 1 < parameters.Length) Console.Write(", ");
            ////        }
            ////        Console.WriteLine(")");
            ////    }
            ////    Console.WriteLine();
            ////}

            ////Fields and properties
            ////{
            ////    Console.WriteLine("Fields:");
            ////    foreach (FieldInfo field in myType.GetFields())
            ////    {
            ////        Console.WriteLine($"{field.FieldType} {field.Name}");
            ////    }

            ////    Console.WriteLine("Properties:");
            ////    foreach (PropertyInfo prop in myType.GetProperties())
            ////    {
            ////        Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            ////    }
            ////    Console.WriteLine();
            ////}

            ////Get list of implemented interfaces
            ////{
            ////    Console.WriteLine("interfaces:");
            ////    foreach (Type i in myType.GetInterfaces())
            ////    {
            ////        Console.WriteLine(i.Name);
            ////    }
            ////    Console.WriteLine();
            ////}

            //Dynamic loading of assemblies
            //{
            //    Assembly asm = Assembly.LoadFrom("ClassLibrary2.dll");

            //    Console.WriteLine(asm.FullName);
            //    // Get all types from MyApp.dll
            //    Type[] types = asm.GetTypes();
            //    foreach (Type t in types)
            //    {
            //        Console.WriteLine(t.Name);
            //    }
            //}

            //Invoke 
            {
                try
                {
                    Assembly asm = Assembly.LoadFrom("ClassLibrary2.dll");

                    Type t = asm.GetType("ClassLibrary2.ClassLibrary1.Person", true, true);

                    // Create instance of Person
                    object obj = Activator.CreateInstance(t);

                    // Get method Sum
                    MethodInfo method = t.GetMethod("Sum");

                    // call method and get result
                    object result = method.Invoke(obj, new object[] { 6, 2 });
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int Year;
        public User(string n, int a)
        {
            Name = n;
            Age = a;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}  Age: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }

        public static string GetClassName()
        {
            return "User";
        }
    }
}
