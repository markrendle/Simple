﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple
{
    public static class BufferedEnumerable
    {
        public static IEnumerable<T> Create<T>(Func<Tuple<bool, T>> iterator)
        {
            var enumerable = new BufferedEnumerable<T>();
            Task.Factory.StartNew(() => enumerable.Iterate(iterator));
            return enumerable;
        }

        public static IEnumerable<T> Create<T>(Func<Tuple<bool, T>> iterator, Action cleanup)
        {
            var enumerable = new BufferedEnumerable<T>();
            var task = new Task(() => enumerable.Iterate(iterator));
            task.ContinueWith(t => cleanup());
            task.Start();
            return enumerable;
        }
    }
}