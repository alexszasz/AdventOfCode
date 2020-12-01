using System.Collections.Generic;

public class Input
{

    public static List<int> Read(string filename)
    {
        var lines = System.IO.File.ReadAllLines(filename);
        var input = new List<int>();
        foreach (var line in lines)
        {
            input.Add(int.Parse(line));
        }
        return input;
    }

}