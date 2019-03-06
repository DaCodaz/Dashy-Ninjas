using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    bool canHit;
    Target target;
    public Transform attackPoint;
    public Animator animator;
    public float attackDist = 1f;
    public float dam = 1;
    public FaceMouse faceMouse;
    RaycastHit2D hit;

    void FixedUpdate () 
    {
        if (faceMouse.lookRight)
        {
            hit = Physics2D.Raycast(attackPoint.position, Vector2.right, attackDist);
            if (hit.collider != null)
            {
                if(hit.collider.GetComponent<Target>() != null)
                {
                    target = hit.collider.GetComponent<Target>();
                    canHit = true;
                }
                else { canHit = false; }
            }
            else { canHit = false; }
        }
        if(!faceMouse.lookRight)
        {
            hit = Physics2D.Raycast(attackPoint.position, Vector2.left, attackDist);
            if (hit.collider != null)
            {
                if(hit.collider.GetComponent<Target>() != null)
                {
                    target = hit.collider.GetComponent<Target>();
                    canHit = true;
                }
                else { canHit = false; }
            }
            else { canHit = false; }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
            if (canHit)
            {
                target.takeDamage(dam);
            }
        }
    }
}
