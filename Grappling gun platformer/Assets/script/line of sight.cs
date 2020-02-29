using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineofsight : MonoBehaviour
{
    public float startTime;
    public bool spotted=false;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (spotted == true && Time.time - startTime >= 4)
            Debug.Log("Game over");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startTime = Time.time;
            spotted = true;
        }
    }
    
}
