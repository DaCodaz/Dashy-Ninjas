using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {
    Vector2 mouseLook;
    public float moveSpeed = 8;
    public float myDamage = 1;
    //bool isDashing;
    public int maxUses = 3;
    public AudioSource aSource;
    public AudioClip aClip;
    public Animator animator;
    int uses;
    CharacterController2D controller;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }
    void Update () {
        if (controller.m_Grounded)
        {
            uses = 0;
        }
        mouseLook = Input.mousePosition;
        mouseLook = Camera.main.ScreenToWorldPoint(mouseLook);
        if (Input.GetButtonDown("Fire1") && uses<maxUses)
        {
            Slash(moveSpeed);
        }
	}
    void Slash(float speed)
    {
        animator.Play("Dash");
        //isDashing = true;
        aSource.PlayOneShot(aClip);
        transform.position = Vector2.Lerp(transform.position, mouseLook, speed);
        //isDashing = false;
        uses += 1;
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "target" && isDashing)
    //    {
    //        col.gameObject.GetComponent<Target>().takeDamage(myDamage);
    //    }
    //}
}
