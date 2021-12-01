using System;
using System.Collections.Generic;
using System.Text.Json;

public class Day5
{
    public class PlaneSeat{
        public int Row {get; set;}
        public int Seat {get; set;}
    }

    public static int Task1(string input)
    {   
        var row = GetRowNumber(0, 127, input.Substring(0, 7));
        var seat = GetSeatNumber(0, 7, input.Substring(7));
        // Console.WriteLine(row.ToString() + " x " + seat.ToString());
        return row * 8 + seat;
    }

    public static PlaneSeat Task2(string input)
    {   
        var s = new PlaneSeat();
        s.Row = GetRowNumber(0, 127, input.Substring(0, 7));
        s.Seat = GetSeatNumber(0, 7, input.Substring(7));
        // Console.WriteLine(row.ToString() + " x " + seat.ToString());
        return s;
    }

    private static int GetRowNumber(int min, int max, string input){
        if (input.Length == 1)
            return input == "F" ? min : max;
        
        if (input[0] == 'F')
            return GetRowNumber(min, (int) (min + Math.Floor((max - min) / 2.0)), input.Substring(1));
        if (input[0] == 'B')
            return GetRowNumber((int) (min + Math.Ceiling((max - min) / 2.0)), max, input.Substring(1));
        return -1;
    }
    private static int GetSeatNumber(int min, int max, string input){
        if (input.Length == 1)
            return input == "L" ? min : max;
        
        if (input[0] == 'L')
            return GetSeatNumber(min, (int) (min + Math.Floor((max - min) / 2.0)), input.Substring(1));
        if (input[0] == 'R')
            return GetSeatNumber((int) (min + Math.Ceiling((max - min) / 2.0)), max, input.Substring(1));
        return -1;
    }

    public static void Run(string file){
        var input = Input.ReadStrings(file);

        // Console.WriteLine("Task 1: ");
        // foreach(var item in input){
        //     Console.WriteLine(item + ": " + Task1(item).ToString());
        // }

        // Console.WriteLine("Task 1.2: ");
        // var output = new List<int>();
        // foreach(var item in input){
        //     //Console.WriteLine(item + ": " + Task1(item).ToString());
        //     output.Add(Task1(item));
        // }
        // output.Sort();
        // Console.WriteLine(output[0].ToString());
        // Console.WriteLine(output[output.Count-1].ToString());

        var output = new List<PlaneSeat>();
        bool[,] seats = new bool[128,8];
        foreach(var item in input){
            //Console.WriteLine(item + ": " + Task1(item).ToString());
            var o = Task2(item);
            seats[o.Row, o.Seat] = true;
        }
        for (var i=1; i<127; i++){
            for (var j=0; j<8; j++){
                if (!seats[i,j] && seats[i-1, j] && seats[i+1, j])
                    // Console.WriteLine(i.ToString() + " x " + j.ToString());
                    Console.WriteLine((8 * i + j).ToString());
            }
        }
    }
}
