﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("HouseScene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
