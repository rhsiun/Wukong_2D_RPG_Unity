using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Transform guardian;
    public HomeDialogue homeDialogue;
    float distance = 1.5f;
    bool storystate = true;

    public void Start()
    {
        if(storystate)
        {
            StartCoroutine(setUp());
        }
       
       
    }
    // Start is called before the first frame update

     public IEnumerator setUp()
    {   
        //To do: Use own code for coroutine
        //  StartCoroutine(battleDialogue.TypeDialog($"A wild {battleUnit.getBattleMonster()._base.name} appeared"));
        yield return (homeDialogue.TypeDialog("Let's find out the mosnter to save your friend!"));
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
