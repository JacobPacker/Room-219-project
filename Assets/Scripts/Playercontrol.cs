using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Playercontrol : MonoBehaviour
{
    // start is called before the first frame u
    private Animator anim;
    private Rigidbody2D rb;
    
    public GameObject projectilePrefab;
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
        if (Helper.DoRayCollisionCheck(gameObject) == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        bool result = Helper.DoRayCollisionCheck(gameObject);
    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w")&&(Helper.DoRayCollisionCheck(gameObject) == true))
        {
            if (velocity.y < 0.001f)
            {
                velocity.y = 12f;    // give the player a velocity of 12 in the y axis

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
        
        
        if (velocity.x > 0 || velocity.x < 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        Helper.SetVelocity(gameObject, velocity.x, velocity.y);
        // Flips sprite depending on which way they are facing
        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Left);
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&(transform.localRotation.x == 0) )
        {
            // Launch projectile from player
            Helper.MakeBullet(projectilePrefab, transform.position.x + 7, transform.position.y + 3, 40.0f, 0f);

        }
       
    }
   

}