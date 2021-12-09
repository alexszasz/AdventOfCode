using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day4
{

    static bool arrayIsAllNegatives(int[] arr)
    {
        foreach (var v in arr)
            if (v >= 0)
                return false;
        return true;
    }
    public static bool matrixHasBingo(int[][] matrix)
    {
        for (var i = 0; i < 5; i++)
        {
            if (arrayIsAllNegatives(matrix[i]) || arrayIsAllNegatives(new int[] { matrix[0][i], matrix[1][i], matrix[2][i], matrix[3][i], matrix[4][i] }))
                return true;
        }
        return false;
    }

    static void printTicket(int[][] m)
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                Console.Write("{0} ", m[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------------");
    }
    public static long Task1(List<List<int[]>> input, bool stopWhenFound)
    {
        var arrDrawnNumbers = input.First().First();
        input.RemoveAt(0);
        var bingoTickets = new List<int[][]>();
        var bingoTicketsIndexes = new List<int>();
        var bingoWasFound = false;
        var lastDrawnNumber = 0;
        var tickets = new List<int[][]>();
        foreach (var x in input)
        {
            tickets.Add(x.ToArray());
        }
        // foreach (var t in tickets)
        // {
        //     printTicket(t);
        // }

        foreach (var currentNumber in arrDrawnNumbers)
        {
            lastDrawnNumber = currentNumber;
            Console.WriteLine(currentNumber);
            var zzz = 0;
            foreach (var t in tickets)
            {
                for (var i = 0; i < 5; i++)
                {
                    for (var k = 0; k < 5; k++)
                    {
                        if (t[i][k] == currentNumber)
                            t[i][k] = -100 + (-1 * t[i][k]);
                    }
                }
                if (matrixHasBingo(t) && bingoTicketsIndexes.IndexOf(zzz) == -1)
                {
                    var bingoTicket = t;
                    // Console.WriteLine("BINGO!!!");
                    // printTicket(t);
                    bingoWasFound = true;
                    bingoTickets.Add(bingoTicket);
                    bingoTicketsIndexes.Add(zzz);
                    if (stopWhenFound && bingoWasFound)
                        break;
                }
                zzz++;
            }
            if (bingoTickets.Count == zzz || (stopWhenFound && bingoWasFound))
                break;
        }
        var s = 0;
        var bt = bingoTickets.Last();
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (bt[i][j] > 0)
                {
                    s += bt[i][j];
                }
            }
        }
        // Console.WriteLine();
        // foreach (var t in tickets)
        // {
        //     printTicket(t);
        // }
        return s * lastDrawnNumber;
    }
    public static long Task2(List<List<int[]>> input)
    {

        return Task1(input, false);
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadIntArraysAndMatrixes(file, new char[] { ' ', ',' });
        Console.WriteLine("Task 1: {0}", Task1(input_1, true));
        var input_2 = Input.ReadIntArraysAndMatrixes(file, new char[] { ' ', ',' });
        Console.WriteLine("Task 2: {0}", Task2(input_2));

    }
}
