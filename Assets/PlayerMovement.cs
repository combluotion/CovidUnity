using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Comment test to push
public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 1;
    public float jumpSpeed = 1;
    Rigidbody2D rb2;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public bool betterJump = true;
    public float highJump = 0.5f;
    public float lowJump = 1f;

    
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2.velocity = new Vector2(runSpeed,rb2.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run",true);
        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2.velocity = new Vector2(-runSpeed,rb2.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run",true);
        }
        else{
            rb2.velocity = new Vector2(0,rb2.velocity.y);
            animator.SetBool("Run",false);
        }

        if(Input.GetKey("space") && isGrounded.value)
        {
            rb2.velocity = new Vector2(rb2.velocity.x,jumpSpeed);
            animator.SetBool("Run",false);
            animator.SetBool("Jump",true);            
        }
        if(!Input.GetKey("space"))
        {
            animator.SetBool("Jump",false);
        }

        if(betterJump)
        {
            if(rb2.velocity.y <0)
            {
                rb2.velocity += Vector2.up * Physics2D.gravity * (highJump) * Time.deltaTime;
            }

            if(rb2.velocity.y >0 && !Input.GetKey("space")){
                rb2.velocity += Vector2.up * Physics2D.gravity * (lowJump) * Time.deltaTime;
            }

        }
    }
}
