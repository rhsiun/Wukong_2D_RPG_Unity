﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MonsterBase : ScriptableObject
{

   public string name;
   public string description;
   public Sprite front;
   public Sprite back;
   public MonsterType typeOne;
   public MonsterType typeTwo;
   

   public int maxhp;
   public int attack;
   public int defense;
   public int spAttack;
   public int spDefense;
   public int speed;

   public List<LearnableMove> learnablemove;

//    public Dictionary<MoveBase,int> mymove = new Dictionary<MoveBase, int>();

   public int getHP()
   {
       return maxhp;
   }

   public string getName()
   {
       return name;
   }
//    public int getAttack()
//    {
//        return attack;
//    }
//    public int getDefense()
//    {
//        return defense;
//    }
//    public int getSPATTACK()
//    {
//        return spAttack;
//    }
//    public int getSPDEFENSE()
//    {
//        return spDefense;
//    }
//    public int getSpeed()
//    {
//        return speed;
//    }

//    public LearnableMove[] getLearnableMoves()
//    {
//        return learnablemoves;
//    }
}
[System.Serializable]
public class LearnableMove
{

    // public MoveBase mymovebase;
    // public int level;
    public MoveBase movebase;
    public int level;

    // public MoveBase MoveBase
    // {
    //     get {return movebase;}
    // }
    // public int Level
    // {
    //     get {return level;}
    // }
}

public enum MonsterType
{
    Normal,
    Fire,
    Water,
    Ground,
    Flying
}