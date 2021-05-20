using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float waitTime;
    private float startWaitTime = 2;

    public Animator animator;

    public float speed = 0.5f;

    public Transform[] transformArray;

    private int i =0;

    private Vector2 actualPos;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(CheckEnemyMoving());
        transform.position = Vector2.MoveTowards(transform.position,transformArray[i].transform.position,speed * Time.deltaTime );
        
        if(Vector2.Distance(transform.position, transformArray[i].transform.position) < 0.3f){
            Debug.Log("distancia encontrada");
            animator.SetBool("Run",false);
            if(waitTime <= 0)
            {
            if(transformArray[i] != transformArray[transformArray.Length-1]){
                i++;
            }
            else{
                i = 0;
            }
                waitTime = startWaitTime;
            }
            else{
                waitTime -= Time.deltaTime;
            }

            
        }
        else{
            if(animator.GetBool("Run") == false){
            animator.SetBool("Run",true);
            }
        }
    }

    IEnumerator CheckEnemyMoving(){
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);

        if(transform.position.x > actualPos.x){
            spriteRenderer.flipX = false;
        }
        else if(transform.position.x < actualPos.x){
            spriteRenderer.flipX = true;
        }
    }
}
