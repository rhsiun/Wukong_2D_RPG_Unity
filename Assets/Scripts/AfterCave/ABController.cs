using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABController : MonoBehaviour
{
    //public Transform guardian;
    public ABDialogue abDialogue;
    public GameObject dialogueBox;
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
        dialogueBox.SetActive(true);
        yield return (abDialogue.TypeDialog("Mission Completed! You have saved your friend! "));
        yield return new WaitForSeconds(1f);
        yield return (abDialogue.TypeDialog("Thanks for playing, have a wonderful day!"));
        yield return new WaitForSeconds(1f);
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
