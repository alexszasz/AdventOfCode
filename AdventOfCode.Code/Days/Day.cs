using System;
using System.Reflection;

public class Day{
    Type _theType;
    public Day(string dayname){
        _theType = GetType().Assembly.GetType(dayname);
    }

    public void Run(string filename){
        Console.WriteLine(_theType);
        MethodInfo mi = _theType.GetMethod("Run");
        var p = new object[1]{filename};
        mi.Invoke(null, p);
    }
}