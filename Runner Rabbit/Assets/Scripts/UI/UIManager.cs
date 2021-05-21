using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ManaTearLight, ManaTearDark;
    [SerializeField] TextMeshProUGUI CrystalText, CoinsText;

    [SerializeField] Color ColorLightUp, ColorLightDown;
    [SerializeField] Color ColorDarkUp, ColorDarkDown;

    Image ManaTearLightImage;
    Image ManaTearDarkImage;

    [SerializeField] CanvasGroup hudCanvasGroup;

    public character Cha;



    void Start()
    {
        ManaTearDarkImage = ManaTearDark.GetComponent<Image>();
        ManaTearLightImage = ManaTearLight.GetComponent<Image>();
        hudCanvasGroup.alpha = 0;

        Cha = FindObjectOfType<character>();
        ChangeManaInUse();
    }
    public void ChangeManaInUse()
    {
        if (!Cha.top)
        {
            ManaDisplayDark();
        }
        else
        {
            ManaDisplayLight();

        }

        ShowHud();
    }

    void ManaDisplayDark()
    {
        LeanTween.cancel(ManaTearDark);
        LeanTween.cancel(ManaTearLight);
        LeanTween.scale(ManaTearDark, new Vector3(1.3f, 1.3f, 1.3f), 1).setEase(LeanTweenType.easeOutExpo);
        LeanTween.scale(ManaTearLight, new Vector3(1f, 1f, 1f), 1).setEase(LeanTweenType.easeOutExpo);

        ManaTearDarkImage.color = ColorDarkUp;
        ManaTearLightImage.color = ColorLightDown;
        
        
    }
    void ManaDisplayLight()
    {
        LeanTween.cancel(ManaTearDark);
        LeanTween.cancel(ManaTearLight);
        LeanTween.scale(ManaTearLight, new Vector3(1.3f, 1.3f, 1.3f), 1).setEase(LeanTweenType.easeOutExpo);
        LeanTween.scale(ManaTearDark, new Vector3(1f, 1f, 1f), 1).setEase(LeanTweenType.easeOutExpo);

        ManaTearDarkImage.color = ColorDarkDown;
        ManaTearLightImage.color = ColorLightUp;
    }


    void ShowHud()
    {
        LeanTween.alphaCanvas(hudCanvasGroup, 1, 1).setDelay(0.4f);
    }

}
