using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom", 29);
            person.SetMyInt(255);
            person.Co = new Company("Google");

            // provide type for serialization to c-tor
            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("persons.xml", FileMode.Create))
            {
                formatter.Serialize(fs, person);
            }

            // Deserialize
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine($"Name: {newPerson.Name} --- Age: {newPerson.Age}");
            }

            //Annotattions
            {
                //[XmlRoot("PurchaseOrder", Namespace="http://www.cpandl.com",
                //IsNullable = false)]
            }
            Console.ReadLine();
        }
    }

    [XmlRoot("PurchaseOrder", Namespace="http://www.cpandl.com")]
    [Serializable] // Set this attribute to allow xml serialization for this type
    public class Person
    {
        private string n;

        [XmlAttribute("PersonName")]
        public string Name { get => n; set => n = value; }
        //[Xm]
        public int Age { get; set; }

        [XmlIgnore]
        public int myInt; // private fields are ignored

        public Company Co { get; set; }

        // we need default c-tor for work
        public Person()
        { }

        public Person(string name, int age)
        {
            n = name;
            Age = age;
        }

        public void SetMyInt(int val)
        {
            myInt = val;
        }
    }

    [Serializable]
    public class Company
    {
        public string Name { get; set; }

        public Company() { }

        public Company(string name)
        {
            Name = name;
        }
    }
}