using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Day10
{
 
    public static long Task1(List<long> input)
    {   
        input.Sort();
        var maxVoltage = input[input.Count - 1] + 3;

        

        return maxVoltage;
    }

    public static void Run(string file){
        var input = Input.ReadLongs(file);
        //Console.WriteLine(Task1(input));
        Console.WriteLine(Task1(input));

    }
}
