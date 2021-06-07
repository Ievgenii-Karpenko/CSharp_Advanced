using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace _07_2_JSonSerializer
{
    class Person
    {
        [JsonPropertyName("firstname")]
        public string Name { get; set; }

        public int Age { get; set; }


        public string BossName { get; set; }

        public float Fl { get; set; }

        public Person() {} 
        public Person(string name, int age, string boss) => (Name, Age, BossName) = (name, age, boss);
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // 1
            {
                System.Globalization.NumberFormatInfo s = new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "_" };
                CultureInfo culture2 = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
                culture2.NumberFormat = s;

                Thread.CurrentThread.CurrentCulture = culture2;

                int a;
                int b;

                (a, b) = (123, 123);




                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IgnoreNullValues = true,
                    //NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };

                Person tom = new Person { Name = "Tom", Age = 35, Fl = 123.456789f };
                
                string json = JsonSerializer.Serialize(tom, options);
                // 
                //string json = "{\"firstname\":\"Tom\",\"Age\":\"35\"}";

                Console.WriteLine(json);

                Person restoredPerson = JsonSerializer.Deserialize<Person>(json, options);
                Console.WriteLine(restoredPerson.Name);
            }

            // Async
            {
                //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                //{
                //    Person tom = new Person() { Name = "Tom", Age = 35 };
                //    Task a = JsonSerializer.SerializeAsync<Person>(fs, tom);
                //    Console.WriteLine("Data has been saved to file");
                //}

                //// Read
                //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                //{
                //    Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                //    Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
                //}
            }

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
