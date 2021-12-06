using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

public class a2021_Day3
{
    private static char GetMostCommonInPosition(string[] arrInput, int position)
    {
        int sum = 0;
        for (int i = 0; i < arrInput.Length; i++)
        {
            // Console.Write("{0}, ", arrInput[i]);
            if (arrInput[i][position] == '1')
                sum++;
        }
        // Console.WriteLine(" => {0}", sum);
        return sum >= arrInput.Length / 2.0 ? '1' : '0';
    }
    public static long Task1(List<string> input)
    {
        var gamma = new StringBuilder(new String(' ', input.First().Length));
        var epsilon = new StringBuilder(gamma.ToString());
        var arrInput = input.ToArray();
        for (int k = 0; k < arrInput[0].Length; k++)
        {
            var mostCommon = GetMostCommonInPosition(arrInput, k);
            gamma[k] = mostCommon;
            epsilon[k] = mostCommon == '1' ? '0' : '1';
        }

        return Convert.ToInt64(gamma.ToString(), 2) * Convert.ToInt64(epsilon.ToString(), 2);
    }

    public static string BitCriteria(List<string> input, bool criteria, int position)
    {
        if (input.Count == 1)
            return input.First();
        var mostCommon = GetMostCommonInPosition(input.ToArray(), position);
        // Console.WriteLine("Position: {0} => {1}", position, mostCommon);

        return BitCriteria(input.Where(a => { return (a[position] == mostCommon) == criteria; }).ToList(), criteria, position + 1);
    }
    public static long Task2(List<string> input)
    {
        return Convert.ToInt64(BitCriteria(input, true, 0), 2) * Convert.ToInt64(BitCriteria(input, false, 0), 2) ;
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        var input_2 = Input.ReadStrings(file);
        Console.WriteLine("Task 2: {0}", Task2(input_2));

    }
}
