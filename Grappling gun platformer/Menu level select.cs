﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("2 Basic Map Layout LSavvides");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
