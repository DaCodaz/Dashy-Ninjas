using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    bool canHit;
    Target target;
    public Transform attackPoint;
    public Animator animator;
    public GameObject shuriken;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float posX;
            if (faceMouse.lookRight)
            {
                posX = transform.position.x + 1f;
            }
            else
            {
                posX = transform.position.x - 1f;
            }
            Vector2 pos = new Vector2(posX,transform.position.y);
            GameObject shur = Instantiate(shuriken, pos, Quaternion.identity);
            Shuriken shurComp = shur.GetComponent<Shuriken>();
            if (faceMouse.lookRight)
            {
                shurComp.shoot(Vector2.right);
            }
            if (!faceMouse.lookRight)
            {
                shurComp.shoot(Vector2.left);
            }
        }
    }
}
