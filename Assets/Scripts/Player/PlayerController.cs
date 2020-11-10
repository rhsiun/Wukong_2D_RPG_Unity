﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Outlets
    private float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    //Static variables
    private float initialSpeed = 5;
    
    private void Update() {
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Prevent diagonal movement
            if(input.x != 0) input.y = 0;
            if(input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }   
    }

    IEnumerator Move(Vector3 targetPos){
        isMoving = true; 

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos,
            moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private void Start() {
        moveSpeed = initialSpeed;
    }   
}