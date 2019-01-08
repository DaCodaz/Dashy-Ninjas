﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {
    Vector2 mouseLook;
    public float moveSpeed = 8;
    public LineRenderer line;
    public EdgeCollider2D lineCollider;
    public int maxUses = 3;
    public AudioSource aSource;
    public AudioClip aClip;
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
            StartCoroutine(Slash(moveSpeed));
        }
	}
    IEnumerator Slash(float speed)
    {
        Vector2[] points = lineCollider.points;
        line.enabled = true;
        line.SetPosition(0, transform.position);
        lineCollider.enabled = true;
        transform.position = Vector2.Lerp(transform.position, mouseLook, speed);
        aSource.PlayOneShot(aClip);
        line.SetPosition(1, transform.position);
        points[0] = line.GetPosition(0);
        points[1] = line.GetPosition(1);
        lineCollider.points = points;
        yield return new WaitForSeconds(0.2f);
        lineCollider.enabled = false;
        line.enabled = false;
        uses += 1;
    }
}
