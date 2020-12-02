using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SowrdController : MonoBehaviour
{
    
    public Transform player;
    public Image swordImg;
    public float distance;
    public float minDistance = 3f;

    void FixedUpdate() {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= minDistance)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                swordImg.enabled=true;
                Destroy(gameObject);
                
            }
        }
    }

}
