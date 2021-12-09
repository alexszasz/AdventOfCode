using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day5
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    class Segment
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public bool includeDiagonals { get; set; }
        public Segment(Point _p1, Point _p2, bool _includeDiagonals = false)
        {
            p1 = _p1;
            p2 = _p2;
            includeDiagonals = _includeDiagonals;
        }

        public List<Point> GetPoints()
        {
            var l = new List<Point>();
            if (p1.x == p2.x)
            {
                for (var y = Math.Min(p1.y, p2.y); y <= Math.Max(p1.y, p2.y); y++)
                    l.Add(new Point() { x = p1.x, y = y });
            }
            else if (p1.y == p2.y)
            {
                for (var x = Math.Min(p1.x, p2.x); x <= Math.Max(p1.x, p2.x); x++)
                    l.Add(new Point() { x = x, y = p1.y });
            }
            else if (includeDiagonals && Math.Abs(p1.x - p2.x) == Math.Abs(p1.y - p2.y))
            {
                for(var k = 0; k<=Math.Abs(p1.x - p2.x); k++){
                    l.Add(new Point() { x = p1.x + k * (p2.x-p1.x)/Math.Abs(p1.x - p2.x), y = p1.y + k * (p2.y-p1.y)/Math.Abs(p1.y - p2.y) });
                }
            }
            return l;
        }
    }
    public static long Task1(List<string> input, bool includeDiagonals = false)
    {
        var segments = new List<Segment>();
        int maxx = -1, maxy = -1;
        foreach (var i in input)
        {
            var a = i.Split(" -> ");
            var p1 = a[0].Split(",");
            var p2 = a[1].Split(",");
            var s = new Segment(new Point() { x = int.Parse(p1[0]), y = int.Parse(p1[1]) }, new Point() { x = int.Parse(p2[0]), y = int.Parse(p2[1]) }, includeDiagonals);
            segments.Add(s);
            maxx = Math.Max(Math.Max(maxx, s.p1.x), s.p2.x);
            maxy = Math.Max(Math.Max(maxy, s.p1.y), s.p2.y);
        }
        // Console.WriteLine("{0} x {1}", maxx, maxy);
        int[,] v = new int[maxx + 1, maxy + 1];
        foreach (var seg in segments)
        {
            foreach (var p in seg.GetPoints())
            {
                v[p.x, p.y]++;
            }
        }
        Console.WriteLine("{0} x {1}", v.GetLength(1), v.GetLength(0));
        var sum = 0;
        for (var i = 0; i < v.GetLength(1); i++)
        {
            for (var j = 0; j < v.GetLength(0); j++)
            {
                // Console.Write("{0} ", v[j, i]);
                if (v[j, i] > 1)
                    sum++;
            }
            // Console.WriteLine();
        }
        return sum;
    }
    public static long Task2(List<string> input)
    {
        return Task1(input, true);
    }

    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        Console.WriteLine("Task 1: {0}", Task1(input_1));
        var input_2 = Input.ReadStrings(file);
        Console.WriteLine("Task 2: {0}", Task2(input_2));

    }
}
