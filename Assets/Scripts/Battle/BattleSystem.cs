using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleUnit battleUnit;
    public BattleHud battleHud;

    public void Start()
    {
        setUp();
    }

    public void setUp()
    {
        battleUnit.setUpMonster();
        battleHud.setUpHud(battleUnit.getBattleMonster());
    }
}
