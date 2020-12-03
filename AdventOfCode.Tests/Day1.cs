using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IsDayOneOk
    {
        [Fact]
        public void IsDayOneTestOneOK()
        {
            var input = Input.ReadInts("/Users/alexszasz/AdventOfCode/Inputs/tests/1-1-1.txt");
            var result = Day1.Task1(input);
            Assert.True(result == 514579, "Value is not as expected");
        }
        [Fact]
        public void IsDayOneTestTwoOK()
        {
            var input = Input.ReadInts("/Users/alexszasz/AdventOfCode/Inputs/tests/1-1-1.txt");
            var result = Day1.Task2(input);
            Assert.True(result == 241861950, "Value is not as expected");
        }

    }
}
