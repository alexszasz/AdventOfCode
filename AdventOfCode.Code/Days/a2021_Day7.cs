using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day7
{

    static long median(long[] arr)
    {
        var mid = (arr.Length - 1) / 2;
        return arr[mid];
    }
    static long usedFuel(long[] arr, long a)
    {
        long f = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            f += Math.Abs(arr[i] - a);
        }
        return f;
    }
    static long usedFuel2(long[] arr, long a)
    {
        long f = 0;
        for (var i = 0; i < arr.Length; i++)
        {
            var d = Math.Abs(arr[i] - a);
            // Console.WriteLine("{0} to {1}: {2}", arr[i], a, d * (d + 1) / 2 );
            f += d * (d + 1) / 2;
        }
        return f;
    }
    public static long Task1(List<string> input)
    {
        var l = new List<long>();
        foreach (var v in input.First().Split(","))
            l.Add(long.Parse(v));
        var arr = l.ToArray();
        Array.Sort(arr);

        return usedFuel(arr, median(arr));
    }
    public static double Task2(List<string> input)
    {
        var l = input.First().Split(",").Select(a => { return long.Parse(a); });
        var arr = new long[l.Max()+1];
        foreach (var v in l)
            arr[v] += 1;
        double s = 0;
        for (var k = 0; k < arr.Length; k++)
        {
            s += k * arr[k];
        }
        var _median = Convert.ToInt64(Math.Round(s / l.Count()));
        Console.WriteLine("{0}/{1}: {2}", s, l.Count(), _median);
        Console.WriteLine(usedFuel2(l.ToArray(), 477));
        return usedFuel2(l.ToArray(), 476);
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        // var input_2 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 2: {0}", Task2(input_1));

    }
}
