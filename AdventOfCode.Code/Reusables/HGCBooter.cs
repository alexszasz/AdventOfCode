using System.Collections.Generic;
using System;

public class HGCBooter
{
    public static class Operations{
        public const string ACC = "acc";
        public const string JMP = "jmp";
        public const string NOP = "nop";
    }
    public struct Instruction{
        public Instruction(string textLine){
            var s = textLine.Split(' ');
            Operation = s[0];
            Parameter = int.Parse(s[1]);
        }
        public string Operation {get; set;}
        public int Parameter {get; set;}
    }

    public List<Instruction> Code {get;}
    public HGCBooter(List<Instruction> input){
        Code = input;
    }

    public int ExecuteUntilLoop(){
        return ExecuteUntilLoop(this.Code);
    }
    public static int ExecuteUntilLoop(List<Instruction> code, bool errOnLoop = false){
        var stack = new List<int>();
        int accumulator = 0;
        int nextStep = 0;
        while (nextStep != code.Count){
            if (stack.Exists(s => s == nextStep))
                if (errOnLoop)
                    throw new System.StackOverflowException("Loop occured");
                else
                    break;
            stack.Add(nextStep);
            Instruction instruction = code[nextStep];
            switch (instruction.Operation)
            {
                case Operations.ACC:
                    accumulator += instruction.Parameter;
                    nextStep++;
                    break;
                case Operations.NOP:
                    nextStep++;
                    break;
                case Operations.JMP:
                    nextStep += instruction.Parameter;
                    break;
                default:
                    throw new System.ArgumentException("Unknown operation", instruction.Operation);
            }
        }


        return accumulator;
    }
}