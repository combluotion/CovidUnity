using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño_Murcielago : MonoBehaviour
{
    public Collider2D collider2D;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public GameObject destroyParticle;

    public float jumpforce = 2.5f;

    public int lifes = 2;

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
        animator.Play("hit_murcielago");
    }
    public void CheckLife()
    {
        if (lifes == 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
