using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _07_Serializing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Binary serialization [obsolete from .net 5]
            {
                // Object to serialize
                Person person = new Person("Tom", 29, "12345678");
                person.SetStr("aaaa");
                person.Langs.Add("En");
                person.Langs.Add("Ru");
                person.Co = new Company() { Name = "Adidas" };

                // create BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();
                // get file stram to write our object
                try
                {
                    using (FileStream fs = new FileStream("people.dat", FileMode.Create))
                    {
                        formatter.Serialize(fs, person);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                

                // deserialize from people.dat
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    Person newPerson = (Person)formatter.Deserialize(fs);

                    Console.WriteLine("Deserialize");
                    Console.WriteLine($"Name: {newPerson.Name} --- Year: {newPerson.Year} --- Acc: {newPerson.accNumber}");
                }
            }
        }
    }

    [Serializable]
    public class Company
    {
        public string Name { get; set; }
    }


    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Company Co { get; set; }

        public List<string> Langs = new List<string>();
       
        private string str;

        [NonSerialized]
        public string accNumber;

        public Person(string name, int year, string acc)
        {
            Name = name;
            Year = year;
            accNumber = acc;
        }

        public void SetStr(string val)
        {
            str = val;
        }
    }
}
