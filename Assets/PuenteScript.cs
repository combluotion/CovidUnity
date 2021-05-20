using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float pushPower = 2.0F;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){

            // gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            // gameObject.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // GetComponent<BoxCollider2D>().enabled = false;

            // gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);

            // gameObject.parent.Live = gameObject.parent.Live - 1;
            // Destroy(gameObject.transform.parent.gameObject,0.5f);

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x,50);
        }
    }

}
