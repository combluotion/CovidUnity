using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
public PlayerMovement pm;
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player"))
    {
       if(pm.isHurt == false){ 
        pm.StartCoroutine("HurtCharacter");
       Rigidbody2D playerrb2 = other.gameObject.GetComponent<Rigidbody2D>();
       bool isNotFacingRight = other.GetComponent<SpriteRenderer>().flipX;
       int value = -2;
       if(isNotFacingRight)
       {
           value = 2;
       };
       playerrb2.AddForce(new Vector2(value, 2),ForceMode2D.Impulse);
       
       }
       
    }
}
}
