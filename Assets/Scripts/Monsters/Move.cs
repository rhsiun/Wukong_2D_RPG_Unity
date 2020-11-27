using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase _Base;
    public int maxTimes;

    public Move(MoveBase mBase)
    {
        _Base = mBase;
        maxTimes = mBase.getMaxTimes();
    }
}
