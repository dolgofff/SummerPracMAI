using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask2
{
    public class MyEqualityComparer<T> : IEqualityComparer<T>
    {
        //Default - автоматически сгенерированный компаратор для <T>
        public bool Equals(T? x, T? y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }

        public int GetHashCode(T? obj)
        {
            return EqualityComparer<T>.Default.GetHashCode(obj);
        }
    }
}
