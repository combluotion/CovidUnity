using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaMushroom : MonoBehaviour
{
    public float live;
    public float maxScale;
    public float actualLive;
    public float points;
    private float scale = 1;
    Transform transform;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        actualLive = live;
        transform = GetComponent<Transform>();
        // player = GameObject.Find("SimonPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (actualLive < live) {
            if (scale < maxScale) {
                scale = scale + 0.001f;
            }
            transform.localScale = new Vector2(scale, scale);
        }

        if (actualLive <= 0) {
            Debug.Log("destruido");
            Die();
        }
    }

    public void Die()
    {
        player.GetComponent<ScoreScript>().UpdateScore(points);
        Destroy(gameObject);
    }

    public void MoveBack()
    {
        transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
    }

    void MoveToPlayer()
    {
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
