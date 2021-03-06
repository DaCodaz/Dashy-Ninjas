﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public float reqDist = 1;
    public AudioSource aSource;
    public AudioClip aClip;
    GameObject player;
    coinManager manager;
    float dist;

    void Start () {
        player = GameObject.FindWithTag("Player");
        print(player);
        manager = player.GetComponent<coinManager>();
        print(manager);
        aSource = player.GetComponent<AudioSource>();
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
            aSource.PlayOneShot(aClip);
            CoinCounter.counter += 1;
            Destroy(gameObject);
        }
    }
}
