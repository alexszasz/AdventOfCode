using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day13
{
    static string[,] inputMatrix;
    public static long Task1(List<string[]> comands)
    {
        var f1 = fold(inputMatrix, comands[1][0].Split(" "));
        return countMatrix(f1);
    }
    public static long Task2(List<string[]> comands)
    {
        string[,] f = new string[1, 1];
        f = inputMatrix;
        for (var k = 0; k < comands[1].Length; k++)
            f = fold(f, comands[1][k].Split(" "));
        printMatrix(f);
        return countMatrix(f);
    }

    static string[,] buildMatrix(List<string[]> input)
    {
        string[,] _inputMatrix;
        int maxI = 0, maxK = 0;
        foreach (var item in input[0])
        {
            var coords = item.Split(",");
            maxI = Math.Max(maxI, int.Parse(coords[0]));
            maxK = Math.Max(maxK, int.Parse(coords[1]));
        }
        _inputMatrix = new string[maxI + 1, maxK + 1];
        foreach (var item in input[0])
        {
            var coords = item.Split(",");
            _inputMatrix[int.Parse(coords[0]), int.Parse(coords[1])] = "#";
        }
        return _inputMatrix;

    }
    static void printMatrix(string[,] m)
    {
        for (var i = 0; i < m.GetLength(1); i++)
        {
            for (var j = 0; j < m.GetLength(0); j++)
            {
                if (m[j, i] != null)
                {
                    Console.Write("{0}", m[j, i]);
                }
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }
        Console.WriteLine("=================");
    }
        static long countMatrix(string[,] m)
    {
        long s = 0;
        for (var i = 0; i < m.GetLength(1); i++)
        {
            for (var j = 0; j < m.GetLength(0); j++)
            {
                if (m[j, i] != null)
                {
                    s++;
                }
            }
        }
        return s;
    }
    static string[,] fold(string[,] m, string[] comand)
    {
        var cmd = comand[2].Split("=");
        var foldLine = int.Parse(cmd[1]);
        string[,] r;
        int offsetX = 0;
        int offsetY = 0;
        if (cmd[0] == "y")
        {
            offsetY = m.GetLength(1) - 1 - 2 * foldLine;
            if (offsetY < 0)
                offsetY = 0;
            r = new string[m.GetLength(0), offsetY + foldLine];
            for (var y = foldLine + 1; y < m.GetLength(1); y++)
            {
                for (var x = 0; x < m.GetLength(0); x++)
                {
                    var foldValue = m[x, y];
                    string foldOverValue = null;
                    if ((2 * foldLine - y) < 0)
                        foldOverValue = null;
                    else
                        foldOverValue = m[x, 2 * foldLine - y];

                    r[x, offsetY + 2 * foldLine - y] = foldValue != null ? foldValue : foldOverValue;
                }
            }
        }
        else
        {
            offsetX = m.GetLength(0) - 1 - 2 * foldLine;
            if (offsetX < 0)
                offsetX = 0;
            r = new string[foldLine, offsetX + m.GetLength(1)];
            for (var x = foldLine + 1; x < m.GetLength(0); x++)
            {
                for (var y = 0; y < m.GetLength(1); y++)
                {
                    var foldValue = m[x, y];
                    string foldOverValue = null;
                    if ((2 * foldLine - x) < 0)
                        foldOverValue = null;
                    else
                        foldOverValue = m[2 * foldLine - x, y];

                    r[offsetX + 2 * foldLine - x, y] = foldValue != null ? foldValue : foldOverValue;
                }
            }
        }
        for(var i = 0; i<r.GetLength(0)-offsetX; i++)
            for(var k = 0; k<r.GetLength(1)-offsetY; k++)
                if(m[i,k] != null)
                    r[offsetX + i, offsetY + k] = m[i,k];
        return r;
    }
    public static void Run(string file)
    {
        var input_1 = Input.ReadStringsGroups(file);
        inputMatrix = buildMatrix(input_1);
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        Console.WriteLine("Task 2: {0}", Task2(input_1));

    }
}
