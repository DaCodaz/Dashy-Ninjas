using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    bool canHit;
    Target target;
    public Transform attackPoint;
    public Animator animator;
    public float dam = 1;

	void FixedUpdate () 
    {
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, Vector2.right, 5f);
        if (hit.collider.GetComponent<Target>() != null)
        {
            print("wow");
            //target = hit.collider.GetComponent<Target>();

        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) & target != null)
    //    {
    //        print("wow");
    //        animator.Play("Attack");
    //        target.takeDamage(dam);
    //    }
    //}
}
