using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappling_gun : MonoBehaviour
{
    public Vector3 hookTarget;
    public float pullAmount;
    public bool isGrappled = false;
    public float grappleDistance;
    public Camera cam;
    public GameObject holster;
    public GameObject hook;
    public float hookShootSpeed;
    public float playerMoveSpeed;
    public bool isFired = false;

   
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public float maxDistance = 7;
    public float minDistance = 0.5f;
    public LayerMask mask;
    public LineRenderer line;
    public float step = 0.2f;
    Rigidbody2D rb;
    public float g;
    Vector2 aimDirection;


    void Start()
    {
        
        line.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        g = rb.gravityScale;
    }

    //grappling gun

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isFired == false)
        {
            targetPos = cam.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            aimDirection = targetPos - transform.position;

            Debug.DrawRay(transform.position, aimDirection, Color.green, 50);

            Debug.Log("aimDirection = " + aimDirection);

            RaycastHit2D newHit = Physics2D.Raycast(transform.position, aimDirection, distance, mask);

            if (newHit.collider != null)
            {
                Debug.Log("hiuhfkahsfsdaf");
                hookTarget = newHit.point;
            }
            else if (newHit.collider == null)
            {
                return;
            }



            isFired = true;
        }


        if (Input.GetMouseButtonUp(1) && isFired == true)
        {
            RetractHook();
            isFired = false;
        }

        if (Vector2.Distance(hook.transform.position, holster.transform.position) > maxDistance)
        {
            Debug.Log("RETRACTING");
            RetractHook();
        }

        if (Vector2.Distance(hook.transform.position, holster.transform.position) < minDistance && isGrappled)
        {
            isGrappled = false;
            RetractHook();
        }




        if (isFired)
        {
            line.enabled = true;
            line.SetPosition(0, holster.transform.position);
            line.SetPosition(1, hook.transform.position);
            hook.transform.position = Vector2.MoveTowards(hook.transform.position, hookTarget, hookShootSpeed * Time.deltaTime);
            //hook.transform.Translate(aimDirection * (hookShootSpeed * Time.deltaTime));
        }
        else
        {
            line.enabled = false;
        }

        if (isGrappled)
        {
            rb.gravityScale = 0;
            transform.position = Vector2.MoveTowards(transform.position, hook.transform.position, playerMoveSpeed * Time.deltaTime);
        }
        else
        {
            rb.gravityScale = g;
        }



        if (!isGrappled && !isFired)
        {
            hook.transform.position = holster.transform.position;
        }






       
    }

    void RetractHook()
    {
        hookTarget = Vector3.zero;
        hook.transform.SetParent(holster.transform);
        hook.transform.localPosition = new Vector3(0, 0, 0);
        isGrappled = false;
        isFired = false;
    }
}