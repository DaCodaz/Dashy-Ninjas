using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject player;
    public string level;
    float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < 1)
        {
            print(level);
            SceneManager.LoadScene(level);
        }
	}
}
