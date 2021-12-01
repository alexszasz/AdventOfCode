using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Day7
{
    public class BagContent{
        public string Colour {get; set;}
        public int MaxBags {get; set;}
    }

    private static string GetColour(string input){
        return input.Replace(" bags", "").Replace(" bag", "").Replace(".", "").Trim();
    }

    private static Dictionary<string, List<BagContent>> GetRules(List<string> input){
        var rules = new Dictionary<string, List<BagContent>>();
        foreach (var item in input)
        {
            string thisColour; 
            var thisContents = new List<BagContent>();
            var split1 = item.IndexOf("contain");
            thisColour = GetColour(item.Substring(0, split1 - 1).Trim());
            foreach (var c in item.Substring(split1+7).Split(","))
            {
                var content = c.Trim();
                var split2 = content.IndexOf(" ");
                var strCount = content.Substring(0, split2);
                if(strCount != "no"){
                    var b = new BagContent();
                    b.MaxBags = int.Parse(strCount);
                    b.Colour = GetColour(content.Substring(split2).Trim());
                    thisContents.Add(b);
                }
            }
            rules.Add(thisColour, thisContents);
        }
        return rules;
    }

    private static List<string> GetColoursThatCanHoldColour(Dictionary<string, List<BagContent>> rules, string colourToCheck){
        var valid = new List<string>();
        foreach (var rule in rules)
        {
            if (rule.Value.Exists(c => c.Colour == colourToCheck))
                valid.Add(rule.Key);
        }
        return valid;
    }

    private static int GetTotalBags(Dictionary<string, List<BagContent>> rules, string colourToCheck){
        Console.Write("(");
        if(rules[colourToCheck].Count == 0){
            Console.Write("1) + ");
            return 1;
        }
        var r = 0;
        foreach (var item in rules[colourToCheck])
        {
            
            // Console.Write(item.MaxBags.ToString()+" x "+item.Colour + ", ");
            Console.Write(item.MaxBags.ToString()+" x "+item.Colour);
            var tb = GetTotalBags(rules, item.Colour);

            Console.Write(" + ");
            r += (tb == 1 ? 0 : item.MaxBags) + item.MaxBags * tb;
        }
        Console.Write(")");
        return r;
    }

    public static int Task1(List<string> input, string colourToCheck)
    {   
        var rules = GetRules(input);
        var valid = new List<string>();
        //Check direct colours
        foreach (var rule in rules)
        {
            if (rule.Value.Exists(c => c.Colour == colourToCheck))
                valid.Add(rule.Key);
        }
        int len1 = 0;
        // int len2 = valid.Count;
        while(valid.Count > len1){
            var v = GetColoursThatCanHoldColour(rules, valid[len1]);
            foreach (var x in v)
                if (!valid.Exists(y=>y==x))
                    valid.Add(x);
            len1++;
        }

        
        Console.WriteLine(JsonSerializer.Serialize(valid));
        
        return valid.Count;
    }

    public static int Task2(List<string> input, string colourToCheck)
    {   
        var rules = GetRules(input);
        
        return GetTotalBags(rules, colourToCheck);
    }

    public static void Run(string file){
        var input = Input.ReadStrings(file);
        // Console.WriteLine(Task1(input, "shiny gold"));
        Console.WriteLine(Task2(input, "shiny gold"));

    }
}
