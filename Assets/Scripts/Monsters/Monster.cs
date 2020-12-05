using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public MonsterBase _base;
    public int _level;
    public int currentHP;
    public int maxHP;

    public List<Move> _moves;

    public Monster(MonsterBase mBase, int mLevel)
    {
        _base = mBase;
        _level = mLevel;
        _moves = new List<Move>();
        maxHP = _base.maxhp;
        currentHP = _base.maxhp;
        foreach (var singleMove in _base.learnablemove)
        {
            if(singleMove.level <= _level)
            {
                _moves.Add(new Move(singleMove.movebase));

                if(_moves.Count>=4)
                    break;
            }
        }

    }
     public string getName()
   {
       return _base.getName();
   }

    public int attack
    {
        get{return Mathf.FloorToInt((_base.attack * _level)/100f)+5;}
    }

    public int defense
    {
        get{return Mathf.FloorToInt((_base.defense * _level)/100f)+5;}
    }

    public List<Move> getMoves()
    {
        return _moves;
    }

    public bool TakeDamage(Move move, Monster attacker) {
        int damage = Mathf.FloorToInt(move._Base.power*((float)attacker.attack / defense));
        Debug.Log(damage);
        currentHP -= damage;
        if(currentHP <= 0) {
            currentHP = 0;
            return true;
        }

        return false;
    }

    public Move GetRandomMove() {
        int r = Random.Range(0, _moves.Count);
        return _moves[r];

    }
}
