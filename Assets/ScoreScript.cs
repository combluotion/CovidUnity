using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private float score;

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
