using System.Collections;
using System.Collections.Generic;

namespace _01_Collections
{
    public class Students
    {
        public static IEnumerable<Student> GetStudents()
        {
            //List<Student> studs = new List<Student>();
            //studs.Add(new Student("A"));
            //studs.Add(new Student("B"));
            //studs.Add(new Student("C"));
            //studs.Add(new Student("D"));

            //return studs;

            yield return new Student("A");
            yield return new Student("B");
            yield return new Student("C");
            yield return new Student("D");
        }
    }



    class IntArr : IEnumerator, IEnumerable
    {
        int[] ints = { 12, 13, 1, 4 };
        int index = -1;

        // Реализуем интерфейс IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // Реализуем интерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == ints.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return ints[index];
            }
        }
    }
}

