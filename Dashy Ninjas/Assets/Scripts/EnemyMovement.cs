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
                    attack(player);
                }
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
                    attack(player);
                }
            }
        }

    }
    IEnumerator attack(Slice attacked)
    {
        anim.SetTrigger("Hit");
        attacked.health -= 1;
        yield return new WaitForSeconds(2f);
    }
}
