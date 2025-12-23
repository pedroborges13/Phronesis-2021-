using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level=1;
    public float experience { get; private set; }

    public Text levelText;

    public Image expBar;

 public static int ExpNeedToLvlUp(int currentLevel)
    {
        if (currentLevel == 0)
            return 0;

        return (currentLevel * currentLevel + currentLevel) * 5;
    }

 public void SetExperience(float exp)
    {
        experience += exp;

        float expNeeded = ExpNeedToLvlUp(level);
        float previousExperience = ExpNeedToLvlUp(level - 1);

        if (experience >= expNeeded)
        {
            LevelUp();
            expNeeded = ExpNeedToLvlUp(level);
            previousExperience = ExpNeedToLvlUp(level - 1);
        }

        expBar.fillAmount = (experience - previousExperience) / (expNeeded - previousExperience);

        if (expBar.fillAmount == 1)
        {
            expBar.fillAmount = 0;
        }
    } 

    public void LevelUp()
    {
        level++;
        levelText.text = level.ToString("");
    }
}
