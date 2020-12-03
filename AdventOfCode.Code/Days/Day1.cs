using System;
using System.Collections.Generic;
public class Day1
{
    public static int Task1(List<int> input)
    {
        var output = 1;
        var items = Calculator.FindPartsForValue(input, 2020, 2);
        foreach (var item in items)
        {
            output = output * item;
        }
        // Console.Write(String.Join(" x ", items));
        // Console.Write(" = ");
        // Console.WriteLine(output);
        return output;
    }
    public static int Task2(List<int> input)
    {
        var output = 1;
        var items = Calculator.FindPartsForValue(input, 2020, 3);
        foreach (var item in items)
        {
            output = output * item;
        }
        // Console.Write(String.Join(" x ", items));
        // Console.Write(" = ");
        // Console.WriteLine(output);
        return output;
    }

    public static void Run(string file){
        var input = Input.ReadInts(file);
        Console.Write("Task 1: ");
        Console.WriteLine(Day1.Task1(input));
        Console.Write("Task 2: ");
        Console.WriteLine(Day1.Task2(input));
    }
}