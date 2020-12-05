using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SowrdController : MonoBehaviour
{
    
    public Transform player;
    public Image swordImg;
    public float distance;
    public bool haveSWORD = false;
    float minDistance = 1.5f;

    void Update() {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < minDistance)
        {
            // Debug.Log("Area");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("space");
                haveSWORD = true;
                GameController.instance.haveSWORD = haveSWORD;
                swordImg.enabled=true;
                Destroy(gameObject);
                
            }
        }
    }

}
