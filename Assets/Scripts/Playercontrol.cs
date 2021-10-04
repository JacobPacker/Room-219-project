using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // start is called before the first frame u
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;
    public GameObject objDestroy;
    pubic GameObject objToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        if (isGrounded == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w")&&(isGrounded == true))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 12f;    // give the player a velocity of 5 in the y axis

            }
        }

        rb.velocity = velocity;

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
        
        if (velocity.x > 0 || velocity.x < 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, true);
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, false);
        }
        if (Input.GetKey("z"))
        {

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}