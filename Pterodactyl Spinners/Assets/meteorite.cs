using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorite : MonoBehaviour {

    public float speed;
    private float StartTime;
    public float delaytime;
    public float LifeTime;
    private float r = 5;
    public Vector3 StartingPosition;
    public float respawns;
    void Start () {
        StartingPosition = gameObject.transform.position;
        StartTime = Time.time + delaytime;
        respawns = 0;
    }
	
	//movement and cycle of the meteorite
	void Update () {
        if (Time.time >= StartTime)
        {
            transform.position += -transform.right * speed;

            if (Time.time >= StartTime + LifeTime)
            {
                respawns = respawns +1;
                gameObject.SetActive(false);
                gameObject.transform.position = StartingPosition;
                gameObject.SetActive(true);
                StartTime = Time.time;
                if (respawns % 6 == 0)
                {
                    speed = speed + speed / r;
                    r++;
                }
            }
        }
        
	}
   
    
}
