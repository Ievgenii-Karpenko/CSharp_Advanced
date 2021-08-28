using _01_Collections;

namespace _02_Generics
{
    class Class1<T>
    {
        public T SomeField;

        public Class1()
        {
            //someField = null;
            //someField = 0;
            SomeField = default;

            //if (SomeField.GetType() == typeof(int))
            //{ 
            //    // SomeField = 18; can be set via reflection
            //}

        }
    }

    // Унаследованный обобщенный класс
    class Class2_1<T> : Class1<T>
    { 

    }

    // Ещё один унаследованный класс с собственными параметрами
    class Class2_2<T, V> : Class1<T>
    {
        public V vObj;
    }

    class Class3<T, V, E, G> : Class2_2<T, V>
    { }

    // Обычный необобщенный класс
    class SomeClass
    { }

    // Унаследованный от обычного класса обобщенный класс
    class ObClass<T> : SomeClass
    { }
}
