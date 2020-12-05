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

    Monster _monster;
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
        _monster = monster;

        hpBar.fillAmount = monster.currentHP/monster.maxHP;
        name.text = monster.getName();
    }

    public void UpdateHP() {
        hpBar.fillAmount = ((float)_monster.currentHP/_monster.maxHP);
        // Debug.Log("hub monster hp: " + _monster.currentHP);
        // Debug.Log("hub monster maxhp: " + _monster.maxHP);
        // Debug.Log("current fill amount: " + hpBar.fillAmount);
    }
}
