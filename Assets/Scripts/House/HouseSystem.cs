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
        // yield return (houseDialogue.TypeDialog("You were born in a small lovely town. People here are nice and friendly, and enjoy the serenity here..."));
        // yield return new WaitForSeconds(1f);
        // yield return (houseDialogue.TypeDialog("However, there was recently some rumors that destroy your peaceful life. A monster was witnessed to appear in the dark forest!"));
        // yield return new WaitForSeconds(1f);
        // yield return (houseDialogue.TypeDialog("When you wake up today, you can't find you friend, who has been living with you for years. It is said that he was kidnapped by the monster!"));
        // yield return new WaitForSeconds(1f);
        yield return (houseDialogue.TypeDialog("It's time to fight! Search for something useful in this room and pick it up by Space."));
        yield return new WaitForSeconds(1f);
        //HouseDialogueController.SetActive(false);
        dialogueBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
