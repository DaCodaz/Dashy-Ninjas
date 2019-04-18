using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {
    Slice slice;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Slice>()!= null)
        {
            slice = collision.gameObject.GetComponent<Slice>();
            slice.health = 0;
        }
    }
}
