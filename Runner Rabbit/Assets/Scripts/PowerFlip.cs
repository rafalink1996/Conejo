﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerFlip : MonoBehaviour
{
    // Start is called before the first frame update

    private character Cha;
    public Animator animator;
    Button button;


    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        button = GetComponent<Button>();
        //button.onClick.AddListener(Cha.Missile);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            animator.SetBool("Character Down", true);
        }
        if (Cha.top == false)
        {

            animator.SetBool("Character Up", true);
        }
    }


    public void SpawnDarkPower()
    {
        GameObject DarkPower = GameObject.Instantiate(Resources.Load("Prefabs/Power Dark") as GameObject);
        DarkPower.transform.SetParent(GameObject.FindGameObjectWithTag("UIpower").transform, false);
        DarkPower.GetComponent<Button>().onClick.AddListener(Cha.Defence);
    }
    public void CharacterFlip()
    {
        
        Destroy(gameObject);
    }

    public void SpawnLightPower()
    {
        GameObject Lightpower = GameObject.Instantiate(Resources.Load("Prefabs/Power Light") as GameObject);
        Lightpower.transform.SetParent(GameObject.FindGameObjectWithTag("UIpower").transform, false);
        Lightpower.GetComponent<Button>().onClick.AddListener(Cha.Missile);
    }
   
    

 

}
