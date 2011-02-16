﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple
{
    public static class EnumerableEx
    {
        public static Func<Maybe<T>> ToIterator<T>(this IEnumerable<T> source)
        {
            var enumerator = source.GetEnumerator();
            return
                () => enumerator.MoveNext() ? enumerator.Current : Maybe<T>.None;
        }
    }
}
