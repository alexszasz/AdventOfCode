using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IsDayOneOk
    {
        [Fact]
        public void IsDayOneTestOneOK()
        {
            var input = Input.ReadInts("../../../../Inputs/Tests/1-1-1.txt");
            var result = a2021_Day1.Task1(input.ToArray());
            Assert.True(result == 7, "Value is not as expected");
        }
        [Fact]
        public void IsDayOneTestTwoOK()
        {
            var input = Input.ReadInts("../../../../Inputs/Tests/1-1-1.txt");
            var result = a2021_Day1.Task2(input.ToArray());
            Assert.True(result == 5, "Value is not as expected");
        }

    }
}
