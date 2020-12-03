using System.Collections.Generic;

public class Input
{

    public static List<int> ReadInts(string filename)
    {
        var lines = System.IO.File.ReadAllLines(filename);
        var input = new List<int>();
        foreach (var line in lines)
        {
            input.Add(int.Parse(line));
        }
        return input;
    }
    public static List<string> ReadStrings(string filename)
    {
        var lines = System.IO.File.ReadAllLines(filename);
        var input = new List<string>();
        foreach (var line in lines)
        {
            input.Add(line);
        }
        return input;
    }
}