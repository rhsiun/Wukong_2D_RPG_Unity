using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AGController : MonoBehaviour
{
    //public Transform guardian;
    public AGDialogue agDialogue;
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
        yield return (agDialogue.TypeDialog("Now you have defeated the guardian, go inside the cave!"));
        yield return new WaitForSeconds(1f);
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
