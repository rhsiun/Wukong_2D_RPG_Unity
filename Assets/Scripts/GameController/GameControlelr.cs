using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlelr : MonoBehaviour
{

    //Create instance
    public static GameControlelr instance;

    //Outlets
    public GameObject[] pokemonPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
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
