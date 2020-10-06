﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmIceAttacks : MonoBehaviour
{
    BossWyrm wyrm;
    Animator anim;

   
    // Start is called before the first frame update
    void Start()
    {
        wyrm = FindObjectOfType<BossWyrm>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wyrm.iceTimer <= 0)
        {
            anim.SetTrigger("Shatter");
            

        }
    }
    public void Deactivate()
    {
        wyrm.iceTimer = Random.Range(20f, 30f);
        gameObject.SetActive(false);
    }

    public void ShatterSound()
    {
        FindObjectOfType<AudioManager>().Play("IceShatter");
    }
   
}
