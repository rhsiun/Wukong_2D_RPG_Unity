using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    //instances
    public HouseDialogueController houseDialogue;
    public HomeDialogue homeDialogue;
    public GameObject dialogueBox;
    private bool exitedHouse;
    private bool haveSword;

    private void Start() {
        exitedHouse = GameController.instance.exitedHouse;
        haveSword = GameController.instance.haveSWORD;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(this.CompareTag("House")){
                if(exitedHouse && haveSword){
                    StartCoroutine(doNotGoBackInDialogue());
                } else {
                   new WaitForSeconds(1f);
                   SceneManager.LoadScene(1);
                }
            }
            if(this.CompareTag("Enemy")){
                new WaitForSeconds(1f);
                SceneManager.LoadScene(3);
            }
            if(this.CompareTag("Field")) {
                if(haveSword){
                    new WaitForSeconds(1f);
                    SceneManager.LoadScene(2);
                    GameController.instance.exitedHouse = true;
                } else {
                    StartCoroutine(doNotGoOutDialogue());
                }
            }
            if(this.CompareTag("Cave")) {
                new WaitForSeconds(1f);
                SceneManager.LoadScene(4);
            }
        }
    }

    private void Update() {
        exitedHouse = GameController.instance.exitedHouse;
        haveSword = GameController.instance.haveSWORD;
    }

    public IEnumerator doNotGoBackInDialogue()
    {   
        dialogueBox.SetActive(true);
        yield return (homeDialogue.TypeDialog("Do not go back! Go find your friend!"));
        yield return new WaitForSeconds(1f);
        //HouseDialogueController.SetActive(false);
        dialogueBox.SetActive(false);
    }

    public IEnumerator doNotGoOutDialogue()
    {   
        dialogueBox.SetActive(true);
        yield return (houseDialogue.TypeDialog("Do not go out yet! Go find yourself a weapon!"));
        yield return new WaitForSeconds(1f);
        //HouseDialogueController.SetActive(false);
        dialogueBox.SetActive(false);
    }
}
