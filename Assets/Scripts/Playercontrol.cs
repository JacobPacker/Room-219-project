using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w"))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 12f;    // give the player a velocity of 5 in the y axis

            }
        }

        rb.velocity = velocity;

    }
    void DoFaceLeft( bool faceLeft) 
    {
        if( faceLeft == true)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else 
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }

    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -15;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = 15;
        }
        rb.velocity = velocity;

        if (velocity.x < -0.5)
        {
            DoFaceLeft(true);
        }
        if (velocity.x > 0.5f)
        {
            DoFaceLeft(false);
        }

    }
}