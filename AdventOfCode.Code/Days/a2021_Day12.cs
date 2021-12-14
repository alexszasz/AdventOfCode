using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class a2021_Day12
{
    static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
    static List<string> solutions = new List<string>();
    static List<string> currentCandidate = new List<string>();
    static void addEdge(string u, string v)
    {
        // var isStart = (u == "start") || (v=="end");
        // var isEnd = (v == "end") || (u == "start");

        if (!graph.ContainsKey(u))
            graph[u] = new List<string>();
        if (!graph.ContainsKey(v))
            graph[v] = new List<string>();
        if (!graph[u].Contains(v))
            graph[u].Add(v);
        if (!graph[v].Contains(u))
            graph[v].Add(u);
    }

    static void print()
    {
        foreach (var k in graph.Keys)
        {
            Console.Write("{0}: ", k);
            foreach (var v in graph[k])
            {
                Console.Write("{0} - ", v);
            }
            Console.WriteLine();
        }
    }
    static int? checkSolution(List<string> candidate, int maxAllowedSmallVisits)
    {
        //var isValid = true;
        //printCanditate(candidate);
        if (candidate.First() != "start")
            return 1;
        if (candidate.Last() != "end")
            return 2;
        var lowerCases = candidate.Where(c => { return c == c.ToLower(); });
        if (lowerCases.Count() > lowerCases.Distinct().Count() + maxAllowedSmallVisits - 1)
            return 3; //same lowercase more than once
        if (solutions.Contains(string.Join(",", candidate)))
            return 4; //already have it as a solution
        return null;
    }
    public static long Task1()
    {
        solutions = new List<string>();
        currentCandidate = new List<string>();
        findSolutions("start", 1);
        return solutions.Count;
    }
    public static long Task2()
    {
        solutions = new List<string>();
        currentCandidate = new List<string>();
        // print();
        findSolutions("start", 2);
        // foreach (var item in solutions)
        // {
        //     Console.WriteLine(item);
        // }
        return solutions.Count;
    }

    static void printCanditate(List<string> candidate)
    {
        foreach (var item in candidate)
        {
            Console.Write("{0},", item);
        }
        Console.WriteLine();
    }
    static void findSolutions(string startPoint, int maxAllowedSmallVisits)
    {
        // var _start = graph[startPoint];
        //var currentCandidate = new List<string>();
        currentCandidate.Add(startPoint);
        // Console.Write("{0}: ", startPoint);
        //printCanditate(currentCandidate);
        var lowerCases = currentCandidate.Where(c => { return c == c.ToLower(); });
        if (!(lowerCases.Count() > lowerCases.Distinct().Count() + maxAllowedSmallVisits - 1))
        {
            if (startPoint == "end")
            {
                var isSolution = checkSolution(currentCandidate, maxAllowedSmallVisits);
                if (isSolution == null)
                {
                    solutions.Add(string.Join(",", currentCandidate));
                    if (solutions.Count % 100 == 0)
                        Console.Write('.');
                    if (solutions.Count % 10000 == 0)
                        Console.WriteLine();
                }
                else
                {
                    Console.Write("({0})", isSolution);
                    printCanditate(currentCandidate);
                }
            }
            else
                foreach (var item in graph[startPoint])
                {
                    //Console.WriteLine("{0}->{1}", startPoint, item);
                    if (item != item.ToLower() || (item == item.ToLower() && !(currentCandidate.FindAll(c => { return c == item; }).Count >= maxAllowedSmallVisits)))
                        findSolutions(item, maxAllowedSmallVisits);
                }
        }
        currentCandidate.RemoveAt(currentCandidate.Count - 1);
    }
    public static void Run(string file)
    {
        var input_1 = Input.ReadStrings(file);
        foreach (var item in input_1)
        {
            var v = item.Split("-");
            addEdge(v[0], v[1]);
            addEdge(v[1], v[0]);
        }
        graph["end"] = new List<string>();
        foreach (var k in graph.Keys)
        {
            graph[k].Remove("start");
        }
        // print();
        // Console.WriteLine(@"¯\_(ツ)_/¯");
        Console.WriteLine("Task 1: {0}", Task1());
        // var input_2 = Input.ReadStrings(file);
        Console.WriteLine("Task 2: {0}", Task2());

    }
}
