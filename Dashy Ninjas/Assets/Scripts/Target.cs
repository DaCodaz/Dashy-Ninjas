using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public GameObject line;
    EdgeCollider2D lineCol;
    // Use this for initialization
    void Start () {
        lineCol = line.GetComponent<EdgeCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector2.Distance(gameObject.transform.position, lineCol.transform.position);
        if (lineCol.enabled == true){ if (dist < 1) takeDamage(); }
	}
    void takeDamage()
    {
        Destroy(gameObject);
    }
}
