using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06_3_EFCore_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 36, Company = microsoft };
                User bob = new User { Name = "Bob", Age = 39, Company = google };
                User alice = new User { Name = "Alice", Age = 28, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 25, Company = google };

                db.Users.AddRange(tom, bob, alice, kate);
                db.SaveChanges();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                //var users = db.Users.Include(p=>p.Company).Where(p=> p.CompanyId == 1);
                var users = (from user in db.Users.Include(p => p.Company)
                             where user.CompanyId == 1
                             select user).ToList();  //.ToListAsync();

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company.Name}");

                //SELECT[p].[Id], [p].[CompanyId], [p].[Name], [p].[Age], [c].[Id], [c].[Name]
                //FROM[Users] AS[p]
                //INNER JOIN[Companies] AS[c] ON[p].[CompanyId] = [c].[Id]
                //WHERE[p].[CompanyId] = 1
            }

            //Like statements
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.Where(p => EF.Functions.Like(p.Name, "%Tom%"));
                    foreach (User user in users)
                        Console.WriteLine($"{user.Name} ({user.Age})");

                    //IQueryable<User> a = db.Users.FromSqlRaw("SELECT * FROM Users").Where(f => asdas);
                }

                // %: соответствует любой подстроке, которая может иметь любое количество символов, при этом подстрока может и не содержать ни одного символа
                // _: соответствует любому одиночному символу
                // []: соответствует одному символу, который указан в квадратных скобках
                // [- ]: соответствует одному символу из определенного диапазона
                // [^ ]: соответствует одному символу, который не указан после символа ^

                //var users = db.Users.Where(u => EF.Functions.Like(u.Age.ToString(), "2[2-9]"));
            }

            //Join
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = from u in db.Users
                                join c in db.Companies on u.CompanyId equals c.Id
                                select new { Name = u.Name, Company = c.Name, Age = u.Age };

                    foreach (var u in users)
                        Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
                }
            }
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
