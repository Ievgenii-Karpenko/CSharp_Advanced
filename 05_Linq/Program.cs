using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // General
            {
                string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
                {
                    var selectedTeams = new List<string>();
                    foreach (string s in teams)
                    {
                        if (s.ToUpper().StartsWith("Б"))
                            selectedTeams.Add(s);
                    }
                    selectedTeams.Sort();

                    foreach (string s in selectedTeams)
                        Console.WriteLine(s);
                }

                Console.WriteLine("-----------------------------------------------------------------------");
                {
                    var selectedTeams = from t in teams // определяем каждый объект из teams как t
                                        where t.StartsWith("Б", StringComparison.InvariantCultureIgnoreCase) //фильтрация по критерию
                                        orderby t descending // упорядочиваем по возрастанию
                                        select t; // выбираем объект

                    foreach (string s in selectedTeams)
                        Console.WriteLine(s);
                }

                // Linq with help of extension methods
                Console.WriteLine("-----------------------------------------------------------------------");
                {
                    var selectedTeams = teams.Where(t => t.ToUpper().StartsWith("Б"))
                                             .OrderBy(t => t);

                    foreach (string s in selectedTeams)
                        Console.WriteLine(s);
                }

                // Combined way
                int number = (from t in teams where t.ToUpper().StartsWith("Б") select t).Count();
            }

            // Filtering
            {
                int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

                IEnumerable<int> evens = from i in numbers
                                         where i % 2 == 0 && i > 10  // filter
                                         select i;

                foreach (int i in evens)
                    Console.WriteLine(i);

                // Same with extension methods
                Console.WriteLine("Filtering with extension methods:");
                IEnumerable<int> evens2 = numbers.Where(i => i % 2 == 0 && i > 10);

                //var a = evens2[2];
                foreach (int i in evens2)
                    Console.WriteLine(i);
            }

            // Filtering of objects
            {
                List<User> users = new List<User>
                {
                    new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                    new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                    new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                    new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
                };

                IEnumerable<User> selectedUsers = from user in users
                                                  where user.Age > 25
                                                  select user;

                // Same:
                // var selectedUsers = users.Where(u=> u.Age > 25);

                Console.WriteLine("Users with Age > 25");
                foreach (User user in selectedUsers)
                    Console.WriteLine($"{user.Name} - {user.Age}");

                // Comlex Filtering
                var selectedUsers2 = from user in users
                                     from lang in user.Languages
                                     where user.Age < 28
                                     where lang == "английский"
                                     select user;

                Console.WriteLine();
                Console.WriteLine("Users with Age < 28 and with english");
                foreach (User user in selectedUsers2)
                    Console.WriteLine($"{user.Name} - {user.Age}");

                var selectedUsersExt = users.SelectMany(u => u.Languages,
                            (u, l) => new { User = u, Lang = l })
                          .Where(u => u.Lang == "английский" && u.User.Age < 28)
                          .Select(u => u.User);

                Console.WriteLine();
                Console.WriteLine("Users with Age < 28 and with english (Extension methods):");
                foreach (User user in selectedUsersExt)
                    Console.WriteLine($"{user.Name} - {user.Age}");


                //Creating of new anonymous type
                PrintSeparator();
                //var items = from u in users
                //            select new
                //            {
                //                FirstName = u.Name,
                //                DateOfBirth = DateTime.Now.Year - u.Age
                //            };
                //Same with extensions
                var items = users.Select(u => new
                {
                    FirstName = u.Name,
                    DateOfBirth = DateTime.Now.Year - u.Age
                });

                foreach (var n in items)
                    Console.WriteLine($"{n.FirstName} - {n.DateOfBirth}");
            }

            //operator let
            {
                List<User> users = new List<User>()
                {
                    new User { Name = "Sam", Age = 43 },
                    new User { Name = "Tom", Age = 33 }
                };

                var people = from u in users
                             let name = "Mr. " + u.Name // helps to create temp variable
                             select new User()
                             {
                                 Name = name,
                                 Age = u.Age
                             };

                foreach (var user in people)
                {
                    var anonType = user.GetType().Name;
                    Console.WriteLine($"Type: {anonType} - {user.Name} - {user.Age}");
                }

            }

            //Selection from two sources
            {
                List<User> users = new List<User>()
                {
                    new User { Name = "Sam", Age = 25 },
                    new User { Name = "Tom", Age = 34 }
                };
                List<Phone> phones = new List<Phone>()
                {
                    new Phone {Name="Galaxy", Company="Samsung" },
                    new Phone {Name="iPhone X", Company="Apple"},
                };

                var people = from user in users
                             from phone in phones
                             select new { Name = user.Name, Phone = phone.Name };

                foreach (var p in people)
                    Console.WriteLine($"{p.Name} - {p.Phone}");
            }

            //Sorting
            {
                int[] numbers = { 3, 12, 4, 10, 34, 20, 55, -66, 77, 88, 4 };
                var orderedNumbers = from i in numbers
                                     orderby i // Оператор orderby приймає критерій сортування. У даному випадку в якості критерію виступає саме число. 
                                     select i;
                foreach (int i in orderedNumbers)
                    Console.WriteLine(i);

                PrintSeparator();

                List<User> users = new List<User>()
                {
                    new User { Name = "Tom", Age = 33 },
                    new User { Name = "Bob", Age = 30 },
                    new User { Name = "Tom", Age = 21 },
                    new User { Name = "Sam", Age = 43 }
                };

                //var sortedUsers = from u in users
                //                  orderby u.Name // Сортувати за полем об"єкту (за зростанням)
                //                  //orderby u.Name descending // Сортувати за полем об"єкту (за спаданням)
                //                  orderby u.Name, u.Age // Сортування за двома ознаками
                //                  select u;

                // аналогічне сортування через методи розширення
                var sortedUsers = users.OrderBy(u => u);
                //sortedUsers = users.OrderByDescending(u => u.Name);

                foreach (User u in sortedUsers)
                    Console.WriteLine(u.Name);

                PrintSeparator();
                // Сортування за двома ознаками через методи розширення
                var result = users.OrderBy(u => u.Name).ThenBy(u => u.Age);

                foreach (User u in sortedUsers)
                    Console.WriteLine(u.Name);
            }

            //Delegats for Linq
            {
                int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

                //Визначимо делегат для фільтрації елементів масиву
                Func<int, bool> MoreThanTen = delegate (int i) { return i > 10; };

                var result = numbers.Where(MoreThanTen); //Передаємо деоегат в якості параметру для Where
                //var result = numbers.Where(MoreThanTenMethod); // У якості параметру також можна передавати метод

                foreach (int i in result)
                    Console.WriteLine(i);

                PrintSeparator();

                int[] numbersF = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };

                var resultF = numbersF.Where(i => i > 0).Select(Factorial); //Метод Select як параметр приймає тип Func<TSource, TResult> selector.

                foreach (int i in resultF)
                    Console.WriteLine(i);
            }

            //Linq sets interface
            {
                string[] soft = { "Microsoft", "Google", "Apple" };
                string[] hard = { "Apple", "IBM", "Samsung" };

                // різниця наборів
                var result = soft.Except(hard);
                //result = soft.Union(hard);
                //result = soft.Intersect(hard);

                foreach (string s in result)
                    Console.WriteLine(s);

            }

            //Grouping
            {
                List<Phone> phones = new List<Phone>
                {
                    new Phone {Name="Lumia 430", Company="Microsoft" },
                    new Phone {Name="Mi 5", Company="Xiaomi" },
                    new Phone {Name="LG G 3", Company="LG" },
                    new Phone {Name="iPhone 11", Company="Apple" },
                    new Phone {Name="Lumia 930", Company="Microsoft" },
                    new Phone {Name="iPhone 6", Company="Apple" },
                    new Phone {Name="Lumia 630", Company="Microsoft" },
                    new Phone {Name="LG G 4", Company="LG" }
                };

                var phoneGroups = from phone in phones
                                  group phone by phone.Company;

                foreach (IGrouping<string, Phone> g in phoneGroups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var t in g)
                        Console.WriteLine(t.Name);
                    Console.WriteLine();
                }
            }

            //Different
            {
                List<int> numbers = new List<int>(){ 1, 2, 3, 4, 5 };

                var res = numbers.FirstOrDefault(i => i==10);

                //bool isAllMoreThanZero;
                //foreach (var item in collection)
                //{
                //    item
                //}

                IEnumerable<int> nn = numbers.Where(i => i > 3).ToList();

                numbers.Add(6);

                Console.WriteLine("Number of elemenmts > 3: " + nn.Count());

                int query = numbers.Aggregate((x, y) => x - y); // те ж саме, що і "1 - 2 - 3 - 4 - 5"

                int size = numbers.Count(i => i % 2 == 0 && i > 2); // підрахунок елементів за умовою

                decimal sum2 = numbers.Sum(); // Сумма елеметнів

                string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
                foreach (var t in teams.TakeWhile(x => x.StartsWith("Б"))) //SkipWhile
                    Console.WriteLine(t);
            }
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("\n----------------------------------------");
        }

        private static bool MoreThanTenMethod(int i)
        {
            return i > 10;
        }

        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
                result *= i;
            return result;
        }
    }

    class User : IComparable<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }

        public int CompareTo(User other)
        {
            return this.Age.CompareTo(other.Age);
        }
    }

    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
