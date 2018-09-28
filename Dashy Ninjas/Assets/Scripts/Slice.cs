using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour {
    Vector2 mouseLook;
    public float moveSpeed = 8;
    public LineRenderer line;
    public int maxUses = 3;
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
        line.enabled = true;
        line.SetPosition(0, transform.position);
        transform.position = Vector2.Lerp(transform.position, mouseLook, speed);
        line.SetPosition(1, transform.position);
        yield return new WaitForSeconds(0.2f);
        line.enabled = false;
        uses += 1;
    }
}
