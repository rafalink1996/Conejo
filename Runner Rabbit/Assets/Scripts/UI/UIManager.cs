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

    //Silenced UI
    [SerializeField] CanvasGroup SilenecedCanvas = null;
    [SerializeField] GameObject Chain1 = null;
    [SerializeField] GameObject Chain2 = null;
    bool silenceActive;


    //PoisonUI
    [SerializeField] GameObject PosionDropUI;
    bool PoisonActive;
    

    public character Cha;

    private void Update()
    {
        if (Cha.silenced && !silenceActive)
        {
            ToggleSilencedUI(true);
            silenceActive = true;
        }
        if(!Cha.silenced && silenceActive)
        {
            ToggleSilencedUI(false);
            silenceActive = false;
        }
        if(Cha.isPoisoned && !PoisonActive)
        {
            TogglePoisonUI(true);
            PoisonActive = true;
        }
        if(!Cha.isPoisoned && PoisonActive)
        {
            TogglePoisonUI(false);
            PoisonActive = false;
        }
    }

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


    void ToggleSilencedUI(bool Sileneced)
    {
        if (Sileneced)
        {
            LeanTween.cancel(SilenecedCanvas.gameObject);
            LeanTween.alphaCanvas(SilenecedCanvas, 1, 0.5f).setEase(LeanTweenType.easeInExpo);
            LeanTween.cancel(Chain1);
            LeanTween.moveLocal(Chain1, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.5f);
            LeanTween.cancel(Chain2);
            LeanTween.moveLocal(Chain2, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.5f);
        }
        else
        {
            
            LeanTween.cancel(Chain1);
            LeanTween.moveLocal(Chain1, new Vector3(-135, 142, 0), 0.5f).setEase(LeanTweenType.easeInExpo);
            LeanTween.cancel(Chain2);
            LeanTween.moveLocal(Chain2, new Vector3(164, 125, 0), 0.5f).setEase(LeanTweenType.easeInExpo);
            LeanTween.cancel(SilenecedCanvas.gameObject);
            LeanTween.alphaCanvas(SilenecedCanvas, 0, 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.5f);
        }
    }

    void TogglePoisonUI(bool Poisoned)
    {
        if (Poisoned)
        {
            LeanTween.cancel(PosionDropUI);
            LeanTween.scale(PosionDropUI, new Vector3(1, 1, 1), 0.3f).setEase(LeanTweenType.easeInExpo);
        }
        else
        {
            LeanTween.cancel(PosionDropUI);
            LeanTween.scale(PosionDropUI, new Vector3(0, 0, 0), 0.3f).setEase(LeanTweenType.easeInExpo);
        }
    }

}
