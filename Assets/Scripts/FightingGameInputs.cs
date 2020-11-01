using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGameInputs
{
    public bool facingRight = true;
    public string right = "Right";
    public string left = "Left";
    public string up = "Up";
    public string down = "Down";
    public string neutral = "Neutral";

    public string Forward()
    {
        if (facingRight) return right;
        else return left;
    }
    public string Back()
    {
        if (facingRight) return left;
        else return right;
    }
    public string[] NeutralUp()
    {
        string[] item = { neutral, up };
        return item;
    }
    public string[] ForwardUp()
    {
        string[] item = { Forward(), up };
        return item;
    }
    public string[] ForwardNeutral()
    {
        string[] item = { Forward(), neutral };
        return item;
    }
    public string[] ForwardDown()
    {
        string[] item = { Forward(), down };
        return item;
    }
    public string[] NeutralDown()
    {
        string[] item = { neutral, down };
        return item;
    }
    public string[] BackDown()
    {
        string[] item = { Back(), down };
        return item;
    }
    public string[] BackNeutral()
    {
        string[] item = { Back(), neutral };
        return item;
    }
    public string[] BackUp()
    {
        string[] item = { Back(), up };
        return item;
    }
    
    public List<string[]> QCFQ4() // Quarter circle forward from the bottom
    {
        List<string[]> totalInput = new List<string[]>();
        totalInput.Add(NeutralDown());
        totalInput.Add(ForwardDown());
        totalInput.Add(ForwardNeutral());
        return totalInput;
    } 
    public List<string[]> QCFQ1() // Quarter circle forward from the top
    {
        List<string[]> totalInput = new List<string[]>();
        totalInput.Add(NeutralUp());
        totalInput.Add(ForwardUp());
        totalInput.Add(ForwardNeutral());
        return totalInput;
    } 
    public List<string[]> QCBQ3() // Quarter circle back from the bottom
    {
        List<string[]> totalInput = new List<string[]>();
        totalInput.Add(NeutralDown());
        totalInput.Add(BackDown());
        totalInput.Add(BackNeutral());
        return totalInput;
    } 
    public List<string[]> QCBQ2() // Quarter circle back from the top
    {
        List<string[]> totalInput = new List<string[]>();
        totalInput.Add(NeutralUp());
        totalInput.Add(BackUp());
        totalInput.Add(BackNeutral());
        return totalInput;
    } 
}
