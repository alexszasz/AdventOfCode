using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Day8
{
 
    public static int Task1(List<string> input)
    {   
        var code = new List<HGCBooter.Instruction>();
        foreach (var item in input)
        {
            code.Add(new HGCBooter.Instruction(item));
        }
        var b = new HGCBooter(code);
        return b.ExecuteUntilLoop();
    }

    public static int Task2(List<string> input)
    {   
        var initCode = new List<HGCBooter.Instruction>();
        foreach (var item in input)
        {
            initCode.Add(new HGCBooter.Instruction(item));
        }
        var variants = new List<List<HGCBooter.Instruction>>();
        for(var i=0; i<initCode.Count; i++){
            var zCode = new HGCBooter.Instruction[initCode.Count];
            zCode = initCode.ConvertAll(c => c).ToArray();
            if(zCode[i].Operation == HGCBooter.Operations.JMP || zCode[i].Operation == HGCBooter.Operations.NOP){
                zCode[i].Operation = (zCode[i].Operation == HGCBooter.Operations.JMP) ? HGCBooter.Operations.NOP : HGCBooter.Operations.JMP;
                variants.Add(zCode.ToList());
            }
        }
        foreach (var code in variants)
        {
            try{
                var o = HGCBooter.ExecuteUntilLoop(code, true);
                return o;
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        //Console.WriteLine(variants.Count);
        
        return -1;
        //return b.ExecuteUntilLoop();
    }

    public static void Run(string file){
        var input = Input.ReadStrings(file);
        // Console.WriteLine(Task1(input, "shiny gold"));
        //Console.WriteLine(Task1(input));
        Console.WriteLine(Task2(input));

    }
}
