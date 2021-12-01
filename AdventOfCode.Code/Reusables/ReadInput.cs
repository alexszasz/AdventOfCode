using System;
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
    public static List<long> ReadLongs(string filename)
    {
        var lines = System.IO.File.ReadAllLines(filename);
        var input = new List<long>();
        foreach (var line in lines)
        {
            input.Add(long.Parse(line));
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

    public static List<dynamic> ReadObjectsArray(string filename)
    {
        var text = System.IO.File.ReadAllText(filename);
        text = text.Replace("\n\n", "^").Replace("\n", " ");
        // Console.WriteLine(text);
        var input = new List<dynamic>();
        foreach (var line in text.Split('^'))
        {
            var obj = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;
            var props = line.Split(' ');
            foreach (var prop in props)
            {
                var p = prop.Split(':');
                if (p.Length == 2)
                    obj.Add(p[0], p[1]);
            }
            input.Add(obj);
        }
        return input;
    }

    public static List<string[]> ReadStringsGroups(string filename)
    {
        var text = System.IO.File.ReadAllText(filename);
        text = text.Replace("\n\n", "^").Replace("\n", "\t");
        // Console.WriteLine(text);
        var input = new List<string[]>();
        foreach (var line in text.Split('^'))
        {
            input.Add(line.Split('\t'));
        }
        return input;
    }
}