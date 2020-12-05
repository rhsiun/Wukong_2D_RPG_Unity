using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //Create instance
    public static GameController instance;
    public bool haveSWORD;
    public Image swordImg;
    public bool exitedHouse = false;

    //Outlets
    

    // Start is called before the first frame update
    void Start()
    {
        if(haveSWORD) {
            swordImg.enabled=true;
        }
    }

    //Set instance
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
