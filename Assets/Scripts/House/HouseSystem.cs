using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSystem : MonoBehaviour
{

    public HouseDialogueController houseDialogue;
    public GameObject dialogueBox;
    bool storystate = true;

    public void Start()
    {
        dialogueBox.SetActive(true);
        StartCoroutine(setUp());

        
    }
    // Start is called before the first frame update

    public IEnumerator setUp()
    {   
        dialogueBox.SetActive(true);
        yield return (houseDialogue.TypeDialog("Hey Kong, this is your little house. Your friend Ming has been kidnapped, you have to save him."));
        yield return new WaitForSeconds(1f);
        yield return (houseDialogue.TypeDialog("Try to move around by WASD, press 'ESC' to see the Menu for more game control details"));
        yield return new WaitForSeconds(1f);
        yield return (houseDialogue.TypeDialog("It's time to fight! Search for your ultimate blade 'Excalibur' and pick up by pressing 'Space'."));
        yield return new WaitForSeconds(1f);
        //HouseDialogueController.SetActive(false);
        dialogueBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
