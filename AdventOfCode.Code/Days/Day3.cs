using System;
using System.Collections.Generic;
public class Day3
{
    public static Int64 Task1(List<string> input, int slopeX, int slopeY)
    {       
        var output = new List<string>();
        var checkX = 0;
        var checkY = 0;
        while(checkY < input.Count){
            var z = input[checkY];
            output.Add((input[checkY][checkX] == '#') ? "X" :"0");
            checkX = (checkX + slopeX) % input[0].Length;
            checkY += slopeY;
        }
        return output.FindAll(o => o=="X").Count;
    }

    public static void Run(string file){
        var input = Input.ReadStrings(file);
        Console.Write("Task 1: ");
        Console.WriteLine(Day3.Task1(input, 3, 1));
        Console.Write("Task 2: ");
        Console.WriteLine(Day3.Task1(input, 1, 1) * Day3.Task1(input, 3, 1) * Day3.Task1(input, 5, 1) * Day3.Task1(input, 7, 1) * Day3.Task1(input, 1, 2));
    }
}