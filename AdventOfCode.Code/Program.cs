using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using file " + args[1]);
            var day = new Day(args[0]);
            day.Run(args[1]);
        }
    }
}
