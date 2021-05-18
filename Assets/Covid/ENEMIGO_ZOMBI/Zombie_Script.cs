using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Script : MonoBehaviour
{
    public GameObject MainCharacter;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = MainCharacter.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        float distance = Mathf.Abs(MainCharacter.transform.position.x - transform.position.x);
        if (distance < 1.0f)
        {
            Ataca();
            
        }
    }
    private void Ataca()
    {
        Debug.Log("Ataca");
        animator.SetBool("Cerca", true);
    }
}
