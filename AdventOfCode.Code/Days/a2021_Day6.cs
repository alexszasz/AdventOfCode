using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day6
{
    class Lanternfish
    {
        public int timer { get; set; }
        private int lifespan { get; set; }
        public Lanternfish(int _lifespan, int _timer)
        {
            timer = _timer;
            lifespan = _lifespan;
        }
        public bool Tick()
        {
            timer--;
            if (timer < 0)
            {
                timer = lifespan - 1;
                return true;
            }
            return false;
        }
    }
    public static long Task1(List<string> input, int days)
    {
        var lifespan = 7;
        Console.WriteLine("{0}", input.First());
        var list = input.First().Split(",");
        var fish = new List<Lanternfish>();
        foreach (var l in list)
        {
            fish.Add(new Lanternfish(lifespan, int.Parse(l)));
        }

        for (var day = 0; day < days; day++)
        {
            var newFish = 0;
            foreach (var f in fish)
            {
                if (f.Tick())
                {
                    newFish++;
                }
            }
            for (int i = 0; i < newFish; i++)
                fish.Add(new Lanternfish(lifespan, lifespan + 1));
            // Console.Write("After day {0}: ", day+1);
            foreach (var f in fish)
            {
                // Console.Write("{0},", f.timer);
            }
            // Console.Write(".");
            // if(day % 10 == 0)
            // Console.Write(", {0}", fish.Count());
            Console.WriteLine("{0}/{1} ({2:n0})", day + 1, days, fish.Count());
        }
        Console.WriteLine("({0:n0})", fish.Count());
        return fish.Count();
    }

//
// After hours of trying to solve this as a mathematical problem
// (trying to come up with the exponential function), I finally gave up
// and looked online for the solution, which I took from here:
// https://www.reddit.com/r/adventofcode/comments/r9z49j/2021_day_6_solutions/
//
    static long solver2(List<string> input, int days)
    {
        var list = input.First().Split(",");
        var fishList = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        foreach (var l in list)
        {
            fishList[int.Parse(l)] += 1;
        }
        for (var k = 0; k < 9; k++)
        {
            Console.Write("{0} ", fishList[k]);
        }
        for (var i = 0; i < days; i++)
        {
            var newFishList = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (var k = 0; k < 9; k++)
            {
                if (k == 0)
                {
                    newFishList[6] += fishList[k];
                    newFishList[8] += fishList[k];
                }
                else
                {
                    newFishList[k - 1] += fishList[k];
                }
            }
            newFishList.CopyTo(fishList, 0);
        }
        long sum = 0;
        for (var k = 0; k < 9; k++)
        {
            //Console.Write("{0} ", fishList[k]);
            sum += fishList[k];
        }
        return sum;
    }
    public static long Task2(List<string> input, int days)
    {

        var list = input.First().Split(",");
        var calculatedValues = new Dictionary<string, long>();
        long sum = 0;
        for (var day = 0; day < days; day++)
        {
            Console.Write(".");
        }
        Console.WriteLine();
        foreach (var l in list)
        {
            if (!calculatedValues.ContainsKey(l))
            {
                calculatedValues.Add(l, solver2((new string[1] { l }).ToList(), days));
            }
            sum += calculatedValues[l];
        }
        return sum;
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", solver2(input_1, 256));
        // Console.WriteLine("Task 1: {0}", solver2((new string[1] { "3" }).ToList(), 80));
        // var input_2 = Input.ReadStrings(file);
        // Console.WriteLine("Task 2: {0}", Task2(input_1, 256));

    }
}
