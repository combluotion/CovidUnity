using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitLive : MonoBehaviour
{
    public GameObject Enemy;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x,10);
            Enemy.GetComponent<IaMushroom>().actualLive = Enemy.GetComponent<IaMushroom>().actualLive - 1;
            Debug.Log(Enemy.GetComponent<IaMushroom>().actualLive);

            // if (Enemy.GetComponent<IaMushroom>().actualLive == 0) {
            //     Enemy.GetComponent<SpriteRenderer>().enabled = false;
            //     Enemy.GetComponent<BoxCollider2D>().enabled = false;
            //     GetComponent<BoxCollider2D>().enabled = false;

            //     gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
            //     Destroy(gameObject.transform.parent.GetChild(2).gameObject);

            //     Destroy(gameObject.transform.parent.gameObject,0.5f);
            // }
        }
    }
}

