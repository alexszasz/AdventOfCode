using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class PassportValidator{
    public static Dictionary<string, bool> requiredFields = new Dictionary<string, bool>(){
        {"byr", true}, {"iyr", true}, {"eyr", true}, {"hgt", true}, {"hcl", true}, {"ecl", true}, {"pid", true}, {"cid", false}
    };

    public static bool IsFieldValid(string field, string value){
        int v;
        var isValid = true;
        switch (field)
        {
            case "byr":
                if (value.Length != 4)
                    isValid = false;
                if (!int.TryParse(value, out v))
                    isValid = false;
                isValid = isValid && (v >= 1920 && v<=2002);
                break;
            case "iyr":
                if (value.Length != 4)
                    isValid = false;
                if (!int.TryParse(value, out v))
                    isValid = false;
                isValid = isValid && (v >= 2010 && v<=2020);
                break;
            case "eyr":
                if (value.Length != 4)
                    isValid = false;
                if (!int.TryParse(value, out v))
                    isValid = false;
                isValid = isValid && ( v >= 2020 && v<=2030);
                break;
            case "hgt":
                Regex rx_cm = new Regex(@"([0-9]+)cm", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Regex rx_in = new Regex(@"([0-9]+)in", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                isValid = false;
                var m_cm = rx_cm.Match(value);
                if (m_cm.Success){
                    // Console.WriteLine(JsonSerializer.Serialize(m_cm));
                    Int32.TryParse(m_cm.Groups[1].Value, out v);
                    if(v >= 150 && v <= 193)
                        isValid = true;
                }
                else 
                {
                    var m_in = rx_in.Match(value);
                    if (m_in.Success){
                        Int32.TryParse(m_in.Groups[1].Value, out v);
                        if(v >= 59 && v <= 76)
                            isValid = true;
                    }
                }    
                break;
            case "hcl":
                Regex rx_hcl = new Regex(@"#([0-9]|[a-f]){6}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                isValid = rx_hcl.IsMatch(value);
                break;
            case "ecl":
                Regex rx_ecl = new Regex(@"\b(amb|blu|brn|gry|grn|hzl|oth)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                isValid = rx_ecl.IsMatch(value);
                break;
            case "pid":
                Regex rx_pid = new Regex(@"\b[0-9]{9}\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                isValid = rx_pid.IsMatch(value);
                break;
            default:
                isValid = true;
                break;
        }
        // if (!isValid)
        //     Console.WriteLine(field+" = "+value+" is " + (isValid ? "valid" : "invalid"));
        return isValid;
    }
}