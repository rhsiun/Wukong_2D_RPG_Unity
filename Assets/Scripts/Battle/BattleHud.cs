using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    //Outlet
    public Image hpBar;
    public Text name;
    public Text level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUpHud(Monster monster)
    {
        hpBar.fillAmount = monster.currentHP/monster.maxhp;
        name.text = monster.getName();
        //level.text = "Lvl: "+monster._level;
    }
}
