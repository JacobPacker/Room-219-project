using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public GameObject player;
    public float enemyspeed;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void DoFaceLeft(bool faceLeft)
    {
        if (faceLeft == true)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < -transform.position.x)
        {
            DoFaceLeft(true);
        }
        if (player.transform.position.x > transform.position.x)
        {
            DoFaceLeft(false);
        }
        //Throw spear when player is less than 20m away
        float ex = transform.position.x;

        float px = player.transform.position.x;

        float dist = ex - px;
        
        if (dist < 20 && dist > -20) 
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }
    void SayHello()
    {
        print("hello");
    }
}
