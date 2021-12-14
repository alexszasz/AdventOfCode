using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day10
{
    static char[] openingTags = { '(', '[', '{', '<' };
    static Dictionary<char, char> tags = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
    static Dictionary<char, long> closingTags = new Dictionary<char, long>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
    static char? GetFirstInvalidCharacter(string line)
    {
        Stack<char> st = new Stack<char>();
        for (int i = 0; i < line.Length; i++)
        {
            if (tags.Keys.Contains(line[i])) //starting bracket
                st.Push(line[i]);
            if (tags.Values.Contains(line[i])) //closing bracket   
            {
                if (st.Count == 0)
                    throw new Exception("Closing bracket without a starting one");
                if (tags[st.Pop()] != line[i])
                    return line[i];
            }
        }
        if (st.Count > 0)
            throw new Exception("Incomplete");

        return null;
    }

    public static long Task1(List<string> input)
    {
        long s = 0;
        foreach (var item in input)
        {
            try
            {
                var c = GetFirstInvalidCharacter(item);
                if (c != null)
                    s += closingTags[(char)c];
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        return s;
    }

    static char[]? Autocomplete(string line)
    {
        Stack<char> st = new Stack<char>();
        for (int i = 0; i < line.Length; i++)
        {
            if (tags.Keys.Contains(line[i])) //starting bracket
                st.Push(line[i]);
            if (tags.Values.Contains(line[i])) //closing bracket   
            {
                st.Pop();
            }
        }
        var remainingChars = new List<char>();
        while (st.Count > 0){
            var c = st.Pop();
            if (tags.Keys.Contains(c)) 
                remainingChars.Add(tags[c]);
        }
        return remainingChars.ToArray();
    }
    static long Score(char[] chars){
        long s = 0;
        var scores = new Dictionary<char, long>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
        // Console.Write("{0} => ", new string(chars));

        foreach (var c in chars)
        {
            // Console.Write("{0} * 5 + {1} = ", s, scores[c]);
            s = (s * 5 + scores[c]);
            // Console.Write("{0};", s);
        }
        // Console.WriteLine();
        return s;
    }
    public static long Task2(List<string> input)
    {
        var scores = new List<long>();
        foreach (var item in input)
        {
            try
            {
                GetFirstInvalidCharacter(item);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Incomplete")
                {
                    var rc = Autocomplete(item);
                    var s = Score(rc);
                    Console.WriteLine("{0} => {1}",new string(rc), s);
                    scores.Add(s);
                }
                else
                    Console.WriteLine(ex.Message);
            }
        }
        scores = scores.Distinct().ToList();
        scores.Sort();
        
        return scores.ToArray()[scores.Count/2];
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        // var input_2 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 2: {0}", Task2(input_1));

    }
}
