using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public float speed1 = 1f;
    public float speed2 = 0f;
    public float r = -1;
    private float StartTime;
    private bool facingRight;
    private bool chase;
    public Transform target;
    void Start()
    {
        StartTime = Time.time;
        facingRight = true;
        speed = speed1;
        r = -1;
        //  chase = false;
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        transform.position += r * transform.right * speed;
        if (Time.time - StartTime >= 4)
        {
            StartTime = Time.time;
            speed = speed1;
            Flip(r);
            
        }

        // if(chase==true)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "block")
        {
            r = -r;
            StartTime = Time.time;
            speed = speed2;
            // chase = false;




            Debug.Log("stay");
        }


        if (col.gameObject.tag == "Player")
        {
            //chase = true;
        }


    }



    private void Flip(float r)
    {
        if (r < 0 && !facingRight || r > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }

}
