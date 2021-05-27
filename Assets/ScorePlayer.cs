using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    private float score;
    public GameObject player;
    public float var;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void UpdateScore( float points )
    {
        score = score + points;
        Debug.Log("Score : ");
        Debug.Log(score);
    }
}
