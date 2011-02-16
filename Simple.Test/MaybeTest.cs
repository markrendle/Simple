using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Simple.Test
{
    public class MaybeTest
    {
        [Fact]
        public void MaybeNoneShouldBeFalse()
        {
            Assert.False(Maybe<int>.None);
        }

        [Fact]
        public void MaybeSomeShouldBeTrue()
        {
            Assert.True(Maybe<int>.Some(1));
        }

        [Fact]
        public void IteratorShouldRun()
        {
            int n = 0;
            Func<Maybe<int>> iterator = () => ++n < 10 ? n : Maybe<int>.None;
            Maybe<int> maybe;
            while (maybe = iterator())
            {
                Assert.Equal(maybe, n);
            }
            Assert.False(maybe);
        }
    }
}
