using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {
    public Rigidbody2D body;

    void Start()
    {
        StartCoroutine(timer(4));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Target>() != null)
        {
            col.gameObject.GetComponent<Target>().takeDamage(1);
            Destroy(gameObject);
        }
    }
    public void shoot(Vector2 vector)
    {
        body.AddForce(vector * 400);
    }
    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
