using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    public GameObject player;
    public bool lookRight = true;
    Vector3 CharScale;

	void Update () 
    {
        if(Input.touchCount > 0)
        {
            Vector2 mouse = new Vector2(Input.GetTouch(0).position.x, Screen.height - Input.GetTouch(0).position.y);
            Vector2 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);
            if (mouse.x > playerScreenPoint.x && !lookRight)
            {
                lookRight = true;
                Flip();
            }
            if (mouse.x < playerScreenPoint.x && lookRight)
            {
                lookRight = false;
                Flip();
            }
        }
    }
    void Flip()
    {
        if(!lookRight)
        {
            CharScale = transform.localScale;
            CharScale.x *= -1;
            transform.localScale = CharScale;
        }
        if (lookRight)
        {
            CharScale = transform.localScale;
            CharScale.x *= -1;
            transform.localScale = CharScale;
        }
    }
}
