using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    bool canHit;
    Target target;
    public Animator animator;
    public GameObject shuriken;
    public FaceMouse faceMouse;
    public AudioSource source;
    public AudioClip shuri;
    RaycastHit2D hit;


    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)
        {
            source.PlayOneShot(shuri);
            float posX;
            if (faceMouse.lookRight)
            {
                posX = transform.position.x + 1f;
            }
            else
            {
                posX = transform.position.x - 1f;
            }
            Vector2 pos = new Vector2(posX, transform.position.y);
            GameObject shur = Instantiate(shuriken, pos, Quaternion.identity);
            Shuriken shurComp = shur.GetComponent<Shuriken>();
            if (faceMouse.lookRight)
            {
                shurComp.shoot(Vector2.right);
            }
            if (!faceMouse.lookRight)
            {
                shurComp.shoot(Vector2.left);
            }
        }
    }
}
