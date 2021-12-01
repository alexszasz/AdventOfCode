using System.Collections.Generic;
using System;

public class XMAS
{
    private List<long> cypher;
    private int preambul;
    public XMAS(List<long> input, int preambul)
    {
        this.cypher = input;
        this.preambul = preambul;
    }

    private bool IsValid(int k)
    {
        for (var i = k - this.preambul; i < k - 1; i++)
            for (var j = i + 1; j < k; j++)
                if (this.cypher[i] + this.cypher[j] == this.cypher[k])
                    return true;
        return false;
    }
    public long GetFirstInvalid()
    {
        var i = this.preambul;
        while (i < this.cypher.Count)
        {
            if (!IsValid(i))
                return this.cypher[i];
            i++;
        }
        return -1;
    }

    public long FindWeakness(){
        var firstInvalid = this.GetFirstInvalid();
        int start = -1;
        int end = -1;
        for(var i=0; i<this.cypher.Count; i++){
            long s = 0;
            for(var j=i; j<this.cypher.Count; j++){
                s+=this.cypher[j];
                if(s == firstInvalid){
                    start = i;
                    end = j;
                    break;
                }
                if(s > firstInvalid)
                    break;
            }
            if(start == i)
                break;
        }
        long min = long.MaxValue; long max = long.MinValue;
        for(var i = start; i<=end; i++){
            if(this.cypher[i] < min)
                min = this.cypher[i];
            if(this.cypher[i] > max)
                max = this.cypher[i];
        }

        return min + max;
    }
}