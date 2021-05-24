using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyHit : MonoBehaviour
{
    public GameObject Enemy;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
        Debug.Log(Enemy.GetComponent<IaMushroom>().actualLive);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("VACUNA")){
            // playerrb2.AddForce(new Vector2(value, 2),ForceMode2D.Impulse);
            Enemy.GetComponent<IaMushroom>().actualLive = Enemy.GetComponent<IaMushroom>().actualLive - 1;
            Debug.Log(Enemy.GetComponent<IaMushroom>().actualLive);


            // if (Enemy.GetComponent<IaMushroom>().actualLive == 0) {
            //     gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //     GetComponent<BoxCollider2D>().enabled = false;

            //     gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
            //     Destroy(gameObject.transform.parent.GetChild(2).gameObject);

            //     Destroy(gameObject.transform.parent.gameObject,0.5f);
            // }
        }
   }
}
