using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IsDayOneOk
    {
        [Fact]
        public void IsDayOneTestOneOK()
        {
            var input = Input.Read("/Users/alexszasz/AdventOfCode/Inputs/tests/1-1-1.txt");
            var result = Day1.Task1(input);
            Console.WriteLine(result);
            Assert.True(result == 514579, "Value is not as expected");
        }
        [Fact]
        public void IsDayOneTestTwpOK()
        {
            var input = Input.Read("/Users/alexszasz/AdventOfCode/Inputs/tests/1-1-1.txt");
            var result = Day1.Task2(input);
            Console.WriteLine(result);
            Assert.True(result == 241861950, "Value is not as expected");
        }
    }
}
