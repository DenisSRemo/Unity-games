using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour {
    
    public TextMeshProUGUI TimerText;
    private float startTime;
    void Start () {
        startTime = Time.time;
	}

    // show the time on the screen, helping the player when to use the power up 
    //and also show after the game is over what is player's time
	void Update () {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TimerText.text = minutes + ":" + seconds;
	}
    
}
