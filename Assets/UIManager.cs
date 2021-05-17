using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            PauseGame();
        }
    }

    public void retryLevel()
    {
    Time.timeScale = 1;
    Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

}

