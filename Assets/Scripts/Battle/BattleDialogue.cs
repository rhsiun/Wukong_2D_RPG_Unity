using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogue: MonoBehaviour
{
    public Text dialogueText;
    public int letterPerSecond;
    public Color highlightedColor;
    public GameObject actionSelector;
    public GameObject moveSelector;
    public GameObject moveDetails;
    public List<Text> actionTexts;
    public List<Text> moveTexts;
    public Text maxTimes;
    public Text type;
    public bool dialogueDone = false;
    public void setDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public bool getDialogueDone() {
        return dialogueDone;
    }
    public IEnumerator TypeDialog(string dialogue)
    {
        dialogueDone = false;
        dialogueText.text="";
        foreach(var letter in dialogue.ToCharArray())
        {
            dialogueText.text+=letter;
            yield return new WaitForSeconds(1f/letterPerSecond);
        }
        dialogueText.text=dialogue;
        dialogueDone = true;
    }

    public void EnableDialogText(bool enabled)
    {
        dialogueText.enabled = enabled;
    }

    IEnumerator IWillWait()
    {
        yield return new WaitForSeconds(1000f);
        // yield return StartCoroutine(WaitForInput());
        // Debug.Log("DONE");
    }
    IEnumerator WaitForInput()
    {
        while (!dialogueDone)
            yield return null;
    }
     public void EnableActionSelector(bool enabled)
    {
        //StartCoroutine(IWillWait());
        actionSelector.SetActive(enabled);
    }
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for(int i=0; i<actionTexts.Count; i++)
        {
            if(i==selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            }
            else
            {
                actionTexts[i].color = Color.black;  
            }
        }
    }


      public void UpdateMoveSelection(int selectedMove,Move move)
    {
        for(int i=0; i<moveTexts.Count; i++)
        {
            if(i==selectedMove)
            {
                moveTexts[i].color = highlightedColor;
            }
            else
            {
                moveTexts[i].color = Color.black;  
            }

            maxTimes .text= $"MaxTimes{move.maxTimes}/{move._Base.getMaxTimes()}";
            type.text = move._Base.type.ToString();
        }
    }
    public void SetMoveNames(List<Move> moves)
    {
        //Debug.Log(moves.Count);
        for(int i=0; i<moveTexts.Count; i++)
        {
            if(i<moves.Count)
            {
                Debug.Log(moves[i]._Base.name);
                moveTexts[i].text = moves[i]._Base.name;
            }
            else
            {
                moveTexts[i].text="-";
            }
        }
    }

}
