using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public MonsterBase _base;
    public int _level;

    public Monster(MonsterBase mBase, int mLevel)
    {
        _base = mBase;
        _level = mLevel;
    }
    public int attack
    {
        get{return Mathf.FloorToInt((_base.attack * _level)/100f)+5;}
    }

    public int defense
    {
        get{return Mathf.FloorToInt((_base.defense * _level)/100f)+5;}
    }

    public int maxhp
    {
        get{return Mathf.FloorToInt((_base.maxhp * _level)/100f)+10;}
    }

    public int spAttack
    {
        get{return Mathf.FloorToInt((_base.spAttack * _level)/100f)+10;}
    }

    public int spDefense
    {
        get{return Mathf.FloorToInt((_base.spDefense * _level)/100f)+10;}
    }

    public int speed
    {
        get{return Mathf.FloorToInt((_base.speed * _level)/100f)+10;}
    }
    // public int attack
    // {
    //     get{return Mathf.FloorToInt((_base.getAttack() * _level)/100f)+5;}
    // }

    // public int defense
    // {
    //     get{return Mathf.FloorToInt((_base.getDefense() * _level)/100f)+5;}
    // }

    // public int maxhp
    // {
    //     get{return Mathf.FloorToInt((_base.getHP() * _level)/100f)+10;}
    // }

    // public int spAttack
    // {
    //     get{return Mathf.FloorToInt((_base.getSPATTACK() * _level)/100f)+10;}
    // }

    // public int spDefense
    // {
    //     get{return Mathf.FloorToInt((_base.getSPDEFENSE() * _level)/100f)+10;}
    // }

    // public int speed
    // {
    //     get{return Mathf.FloorToInt((_base.getSpeed() * _level)/100f)+10;}
    // }
}
