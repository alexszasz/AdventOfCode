using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day1
{

    public static long Task1(int[] input)
    {
        int countIncreases = 0;
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] > input[i - 1])
                countIncreases++;
        }
        return countIncreases;
    }
    public static long Task2(int[] input)
    {
        int[] ws = new int[input.Length - 2];
        for (var i = 0; i < input.Length-2; i++)
        {
            ws[i] = input[i] + input[i+1] + input[i+2];
        }
        return Task1(ws);
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadInts(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1.ToArray()));
        var input_2 = Input.ReadInts(file);
        Console.WriteLine("Task 2: {0}", Task2(input_2.ToArray()));

    }
}
