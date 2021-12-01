using System;
using System.Collections.Generic;
using System.Text.Json;

public class Day4
{
    public static Int64 Task1(List<dynamic> input, Dictionary<string, bool> fields)
    {   
        var invalidRows = new List<dynamic>();
        var validRows = new List<dynamic>();
        foreach (IDictionary<string, Object> item in input)
        {
            var isInvalid = false;
            foreach(var field in fields){
                if (field.Value == true)
                    if (!item.ContainsKey(field.Key)){
                        isInvalid = true;
                        // Console.WriteLine("Missing "+field.Key+": " + JsonSerializer.Serialize(item));
                        break;
                    }
                    else 
                        if ((item[field.Key] as string) == null || (item[field.Key] as string).Trim()=="" || !PassportValidator.IsFieldValid(field.Key, item[field.Key] as string)){
                            isInvalid = true;
                            break;
                        }
            }
            if (isInvalid)
                invalidRows.Add(item);
            else
                validRows.Add(item);
        }

        return validRows.Count;
    }

    public static void Run(string file){
        var input = Input.ReadObjectsArray(file);

        Console.Write("Task 2: ");
        Console.WriteLine(Day4.Task1(input, PassportValidator.requiredFields));
    }
}
