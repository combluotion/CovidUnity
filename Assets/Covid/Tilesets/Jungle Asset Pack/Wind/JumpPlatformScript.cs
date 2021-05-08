using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatformScript : MonoBehaviour
{
public int jumpForce;
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
    Rigidbody2D rb2 = other.GetComponent<Rigidbody2D>();
    rb2.AddForce(new Vector2(rb2.velocity.x,jumpForce),ForceMode2D.Impulse);
    }
}
}
