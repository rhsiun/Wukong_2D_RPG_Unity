using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase Base {get;set;}
    public int maxTimes {get;set;}

    public Move(MoveBase mBase, int maxTimes)
    {
        Base = mBase;
        maxTimes = maxTimes;
    }
}
