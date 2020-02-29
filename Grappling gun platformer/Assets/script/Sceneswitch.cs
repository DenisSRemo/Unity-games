using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitch : MonoBehaviour {
    //functions for the buttons that makes the transition between scenes
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GotoGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("level menu");
        
    }
    public void GotoCotrolsScene()
    {
        SceneManager.LoadScene("2 Basic Map Layout LSavvides");
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
