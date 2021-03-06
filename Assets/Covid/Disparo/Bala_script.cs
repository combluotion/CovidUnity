using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_script : MonoBehaviour
{
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direction;
    private float Horizontal;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
       GetComponent<AudioSource>().PlayOneShot(Sound);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;


    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
        if(direction.x == -1)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else{
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
