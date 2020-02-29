using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public float speed;
    public int maxh;
    public int currenth;
    public float startTime;
    private Rigidbody2D rb;
    private bool facingRight;
    public float ExplosionRadius = 1f;
    public float ExplosiveForce = 1f;
    public Animator animator;
    public bool spinning;
    public AudioClip pterodactyl;
    public AudioClip punch;
    private AudioSource source1;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private float Vol = 3.0f;
    void Awake()
    {
        source1 = GetComponent<AudioSource>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        startTime = Time.time;
        currenth = maxh;
    }
    //Power up
    void Update()
    {
        if(Time.time-startTime>=60 && Input.GetKey(KeyCode.LeftShift) && !spinning)
        {
            spinning = true;
            startTime = Time.time;
            animator.SetTrigger("PowerUp");

 
        }

        if (Time.time - startTime >= 10 && spinning)
        {
            spinning = false;
            animator.SetTrigger("StopSpin");
            startTime = Time.time;
        }

    }

    //Player's movement
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Vector3 vel = rb.velocity;
        vel.x = Horizontal;
        vel.y = Vertical;
        rb.velocity = vel;
        Flip(Horizontal);
    }
    //this makes the player turn left or right so that it faces the right direction
        private void Flip(float Horizontal)
        {
            if(Horizontal>0 && !facingRight || Horizontal<0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

            }
        }
    //when the power up is on, the player is in some sort of "godmode" and the meteorites ricochet from the player
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Meteorite" && spinning == false)
        {
            GameControl.health -= 1;
            float vol = Vol;
            source1.PlayOneShot(punch, vol);

        }
        else
            if(col.gameObject.tag == "Meteorite" && spinning == true)
        {
            foreach (var item in Physics2D.CircleCastAll(transform.position, ExplosionRadius, transform.right))
            {

                if (item.rigidbody)
                {

                    item.rigidbody.AddForce((item.transform.position - transform.position) * ExplosiveForce, ForceMode2D.Impulse);
                }
            }
        }
       
    }
}