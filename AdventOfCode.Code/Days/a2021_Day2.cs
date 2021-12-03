using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day2
{

    public static long Task1(List<string[]> input)
    {
        int x = 0, y = 0;
        x = input.Where(a => a[0] == "forward").Sum(a => Int32.Parse(a[1]));
        y = input.Where(a => a[0] == "down").Sum(a => Int32.Parse(a[1])) - input.Where(a => a[0] == "up").Sum(a => Int32.Parse(a[1]));
        return x * y;
    }
    public static long Task2(List<string[]> input)
    {
        long x = 0, y = 0, aim = 0;
        foreach (var v in input)
        {
            switch (v[0])
            {
                case "down":
                    aim += Int64.Parse(v[1]);
                    break;
                case "up":
                    aim -= Int64.Parse(v[1]);
                    break;
                case "forward":
                    x += Int64.Parse(v[1]);
                    y += Int64.Parse(v[1]) * aim;
                    break;
                default:
                    Console.WriteLine("Should not be here!");
                    break;
            }
        }
        return x*y;
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        var input_2 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 2: {0}", Task2(input_2));

    }
}
