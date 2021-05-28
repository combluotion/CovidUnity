using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update
    public string Escena;
    public Achievement.AchievementTypes achievementType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
    {
     if (other.gameObject.tag == "Player")
        {
            AchievementManager.Instance.UnlockAchievement(achievementType);
            SceneManager.LoadScene(Escena, LoadSceneMode.Single);
        }
    }
}
