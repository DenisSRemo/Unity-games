using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    //health system
    public GameObject Heart1, Heart2, Heart3, Heart4, gameOver, Restart,MainMenu,Quit;
    public static int health;
    void Start()
    {
        health = 4;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        Heart4.SetActive(true);
       gameOver.SetActive(false);
        Restart.SetActive(false);
        MainMenu.SetActive(false);
       // Quit.SetActive(false);
    }

    //everytime the player gets hit a hearth is gone
    void Update()
    {
        if (health > 4)
            health = 4;
        switch (health)
        {
            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                // UI interface when the game is over
                gameOver.SetActive(true);    
                Restart.SetActive(true);
                MainMenu.SetActive(true);
                MainMenu.SetActive(true);
                Time.timeScale = 0;
                health = 4;
                break;
        }
    }
}

