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
            Table<User> users = db.GetTable<User>();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} \t{user.Name} \t{user.Age}");
            }

            // Фільтрація в запиті
            var query = from u in db.GetTable<User>()
                        where u.Age > 25
                        orderby u.Name
                        select u;
            // або так
            // var query = db.GetTable<User>().Where(u => u.Age > 25).OrderBy(u => u.FirstName);
            foreach (var user in query)
            {
                Console.WriteLine($"{user.Id} \t{user.Name} \t{user.Age}");
            }

            // даний запит сформує SQL вираз
            // SELECT[t0].[Id], [t0].[Name] AS[FirstName], [t0].[Age]
            // FROM[Users] AS[t0]
            // WHERE[t0].[Age] > 25
            // ORDER BY[t0].[Name]

            // Змінимо об"єкт в таблиці
            users.First().Age = 28;
            // оновимо дані в БД
            db.SubmitChanges();
        }
    }

    [Table(Name = "Users")]
    public class User
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column]
        public int Age { get; set; }
    }
}
