using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IsDayThreeOk
    {
        [Fact]
        public void IsDayThreeTestOneOK()
        {
            var input = Input.ReadStrings("/Users/alexszasz/AdventOfCode/Inputs/tests/3-1-1.txt");
            var result = Day3.Task1(input, 3, 1);
            Assert.True(result == 7, "Expected 7, result was " + result.ToString());
        }

        [Fact]
        public void IsDayThreeTestTwoOK()
        {
            var input = Input.ReadStrings("/Users/alexszasz/AdventOfCode/Inputs/tests/3-1-1.txt");
            var result = Day3.Task1(input, 1, 1) * Day3.Task1(input, 3, 1) * Day3.Task1(input, 5, 1) * Day3.Task1(input, 7, 1) * Day3.Task1(input, 1, 2);
            Assert.True(result == 336, "Expected 336, result was " + result.ToString());
        }
    }
}
