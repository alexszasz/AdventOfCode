using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day11
{
    static int[][] input;
    static List<int> flashedVal;
    static int flashCount = 0;
    static void flash(int _i, int _k)
    {
        var startI = _i == 0 ? 0 : _i - 1;
        var endI = _i == (input.Length - 1) ? input.Length - 1 : _i + 1;
        var startK = _k == 0 ? 0 : _k - 1;
        var endK = _k == (input.Length - 1) ? input.Length - 1 : _k + 1;
        // Console.WriteLine("[{6}],{0}x{1}: {2}x{4} / {3}x{5}", _i, _k, startI, endI, startK, endK, input.Length);
        // print(_i, _k);
        for (var i = startI; i <= endI; i++)
        {
            for (var k = startK; k <= endK; k++)
            {
                // Console.Write("{0}x{1}; ", i, k);
                if ((100 * i + k) != (100 * _i + _k))
                {
                    // Console.WriteLine("X");
                    input[i][k]++;
                    // print(_i, _k);
                }
            }
        }
        flashedVal.Add(_i * 100 + _k);
        flashCount++;
        // Console.WriteLine("=====================");
    }
    static void print(int exceptI = -1, int exceptK = -1)
    {
        for (var i = 0; i < input.Length; i++)
        {
            for (var k = 0; k < input[i].Length; k++)
            {
                if (i == exceptI && k == exceptK)
                    Console.Write("_ ");
                else
                    Console.Write("{0} ", input[i][k]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    static void increaseEnergy()
    {
        for (var i = 0; i < input.Length; i++)
        {
            for (var k = 0; k < input[i].Length; k++)
            {
                input[i][k]++;
            }
        }
    }
    static int[] getNextToFlash()
    {
        for (var i = 0; i < input.Length; i++)
        {
            for (var k = 0; k < input[i].Length; k++)
            {
                if (input[i][k] > 9 && !flashedVal.Contains(i * 100 + k))
                {
                    // Console.WriteLine("{0} x {1}", i, k);
                    return new int[2] { i, k };
                }
            }
        }

        return null;
    }
    static void step()
    {
        flashedVal = new List<int>();
        increaseEnergy();
        var flashed = new List<int[]>();
        var nextToFlash = getNextToFlash();
        while (nextToFlash != null)
        {
            flash(nextToFlash[0], nextToFlash[1]);
            flashed.Add(nextToFlash);
            nextToFlash = getNextToFlash();
        }
        foreach (var f in flashed)
        {
            input[f[0]][f[1]] = 0;
        }
    }
    public static long Task1(int steps)
    {
        flashCount = 0;
        for (var s = 0; s < steps; s++)
        {
            step();
        }
        return flashCount;
    }
    public static long Task2()
    {
        flashCount = 0;
        var s = 0;
        while (true)
        {
            step();
            s++;
            var hasEnergy = false;
            for (var i = 0; i < input.Length; i++)
                for (var k = 0; k < input[i].Length; k++)
                    if(input[i][k]>0){
                        hasEnergy = true;
                        break;
                    }
            if (!hasEnergy)
                return s;
        }
    }

    public static void Run(string file)
    {
        input = Input.ReadDigitArrays(file).ToArray();
        Console.WriteLine("Task 1: {0}", Task1(100));
        // var input_2 = Input.ReadStrings(file);
        input = Input.ReadDigitArrays(file).ToArray();
        Console.WriteLine("Task 2: {0}", Task2());
        // Console.WriteLine("Task 2: {0}", Task2(input_2));

    }
}
