using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Comment test to push
public class PlayerMovement : MonoBehaviour
{

    public Joystick joystick;

    public Button buttonJump;
    private float HorizontalMove;
    private float Horizontal;
    public float runSpeed = 1;
    private int vidas = 2;
    public float jumpSpeed = 1;
    public float jumpSpeedJoystick = 5;
    public bool isHurt = false;
    Rigidbody2D rb2;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public GameObject BalaPrefab;
    private float LastShoot;
    public GameObject deathPanel;
    public GameObject[] hearts;
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
        HorizontalMove = joystick.Horizontal * runSpeed;
        if (HorizontalMove < 0.0f || Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (HorizontalMove > 0.0f || Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

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
        else if(HorizontalMove != 0f)
        {
            transform.position += new Vector3(HorizontalMove,0,0)*Time.deltaTime *runSpeed;
            animator.SetBool("Run",true);
        }

        
        else{
            rb2.velocity = new Vector2(0,rb2.velocity.y);
            animator.SetBool("Run",false);
        }

        if((Input.GetKey("space") && isGrounded.value) || (ButtonJumpOnPressed.buttonPressed && isGrounded.value))
        {
            rb2.velocity = new Vector2(rb2.velocity.x,jumpSpeed);
            animator.SetBool("Run",false);
            animator.SetBool("Jump",true);            
        }
        else if(!Input.GetKey("space") && !ButtonJumpOnPressed.buttonPressed) 
        {
            animator.SetBool("Jump",false);
        }

        if(betterJump)
        {
            if(rb2.velocity.y <0)
            {
                rb2.velocity += Vector2.up * Physics2D.gravity * (highJump) * Time.deltaTime;
            }

            if(rb2.velocity.y >0 && !Input.GetKey("space") && !ButtonJumpOnPressed.buttonPressed){
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
    public void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bala = Instantiate(BalaPrefab, transform.position+(direction*0.1f), Quaternion.identity);
        bala.GetComponent<Bala_script>().SetDirection(direction);
       

    }
    public void Jump()
    {
            if(isGrounded.value){
            rb2.velocity = new Vector2(rb2.velocity.x,jumpSpeedJoystick);
             
            animator.SetBool("Run",false);
            animator.SetBool("Jump",true);           
        

        if(betterJump)
        {
            if(rb2.velocity.y <0)
            {
                rb2.velocity += Vector2.up * Physics2D.gravity * (highJump) * Time.deltaTime;
            }

            if(rb2.velocity.y >0){
                rb2.velocity += Vector2.up * Physics2D.gravity * (lowJump) * Time.deltaTime;
            }

}
        }
    }

IEnumerator HurtCharacter()
{
        
        if (vidas < 1 )
        {
            Destroy(hearts[0].gameObject);
            deathPanel.gameObject.SetActive(true);
        }
        else
        {
            if (vidas < 3) {
                Destroy(hearts[2].gameObject);
            }
            if (vidas < 2)
            {
                Destroy(hearts[1].gameObject);
            }
            isHurt = true;
            animator.SetBool("Hurt", true);
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("Hurt", false);
            isHurt = false;
            vidas--;
        }

    
}
}
