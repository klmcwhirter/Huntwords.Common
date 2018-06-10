using System.Linq;
using Xunit;
using Huntwords.Common.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Huntwords.Common.Services;

namespace Huntwords.Common.Tests
{
    public partial class IntExtensionsTests
    {
        [Fact]
        public void RandomSeesAllValues()
        {
            var arr = new[] { 1, 2, 3, 4, 5, 6 };
            var seen = new SortedSet<int>();

            for(var i = 0; i < 50; i++)
            {
                seen.Add(arr[arr.Length.Random()]);
            }

            Assert.Equal(arr.Length, seen.Count); // "All items in array should have been seen"
        }
    }
}
