using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player"))
    {
       Rigidbody2D playerrb2 = other.gameObject.GetComponent<Rigidbody2D>();
       bool isNotFacingRight = other.GetComponent<SpriteRenderer>().flipX;
       int value = -5;
       if(isNotFacingRight)
       {
           value = 5;
       };
       playerrb2.AddForce(new Vector2(value,playerrb2.velocity.y + 5),ForceMode2D.Impulse);
    }
}
}
