using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform groundDetector;
    public Transform playerDetector;
    public Animator anim;
    public float speed = 5f;
    public bool movingRight = true;

    void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, 1f);
        if (hit.collider == null)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }
        if (movingRight)
        {
            RaycastHit2D hat = Physics2D.Raycast(playerDetector.position, Vector2.right, 0.5f);
            if (hat.collider != null)
            {
                if (hat.collider.gameObject.GetComponent<Slice>() != null)
                {
                    Slice player = hat.collider.gameObject.GetComponent<Slice>();
                    anim.SetTrigger("Hit");
                    player.health -= 1;
                }
            }

            RaycastHit2D hit2 = Physics2D.Raycast(playerDetector.position, Vector2.right, 1f);
            if(hit2.collider != null)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        if (!movingRight)
        {
            RaycastHit2D hat = Physics2D.Raycast(playerDetector.position, Vector2.left, 0.5f);
            if (hat.collider != null)
            {
                if (hat.collider.gameObject.GetComponent<Slice>() != null)
                {
                    Slice player = hat.collider.gameObject.GetComponent<Slice>();
                    anim.SetTrigger("Hit");
                    player.health -= 1;
                }
            }
            RaycastHit2D hit2 = Physics2D.Raycast(playerDetector.position, Vector2.left, 1f);
            if (hit2.collider != null)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

    }
}
