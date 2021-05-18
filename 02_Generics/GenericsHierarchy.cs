namespace _02_Generics
{
    class Class1<T>
    {
        public T SomeField;

        public Class1()
        {
            //someField = null;
            //someField = 0;
            SomeField = default(T);
        }
    }

    // Унаследованный обобщенный класс
    class Class2_1<T> : Class1<T>
    { }

    // Ещё один унаследованный класс с собственными параметрами
    class Class2_2<T, V> : Class1<T>
    { }

    class Class3<T, V, E, G> : Class2_2<T, V>
    { }

    // Обычный необобщенный класс
    class SomeClass
    { }

    // Унаследованный от обычного класса обобщенный класс
    class ObClass<T> : SomeClass
    { }
}
