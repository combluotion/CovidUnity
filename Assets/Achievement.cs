using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{

public enum AchievementTypes {killBoss, nivelUno, nivelDos};
[SerializeField] private AchievementTypes achievementType;
 public AchievementTypes _achievementType{get {return achievementType;}}
private Text text;
public bool isUnlocked {get; private set;}

private void Awake(){
text = GetComponent<Text>();
CheckIfAchievementIsUnlocked();
}

public void CheckIfAchievementIsUnlocked(){

    if(PlayerPrefs.GetInt(achievementType.ToString()) == 0)
    {
        text.color = Color.red;
    }
    else{
        text.color = Color.green;
        isUnlocked = true;
    }

}

public void UnlockThisAchievement()
{
    PlayerPrefs.SetInt(achievementType.ToString(),1);
    Awake();
}


}
