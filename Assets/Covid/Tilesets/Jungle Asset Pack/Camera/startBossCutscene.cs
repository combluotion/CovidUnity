using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBossCutscene : MonoBehaviour
{
    public Animator canAnim;
    public GameObject bossChat;

    public BossAI2 boss;
private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        canAnim.SetBool("bossCutscene",true);
       Invoke(nameof(showChat),0.1f);
        Invoke(nameof(StopCutscene),3f);
    }
}

void StopCutscene(){
    bossChat.SetActive(false);
    boss.move = true;
    canAnim.SetBool("bossCutscene",false);
    Destroy(gameObject);
    
}

void showChat(){
 bossChat.SetActive(true);
}
}
