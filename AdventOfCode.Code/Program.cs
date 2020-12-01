using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using file " + args[0]);
            var input = Input.Read(args[0]);
            Day1.Task1(input);
            Day1.Task2(input);
        }
    }
}
