using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobSimple : MonoBehaviour {
    public CharacterController2D controller;
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    void FixedUpdate()
    {
        hit1 = Physics2D.Raycast(transform.position, Vector2.left);
        hit2 = Physics2D.Raycast(transform.position, Vector2.right);
    }

    void Update () 
    {
        if(hit1.collider != null)
        {
            if(hit1.collider.gameObject.name == "Player")
            {
                float dist = Vector2.Distance(transform.position, hit1.collider.transform.position);
                if(dist <= 6)
                {
                    controller.Move(-1 * Time.deltaTime, false, false);
                }
            }
        }
        if (hit2.collider != null)
        {
            if (hit2.collider.gameObject.name == "Player")
            {
                float dist = Vector2.Distance(transform.position, hit2.collider.transform.position);
                if (dist <= 6)
                {
                    controller.Move(1 *Time.deltaTime, false, false);
                }
            }
        }
    }
}
