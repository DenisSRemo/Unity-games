﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5f;
    private Rigidbody2D rb;
    private bool facingRight;
    public bool crouching=false;
    public Animator animator;
    public bool right ;
    public Vector3 StartingPosition;
    private float StartTime;
    private bool spotted;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        right = true;
        StartingPosition = gameObject.transform.position;
        StartTime = Time.time;
    }
   
    //Player's movement
    private void Update()
    {
        
        //crouch mechanic
        if(Input.GetKeyUp(KeyCode.LeftControl) && crouching==false)
        {
            crouching = true;
            animator.SetBool("shouldCrouch", true);
            speed = 2f;
        }
        else
            if (Input.GetKeyUp(KeyCode.LeftControl) && crouching == true)
        {
            crouching = false;
            animator.SetBool("shouldCrouch", false);
            speed = 5f;
        }
        

        Vector3 pos = transform.position;


        if (Input.GetKey("d"))
        {
           
            pos.x += speed * Time.deltaTime;
            right = true;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            right = false;
        }


        transform.position = pos;

        Flip(right);


        if (spotted == true && Time.time - StartTime >= 2)
        {
            gameObject.transform.position = StartingPosition;
            spotted = false;
        }
    }
    //this makes the player turn left or right so that it faces the right direction
    private void Flip(bool right)
    {
        if (right==true && !facingRight || right==false && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "hazard")
        {
            gameObject.SetActive(false);
            gameObject.transform.position = StartingPosition;
            gameObject.SetActive(true);
        }
        else
            if (col.gameObject.tag == "enemy")
            {
                StartTime = Time.time;
                spotted = true;
            }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && spotted == true && Time.time - StartTime < 2)
        {
            spotted = false;
            StartTime = Time.time;
        }

    }
}
