using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitch : MonoBehaviour {
    //functions for the buttons that makes the transition between scenes
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        
    }
    public void GotoCotrolsScene()
    {
        SceneManager.LoadScene("Controls");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
