using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Day9
{
 
    public static long Task1(List<long> input)
    {   
        var xmas = new XMAS(input, 25);
        return xmas.GetFirstInvalid();
    }

    public static long Task2(List<long> input)
    {   
        var xmas = new XMAS(input, 25);
        return xmas.FindWeakness();
    }
    public static void Run(string file){
        var input = Input.ReadLongs(file);
        //Console.WriteLine(Task1(input));
        Console.WriteLine(Task2(input));

    }
}
