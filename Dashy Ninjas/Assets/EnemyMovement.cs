using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform groundDetector;
    public float speed = 5f;
    public bool movingRight = true;
	
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.position, Vector2.down, 1f);

        if(hit.collider == null)
        {
            if(movingRight)
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
	}
}
