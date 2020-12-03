using System;
using System.Collections.Generic;
public class Day2
{
    public static int Task1(List<string> input)
    {
        var output = new List<string>();
        foreach (var item in input)
        {
            var arr = item.Split(':');
            if (PasswordValidator.IsValid(arr[1], arr[0]))
                output.Add(arr[1]);
        }
        return output.Count;
    }

    public static void Run(string file){
        var input = Input.ReadStrings(file);
        Console.Write("Task 1: ");
        Console.WriteLine(Day2.Task1(input));
    }

}