using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightpower : MonoBehaviour
{
    private character Cha;
    Button button;
    HoldButton holdbutton;



    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        button = GetComponent<Button>();
        holdbutton = GetComponent<HoldButton>();
        button.onClick.AddListener(Cha.LightPower);
        button.image.sprite = GameStats.stats.lightPowerSprite;


        if (GameStats.stats.lightpowerID < 51)
        {
            button.onClick.AddListener(Cha.LightPower);
        }

        if (GameStats.stats.lightpowerID == 51 || GameStats.stats.lightpowerID == 52 || GameStats.stats.lightpowerID == 53 || GameStats.stats.lightpowerID == 54)
        {
            holdbutton.OnHoldDown.AddListener(Cha.LightPowerHold);
            holdbutton.OnHoldUp.AddListener(Cha.LightPowerHoldStop);
            print("holdButtonWithLaserLight");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            button.interactable = false;
            transform.SetSiblingIndex(0);
        }
        else
        {
            button.interactable = true;
            transform.SetSiblingIndex(1);
        }


    }
}
