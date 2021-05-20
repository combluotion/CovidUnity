using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnTouch : MonoBehaviour
{
    private Vector3 velocity;
    private bool moving;

    void Start()
    {
        Debug.Log("start");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        // if (collision.WasWithPlayer())
        // {
            moving = true;
            collision.collider.transform.SetParent(transform);
            Debug.Log(collision.collider.transform);
        // }
    }

    // private void OnCollisionExit2D(Collider2D collision)
    // {
    //     // if (collision.WasWithPlayer())
    //     // {
    //         moving = false;
    //         collision.collider.transform.SetParent(null);
    //     // }
    // }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}
