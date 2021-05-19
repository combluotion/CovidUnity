using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_BASICA : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    private float waitTime;

    public Transform[] moveSpots;

    public float startwaitTime = 2;

    private int i = 0;

    private Vector2 actualPos;


    void Start()
    {
        waitTime = startwaitTime;
    }

    void Update()
    {
        


    }
}
