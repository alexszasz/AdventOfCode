using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day9
{
    static List<int[]> GetLowPoints(string[] input)
    {
        var lowPoints = new List<int[]>();
        for (var i = 0; i < input.Length; i++)
        {
            for (var k = 0; k < input[i].Length; k++)
            {
                var isLow = false;
                if (k > 0 && i > 0 && k < input[i].Length - 1 && i < input.Length - 1) //not edge
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k - 1] && input[i][k] < input[i][k + 1] && input[i][k] < input[i + 1][k]);
                if (k > 0 && i == 0 && k < input[i].Length - 1) //top edge
                    isLow = (input[i][k] < input[i][k - 1] && input[i][k] < input[i][k + 1] && input[i][k] < input[i + 1][k]);
                if (k > 0 && k < input[i].Length - 1 && i == input.Length - 1)//botom edge
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k - 1] && input[i][k] < input[i][k + 1]);
                if (k == 0 && i > 0 && i < input.Length - 1) //left edge
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k + 1] && input[i][k] < input[i + 1][k]);
                if (i > 0 && k == input[i].Length - 1 && i < input.Length - 1) //right edge
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k - 1] && input[i][k] < input[i + 1][k]);
                if (k == 0 && i == 0) //top left corner
                    isLow = (input[i][k] < input[i][k + 1] && input[i][k] < input[i + 1][k]);
                if (i == 0 && k == input[i].Length - 1) //top right corner
                    isLow = (input[i][k] < input[i][k - 1] && input[i][k] < input[i + 1][k]);
                if (k == 0 && i == input.Length - 1) //bottom left corner
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k + 1]);
                if (k == input[i].Length - 1 && i == input.Length - 1) //botton right corner
                    isLow = (input[i][k] < input[i - 1][k] && input[i][k] < input[i][k - 1]);

                if (isLow)
                    lowPoints.Add(new int[2] { i, k });
            }
        }
        return lowPoints;
    }
    public static long Task1(string[] input)
    {
        long s = 0;
        foreach (var item in GetLowPoints(input))
        {
            s += 1 + long.Parse(input[item[0]][item[1]].ToString());
        }
        return s;
    }

    static List<string> FillBasin(string[] input, int i, int k)
    {
        var l = new List<string>();
        // Console.Write("{0} x {1}; ", i, k);
        if (input[i][k] < '9')
            l.Add(String.Format("{0}x{1}", i, k));
        if (i < input.Length - 1 && input[i][k] < input[i + 1][k])
        {
            l.AddRange(FillBasin(input, i + 1, k));
        }
        if (k < input[i].Length - 1 && input[i][k] < input[i][k + 1])
        {
            l.AddRange(FillBasin(input, i, k + 1));
        }
        if (i > 0 && input[i][k] < input[i - 1][k])
        {
            l.AddRange(FillBasin(input, i - 1, k));
        }
        if (k > 0 && input[i][k] < input[i][k - 1])
        {
            l.AddRange(FillBasin(input, i, k - 1));
        }
        return l.Distinct().ToList();
    }
    public static long Task2(string[] input)
    {
        var lp = GetLowPoints(input);
        long r = 1;
        var bLengths = new List<int>();
        foreach (var p in lp)
        {
            // Console.WriteLine("Checking basin for {0} x {1}", p[0], p[1]);
            var b = FillBasin(input, p[0], p[1]);
            bLengths.Add(b.Count);
            // Console.WriteLine(" => {0}", b.Count);
            // Console.WriteLine();
            // foreach (var bp in b)
            // {
            //     Console.Write("{0}; ", bp);
            // }
            // Console.WriteLine(" => {0}", b.Count);
        }
        bLengths.Sort();
        foreach (var bl in bLengths.TakeLast(3))
        {
            r *= bl;
        } 
        return r;
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1.ToArray()));
        // var input_2 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 2: {0}", Task2(input_1.ToArray()));

    }
}
