using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightpower : MonoBehaviour
{
    public character Cha;
    public Button button;
    public HoldButton holdbutton;



    // Start is called before the first frame update
    void Start()
    {
        //Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        //button = GetComponent<Button>();
        //holdbutton = GetComponent<HoldButton>();
        //button.onClick.AddListener(Cha.LightPower);
        button.image.sprite = GameStats.stats.powerLight.iconLight;

        /*
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

        */

        if (GameStats.stats.powerLight.id < 51)
        {
            button.enabled = true;
            holdbutton.enabled = false;
        }
        else if (GameStats.stats.powerLight.id == 51 || GameStats.stats.powerLight.id == 52 || GameStats.stats.powerLight.id == 53 || GameStats.stats.powerLight.id == 54)
        {
            button.enabled = false;
            holdbutton.enabled = true;
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
