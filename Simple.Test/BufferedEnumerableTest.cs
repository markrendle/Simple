using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Simple.Test
{
    public class BufferedEnumerableTest
    {
        [Fact(DisplayName = "Cleanup method should be called")]
        public void ShouldCallCleanup()
        {
            // Arrange
            bool cleanedUp = false;

            var list = BufferedEnumerable.Create("ABC".ToIterator(),() => cleanedUp = true)
                    .ToList();

            // Act
            Assert.Equal(3, list.Count);

            SpinWait.SpinUntil(() => cleanedUp, 1000);

            Assert.True(cleanedUp);
        }
    }
}
