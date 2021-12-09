using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

public class a2021_Day8
{

    public static long Task1(List<string[]> input)
    {
        //        var lengths = new int[] {0, 2, 0, 0, 4, 0, 0, 3, 7, 0}; //0 = don't care
        long s = 0;
        foreach (var item in input)
        {
            //Console.WriteLine(item[1]);
            //  if (lengths.Contains(item[1].Length))
            //     s++;
            string pattern = @"(\b\w{2}\b)|(\b\w{3}\b)|(\b\w{4}\b)|(\b\w{7}\b)";
            var m = Regex.Matches(item[1], pattern, RegexOptions.IgnoreCase);
            //Console.WriteLine(m.Count);
            s += m.Count;
        }
        return s;
    }
    static bool StringContainsString(string a, string b)
    {
        var a1 = a.ToCharArray();
        var b1 = b.ToCharArray();
        Array.Sort(a1);
        Array.Sort(b1);
        string pattern = ".*" + Regex.Replace(new string(b1), ".{1}", "$0.*");
        var m = Regex.Match(new string(a1), pattern, RegexOptions.IgnoreCase);

        return m.Success;
    }
    public static long Task2(List<string[]> input)
    {
        long s = 0;
        foreach (var item in input)
        {
            /*
            1, "cf"=>L = 2
            4, "bcdf"=> L=4
            7, "acf"=> L=3
            8, "abcdefg"=>L=7

            9, "abcdfg" => L=6 + contains 4 and 7
            3, "acdfg" => L=5 + contains 7
            5, "abdfg" => L=5 + contains 4-1 char from 1
            0, "abcefg" => L=6 + contains 7 and not 4


            2, "acdeg" => L=5 and not others
            6, "abdefg" => L=6 and not others
            */

            var numberMaps = new Dictionary<int, string>();
            var numbers = item[0].Split(' ');
            numberMaps[1] = numbers.Where(a => { return a.Length == 2; }).First();
            numberMaps[4] = numbers.Where(a => { return a.Length == 4; }).First();
            numberMaps[7] = numbers.Where(a => { return a.Length == 3; }).First();
            numberMaps[8] = numbers.Where(a => { return a.Length == 7; }).First();
            
            numberMaps[9] = numbers.Where(a => { return (a.Length == 6) && StringContainsString(a, numberMaps[4]) && StringContainsString(a, numberMaps[7]); }).First();
            numberMaps[3] = numbers.Where(a => { return a.Length == 5 && StringContainsString(a, numberMaps[7]); }).First();
            numberMaps[5] = numbers.Where(a => { return a.Length == 5 && (StringContainsString(a, numberMaps[4].Replace(numberMaps[1][0].ToString(), "")) || StringContainsString(a, numberMaps[4].Replace(numberMaps[1][1].ToString(), "")));}).First();
            numberMaps[0] = numbers.Where(a => { return a.Length == 6 && StringContainsString(a, numberMaps[7]) && !StringContainsString(a, numberMaps[4]); }).First();
            numberMaps[2] = numbers.Where(a => { return a.Length == 5 && a!=numberMaps[3] && a!=numberMaps[5];}).First();
            numberMaps[6] = numbers.Where(a => { return a.Length == 6 && a!=numberMaps[0] && a!=numberMaps[9];}).First();
            for(var k = 0; k<10; k++){
                var nm = numberMaps[k].ToCharArray();
                Array.Sort(nm);
                numberMaps[k] = new string(nm);
            }            
            var output1 = item[1].Split(" ");
            for(var k = 0; k<output1.Length; k++)
            {
                var o = output1[k].ToCharArray();
                Array.Sort(o);
                output1[k] = new String(o);
            }
            var output2 = String.Format(" {0} {1} {2} {3} ", output1[0], output1[1], output1[2], output1[3]);
            for(var k = 0; k<10; k++){
                output2 = Regex.Replace(output2, @"\b"+numberMaps[k]+@"\b", k.ToString());
            }
            output2 = Regex.Replace(output2, " ", "");
            s+=long.Parse(output2);
        }
        return s;
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadCSV(file, " | ");
        // Console.WriteLine("Task 1: {0}", Task1(input_1));
        // var input_2 = Input.ReadCSV(file, " ");
        Console.WriteLine("Task 2: {0}", Task2(input_1));
    }
}
