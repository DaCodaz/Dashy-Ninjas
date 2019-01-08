using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject player;
    public int lastLevel, firstLevel;
    public static int level;
    float distance;

	void Start () {
        level = SceneManager.GetActiveScene().buildIndex +1;
        lastLevel = SceneManager.sceneCountInBuildSettings + 1;
        if (level == lastLevel)
        {
            level = firstLevel;
        }
	}
	
	void Update () {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < 1.5)
        {
            print(level);
            SceneManager.LoadScene(level);
        }
	}
}
