using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AGDialogue : MonoBehaviour
{
    //Outlet 
    public Text dialogueText;
    public int letterPerSecond;

    public void setDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public IEnumerator TypeDialog(string dialogue)
    {
        dialogueText.text="";
        foreach(var letter in dialogue.ToCharArray())
        {
            dialogueText.text+=letter;
            yield return new WaitForSeconds(1f/letterPerSecond);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
