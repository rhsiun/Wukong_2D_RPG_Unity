using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class MoveBase:ScriptableObject
{
   public string name;
   public string description;
   public MonsterType type;

   int power;
   int accuracy;
   int maxTimes;

   public int getPower()
   {
       return power;
   }

   public int getAccuracy()
   {
       return accuracy;
   }

   public int getMaxTimes()
   {
       return maxTimes;
   }
}

