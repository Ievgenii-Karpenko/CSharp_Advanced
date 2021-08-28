using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace _07_2_JSonSerializer
{
    public class Company
    {
        public int Age { get; set; }
    }

    class Person
    {
        public List<Company> data = new List<Company>();

        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    //IgnoreNullValues = true,
                    //NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };

                Person tom = new Person() { Name = "Tom" };
                tom.data.Add(new Company() { Age = 15 });
                tom.data.Add(new Company() { Age = 57 });

                //Dictionary<int, Company> data = new Dictionary<int, Company>();
                //data.Add(2, new Company() { Age = 25});
                //data.Add(7, new Company() { Age = 32 });


                string json = JsonSerializer.Serialize(tom, options);
                // 
                //string json = "{\"firstname\":\"Tom\",\"Age\":\"35\"}";

                Console.WriteLine(json);

                Person restoredPerson = JsonSerializer.Deserialize<Person>(json, options);
                //Console.WriteLine(restoredPerson.Name);
            }

            // Async
            //{
            //    using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //    {
            //        Person tom = new Person() { Name = "Tom", Age = 35 };
            //        Task a = JsonSerializer.SerializeAsync<Person>(fs, tom);
            //        Console.WriteLine("Data has been saved to file");
            //    }

            //    // Read
            //    using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //    {
            //        Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
            //        Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            //    }
            //}

            //using of attributes 
            //[JsonPropertyName("firstname")]
            //[JsonIgnore]
            //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            //JsonSerializerOptions options = new()
            //{
            //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            //};



        }
    }
}
