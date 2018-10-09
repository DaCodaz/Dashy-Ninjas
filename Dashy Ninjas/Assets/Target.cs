﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public GameObject player;
    EdgeCollider2D lineCol;
    // Use this for initialization
    void Start () {
        lineCol = player.GetComponentInChildren<EdgeCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector2.Distance(gameObject.transform.position, lineCol.transform.position);
        if (dist == 0) takeDamage();
	}
    void takeDamage()
    {
        Destroy(gameObject);
    }
}
