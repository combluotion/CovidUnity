using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI2 : MonoBehaviour
{
    // Start is called before the first frame update
     public SpriteRenderer spriteRenderer;
     public bool move;
     public float speed = 0.5f;
     public Animator animator;

     public float xPosition = 12.076f;

     int i = 1;

     public float period = 0.0f;
    public float jumpforce = 2.5f;
    public GameObject destroyParticle;
    public int lifes = 10;
    public float points;
    public GameObject player;
     void Start()
    {

    }


     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("VACUNA"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpforce);
            LoseLifeAndHit();
            CheckLife();
        }
    }
     public void LoseLifeAndHit()
    {
        lifes--;
        animator.SetTrigger("Hurt");
    }
    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            animator.SetTrigger("Death");
            //spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.5f);
        }
    }
    public void EnemyDie()
    {
        player.GetComponent<ScoreScript>().UpdateScore(points);
        Destroy(gameObject);
        AchievementManager.Instance.UnlockAchievement(Achievement.AchievementTypes.killBoss);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveToPosition = new Vector2(xPosition,transform.position.y);
        if(move){
            animator.SetBool("Run",true);
            transform.position = Vector2.MoveTowards(transform.position, moveToPosition, speed * Time.deltaTime);
        }

        if(transform.position.x >= moveToPosition.x - 0.1f)
        {
            move = false;
            animator.SetBool("Run",false);
            if (period > 2f)
            {
            HitAttack();
            period = 0;
            }

            period += UnityEngine.Time.deltaTime;
        }


    }

    void HitAttack()
    {

        animator.SetTrigger("Attack"+i);
        if(i == 2) i = 1;
        else i = 2;

    }
}
