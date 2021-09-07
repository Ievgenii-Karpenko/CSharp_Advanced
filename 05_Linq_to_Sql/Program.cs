using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05_Linq_to_Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ievgenii\Documents\NewDatabase.mdf;Integrated Security=True;Connect Timeout=30";

            DataContext db = new DataContext(connectionString);

            // Дістаємо дані з таблиці користувачів
            Table<User2> users = db.GetTable<User2>();
            //foreach (var user in users)
            //{
            //    Console.WriteLine($"{user.Id} \t{user.UserName} \t{user.Age}");
            //}

            //// Фільтрація в запиті
            //// 
            IQueryable<User> query = from u in db.GetTable<User>()
                                     where u.Age > 25
                                     //orderby u.Name
                                     select u;

            //// або так
            //query = db.GetTable<User>().Where(u => u.Age > 25).OrderBy(u => u.UserName);
            //foreach (var user in query)
            //{
            //    Console.WriteLine($"{user.Id} \t{user.UserName} \t{user.Age}");
            //}

            // даний запит сформує SQL вираз
            // SELECT[t0].[Id], [t0].[Name] AS[FirstName], [t0].[Age]
            // FROM[Users] AS[t0]
            // WHERE[t0].[Age] > 25
            // ORDER BY[t0].[Name]

            // Змінимо об"єкт в таблиці
            //Array.ForEach<User>(users, u => u.Age = 28);
            //var user1 = users.FirstOrDefault(i => i.UserName == "Donald");
            //user1.Age = 28;

            var newUser = new User2() { UserName = "Roman100", Id = 100};
            users.InsertOnSubmit(newUser);

            // оновимо дані в БД
            db.SubmitChanges();
        }
    }

    [Table(Name = "Users")]
    public class User
    {
        [Column(Name="Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string UserName { get; set; }

        [Column]
        public int Age { get; set; }
    }

    [Table(Name = "User2")]
    public class User2
    {
        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string UserName { get; set; }
    }
}
