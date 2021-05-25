using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

public static AchievementManager Instance;
[SerializeField] private Achievement[] achievements;

private void Awake() {

Instance = this;    

}

public void UnlockAchievement(Achievement.AchievementTypes achievementType)
{
Achievement achievementToUnlock = Array.Find(achievements, dummyAchi => dummyAchi._achievementType == achievementType);

if(achievementToUnlock == null){
    Debug.Log("No achievement added: " + achievementType);
    return;
}

if(!achievementToUnlock.isUnlocked)
{
    achievementToUnlock.UnlockThisAchievement();
}
}

}
