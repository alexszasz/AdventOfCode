using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Day6
{
    public static int Task1(List<string[]> input)
    {   
        int output = 0;
        foreach (var item in input)
        {
            string group = "";
            foreach(var s in item)
                group+=s;
            Console.Write(group+": ");
            foreach(var l in group.Distinct().ToArray()){
                if( group.Count(f => f == l) == item.Length ){
                    output++;
                    Console.Write(l);
                }
            }
            Console.WriteLine();
        }
        return output;
    }

    public static void Run(string file){
        var input = Input.ReadStringsGroups(file);
        Console.WriteLine(Task1(input));
    }
}
