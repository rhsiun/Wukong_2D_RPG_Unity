using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    //Create Instance and outlets
    public static MenuController instance;
    public GameObject mainMenu;
    public GameObject profileMenu;
    public GameObject optionsMenu;
    public GameObject mapMenu;
    public Image swordImg;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Assign instance
    void Awake()
    {
        instance = this;
        Hide();
        swordImg.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchMenu(GameObject someMenu)
    {
        //Turn off all menu
        mainMenu.SetActive(false);
        profileMenu.SetActive(false);
        optionsMenu.SetActive(false);
        mapMenu.SetActive(false);

        //Turn on the required menu
        someMenu.SetActive(true);
    }

    public void Show()
    {
        ShowMainMenu();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowMainMenu()
    {
        SwitchMenu(mainMenu);
    }

    public void ShowProfileMenu()
    {
        SwitchMenu(profileMenu);
    }

     public void ShowOptionsMenu()
    {
        SwitchMenu(optionsMenu);
    }

     public void ShowMapMenu()
    {
        SwitchMenu(mapMenu);
    }
}
