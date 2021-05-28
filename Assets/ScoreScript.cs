using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float score;
    GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score");
    }

    public void UpdateScore( float points )
    {
        score = score + points;
        scoreText.GetComponent<Text>().text = score + " points";
        Debug.Log(score);
    }
}
