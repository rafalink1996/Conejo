using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkpower : MonoBehaviour


{
    private character Cha;
    Button button;


    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        button = GetComponent<Button>();
        button.onClick.AddListener(Cha.DarkPower);
        button.image.sprite = GameStats.stats.darkPowerSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            button.interactable = true;
            transform.SetSiblingIndex(1);

        }
        else
        {
            button.interactable = false;
            transform.SetSiblingIndex(0);
        }


    }
}
