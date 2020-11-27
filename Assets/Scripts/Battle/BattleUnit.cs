using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
   public MonsterBase _base;
   public int _level;
   public bool isPlayUnit;

   public Monster battleMonster;

   public void setUpMonster()
   {
       battleMonster = new Monster(_base,_level);
       if(isPlayUnit)
       {
           GetComponent<Image>().sprite = battleMonster._base.back;
       }
       else
       {
           GetComponent<Image>().sprite = battleMonster._base.front;
       }
   }

   public Monster getBattleMonster()
   {
       return battleMonster;
   }
}
