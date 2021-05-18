using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Generics
{
    public struct Nullable<T> where T : struct
    {
        public Nullable(T value)
        {
            HasValue = true;
            this.value = value;
        }

        public bool HasValue { get; private set; }
        
        private T value;
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Value not set");
                }
                return value;
            }
        }
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }

        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }

        public override string ToString()
        {
            return HasValue ? value.ToString() : string.Empty;
        }
    }
}
