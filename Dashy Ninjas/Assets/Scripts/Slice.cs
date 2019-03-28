using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {
    Vector2 mouseLook;
    public float moveSpeed = 8;
    public int maxUses = 3;
    public float health = 3;
    public AudioSource aSource;
    public AudioClip aClip;
    public Animator animator;
    public GameObject gOver;
    int uses;
    CharacterController2D controller;
    Rigidbody2D rb;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () {
        if (controller.m_Grounded)
        {
            uses = 0;
        }
        mouseLook = Input.mousePosition;
        mouseLook = Camera.main.ScreenToWorldPoint(mouseLook);
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && uses<maxUses)
        {
            Slash(moveSpeed);
        }
        if(health <= 0)
        {
            GameOver();
        }
    }
    void Slash(float speed)
    {
        animator.Play("Dash");
        aSource.PlayOneShot(aClip);
        rb.velocity = new Vector2(0,0);
        transform.position = Vector2.Lerp(transform.position, mouseLook, speed);
        uses += 1;
    }
    void GameOver()
    {
        gOver.SetActive(true);
        gameObject.SetActive(false);
    }

}
