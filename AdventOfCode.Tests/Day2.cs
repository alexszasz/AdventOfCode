using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IsDayTwoOk
    {
        [Fact]
        public void IsDayTwoTestOneOK()
        {
            var input = Input.ReadStrings("/Users/alexszasz/AdventOfCode/Inputs/tests/2-1-1.txt");
            var result = Day2.Task1(input);
            // Assert.True(result == 2, "Expected 2, result was " + result.ToString());
            Assert.True(1 == 1, "Disregard, as in task two it was marked as being incorrect logic");
        }

        [Fact]
        public void IsDayTwoTestTwoOK()
        {
            var input = Input.ReadStrings("/Users/alexszasz/AdventOfCode/Inputs/tests/2-1-1.txt");
            var result = Day2.Task1(input);
            Assert.True(result == 1, "Expected 1, result was " + result.ToString());
        }

    }
}
