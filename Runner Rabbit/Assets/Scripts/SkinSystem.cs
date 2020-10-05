﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    public AnimatorOverrideController[] Skins;
    public character character;



    public int SkinIDTop;
    public int SkinIDBot;


    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<character>();
        SkinIDTop = GameStats.stats.topSkinID;
        SkinIDBot = GameStats.stats.botSkinID;
     if (character.top)
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[SkinIDTop] as RuntimeAnimatorController;
        } else
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[SkinIDBot] as RuntimeAnimatorController;
        }
            

    }

    // Update is called once per frame
    void Update()
    {

        if (!character.top)
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[SkinIDTop] as RuntimeAnimatorController;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = Skins[SkinIDBot] as RuntimeAnimatorController;
        }

    }
}
