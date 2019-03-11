using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject player;
    public int lastLevel, firstLevel;
    public bool target;
    public static int level;
    public float req = 1.5f;
    float distance;

	void Start () {
        //if(target == true)
        //{
        //    level = SceneManager.GetActiveScene().buildIndex + 1;
        //}
        //if(target == false)
        //{
        //    level = SceneManager.GetActiveScene().buildIndex - 1;
        //}
        //if (level == lastLevel)
        //{
        //    level = firstLevel;
        //}
        level = Random.Range(firstLevel, lastLevel);
	}
	
	void Update () {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distance < req)
        {
            print(level);
            SceneManager.LoadScene(level);
        }
	}
}
