using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Comment test to push
public class PlayerMovement : MonoBehaviour
{
    private float Horizontal;
    public float runSpeed = 1;
    public float jumpSpeed = 1;
    public bool isHurt = false;
    Rigidbody2D rb2;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public GameObject BalaPrefab;
    private float LastShoot;

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
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (!isHurt){
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2.velocity = new Vector2(runSpeed,rb2.velocity.y);
            //spriteRenderer.flipX = false;
            animator.SetBool("Run",true);
        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2.velocity = new Vector2(-runSpeed,rb2.velocity.y);
            //spriteRenderer.flipX = true;
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

            if (Input.GetKey(KeyCode.E)&&Time.time>LastShoot+0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
    }
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bala = Instantiate(BalaPrefab, transform.position+(direction*0.1f), Quaternion.identity);
        bala.GetComponent<Bala_script>().SetDirection(direction);
        
    }

IEnumerator HurtCharacter()
{
    isHurt = true;
    animator.SetBool("Hurt",true);
    yield return new WaitForSeconds(1.5f);
    animator.SetBool("Hurt",false);
    isHurt = false;
}
}
