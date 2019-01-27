using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public float reqDist = 1;
    GameObject player;
    coinManager manager;
    float dist;

    void Start () {
        player = GameObject.FindWithTag("Player");
        manager = player.GetComponent<coinManager>();
    }
    void Update()
    {
        Collect();
    }
    void FixedUpdate () {
        dist = Vector2.Distance(gameObject.transform.position, player.transform.position);
    }
    void Collect()
    {
        if (dist < reqDist)
        {
            Destroy(gameObject);
            manager.counter += 1;
        }
    }
}
