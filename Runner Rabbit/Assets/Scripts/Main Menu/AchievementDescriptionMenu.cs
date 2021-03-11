using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementDescriptionMenu : MonoBehaviour
{
    public Sprite[] AchivmentImages;
    public string[] AchivementNames;
    public string[] AchivementDescriptions;

    public Image AchievementImage;
    public TextMeshProUGUI AchievmentName;
    public TextMeshProUGUI AchievmentDescription;

    public void SeeAchievmentInfo(int AchievmentID)
    {
        
        AchievementImage.sprite = AchivmentImages[AchievmentID - 1];
        AchievmentName.text = AchivementNames[AchievmentID - 1];
        AchievmentDescription.text = AchivementDescriptions[AchievmentID - 1];



    }
  
}
