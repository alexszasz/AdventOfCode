using System.Collections.Generic;
using System;
public class Calculator
{
    private static List<List<int>> GenerateSelections(List<int> items, int n)
    {
        bool[] in_selection = new bool[items.Count];
        var results = new List<List<int>>();
        SelectItems(items, in_selection, results, n, 0);
        return results;
    }

    private static void SelectItems<T>(List<T> items, bool[] in_selection,
        List<List<T>> results, int n, int first_item)
    {
        if (n == 0)
        {
            List<T> selection = new List<T>();
            for (int i = 0; i < items.Count; i++)
            {
                if (in_selection[i]) selection.Add(items[i]);
            }
            results.Add(selection);
        }
        else
        {
            for (int i = first_item; i < items.Count; i++)
            {
                in_selection[i] = true;
                SelectItems(items, in_selection, results, n - 1, i + 1);
                in_selection[i] = false;
            }
        }
    }
    public static List<int> FindPartsForValue(List<int> input, int sum, int parts = 2)
    {
        var values = new List<int>();
        var l = GenerateSelections(input, parts);
        for (var i = 0; i < l.Count; i++)
        {
            int s = 0;
            for (var j = 0; j < parts; j++)
            {
                s = s + l[i][j];
                values.Add(l[i][j]);
            }
            if (s == sum)
            {
                break;
            }
            values.Clear();
        }

        return values;
    }
}