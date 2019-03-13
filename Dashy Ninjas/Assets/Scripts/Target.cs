using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float hp = 1;
    public GameObject coin;
    public void takeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Transform pos = gameObject.transform;
            Instantiate(coin, pos.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
