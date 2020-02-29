using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookContact : MonoBehaviour
{
    public grappling_gun grappleScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent = collision.transform;
        grappleScript.grappleDistance = Vector2.Distance(grappleScript.holster.transform.position, grappleScript.hook.transform.position);
        grappleScript.isGrappled = true;
    }
}

