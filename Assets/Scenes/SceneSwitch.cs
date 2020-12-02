using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(this.CompareTag("House")){
                new WaitForSeconds(1f);
                SceneManager.LoadScene(0);
            }
            if(this.CompareTag("Enemy")){
                new WaitForSeconds(1f);
                SceneManager.LoadScene(2);
            }
            if(this.CompareTag("Field")) {
                new WaitForSeconds(1f);
                SceneManager.LoadScene(1);
            }
            if(this.CompareTag("Cave")) {
                new WaitForSeconds(1f);
                SceneManager.LoadScene(3);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
       
    }
}
