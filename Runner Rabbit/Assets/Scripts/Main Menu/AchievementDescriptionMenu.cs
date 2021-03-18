using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementDescriptionMenu : MonoBehaviour
{
    public Sprite[] AchivmentImages;
    public string[] AchivementNames;
    public string[] Español_AchivementNames;

    public string[] AchivementDescriptions;
    public string[] Español_AchivementDescriptions;

    public Image AchievementImage;
    public TextMeshProUGUI AchievmentName;
    public TextMeshProUGUI AchievmentDescription;

    public void SeeAchievmentInfo(int AchievmentID)
    {
        
        AchievementImage.sprite = AchivmentImages[AchievmentID - 1];
        if (GameStats.stats.LanguageSelect == 0)
        {
            AchievmentName.text = AchivementNames[AchievmentID - 1];
            AchievmentDescription.text = AchivementDescriptions[AchievmentID - 1];
        } else if (GameStats.stats.LanguageSelect == 1)
        {
            AchievmentName.text = Español_AchivementNames[AchievmentID - 1];
            AchievmentDescription.text = Español_AchivementDescriptions[AchievmentID - 1];
        }
        



    }
  
}
