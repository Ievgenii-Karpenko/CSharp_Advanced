using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _06_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
                //user1.Languages = new List<Languages>() { new ("en"), new("uk"), new("ru")};
                //user2.Languages = new List<Languages>() { new("en"), new("fr"), new("it") };
                //user1.Company = new Company() { Name = "Microsoft" };
                //user2.Company = new Company() { Name = "Intel" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            //For connecting to existing db open Package Manager Console
            //Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer

            //CRRUD operations
            {
                // Добавление
                using (ApplicationContext db = new ApplicationContext())
                {
                    User user1 = new User { Name = "Tom", Age = 33 };
                    User user2 = new User { Name = "Alice", Age = 26 };

                    // Добавление
                    db.Users.Add(user1);
                    db.Users.Add(user2);
                    //db.SaveChanges();
                }

                //// получение
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var users = db.Users.ToList();
                    Console.WriteLine("Данные после добавления:");
                    foreach (User u in users)
                    {
                        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                    }
                }


                //User user;
                ////// Редактирование
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем первый объект
                    var user = db.Users.FirstOrDefault();
                    if (user != null)
                    {
                        user.Name = "Bob";
                        user.Age = 44;
                        //обновляем объект
                        //db.Users.Update(user);
                        db.SaveChanges();
                    }
                }

                //using (ApplicationContext db = new ApplicationContext())
                //{
                //    db.SaveChanges();
                //    // выводим данные после обновления
                //    Console.WriteLine("\nДанные после редактирования:");
                //    var users = db.Users.ToList();
                //    foreach (User u in users)
                //    {
                //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //    }
                //}

                //// Удаление
                //using (ApplicationContext db = new ApplicationContext())
                //{
                //    // получаем первый объект
                //    User user = db.Users.FirstOrDefault();
                //    if (user != null)
                //    {
                //        //удаляем объект
                //        db.Users.Remove(user);
                //        db.SaveChanges();
                //    }
                //    // выводим данные после обновления
                //    Console.WriteLine("\nДанные после удаления:");
                //    var users = db.Users.ToList();
                //    foreach (User u in users)
                //    {
                //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //    }
                //}
            }

        }
    }

    //[DisplayColumn("asdads")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Age { get; set; }
        //public Company Company { get; set; }

        //public List<Languages> Languages { get; set; }
    }

    public class Company
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }

    //public class Languages
    //{
    //    public Languages(string name)
    //    {
    //        Name = name;
    //    }
    //    public int UserId { get; set; }
    //    public string Name { get; set; }
    //}

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("UserId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFdb2;Trusted_Connection=True;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
