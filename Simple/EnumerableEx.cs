using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple
{
    public static class EnumerableEx
    {
        public static Func<Tuple<bool,T>> ToIterator<T>(this IEnumerable<T> source)
        {
            var enumerator = source.GetEnumerator();
            return
                () => enumerator.MoveNext() ? Tuple.Create(true, enumerator.Current) : Tuple.Create(false, default(T));
        }
    }
}
