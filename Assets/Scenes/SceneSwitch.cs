﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(this.CompareTag("House")){
                SceneManager.LoadScene(1);
            }
            if(this.CompareTag("Enemy")){
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
       
    }
}
