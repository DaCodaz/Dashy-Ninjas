using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject player;
    public GameObject closed;
    public int lastLevel, firstLevel;
    //public AudioSource source;
    //public AudioClip closeDoor, openDoor;
    public Transform pos;
    public bool target;
    public static int level;
    public float req = 1.5f;
    bool canEnter;
    float distance;

	void Start () {
        level = Random.Range(firstLevel, lastLevel);
        closed.SetActive(false);
	}
	
	void Update () {
        distance = Vector2.Distance(player.transform.position, pos.position);
        if (FindObjectOfType(typeof(Target)) != null)
        {
            closed.SetActive(true);
        }
        if(FindObjectOfType(typeof(Target)) == null)
        {
            closed.SetActive(false);
        }
        if (distance < req & closed.activeInHierarchy == false)
        {
            print(level);
            SceneManager.LoadScene(level);
        }
	}
}
