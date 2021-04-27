using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitboxHead : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);

        Destroy(gameObject.transform.parent.gameObject,0.5f);

        other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x,5);

    }
}
}
