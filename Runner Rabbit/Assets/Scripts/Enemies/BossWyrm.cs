﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWyrm : MonoBehaviour
{
    public int element = 1;
    public int currentElement = 1;
    public GameObject[] portals;
    public GameObject[] attacks;
    public bool ice;
    public float iceTimer;
    Animator anim;
    public float timeToChange;
    public bool isChanging;
    character Cha;
    public bool bossTop;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timeToChange = Random.Range(15f, 25f);
        iceTimer = Random.Range(20f, 30f);
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChanging)
        {
            timeToChange -= Time.deltaTime;

        }
        if (element == 1)
        {
            portals[0].SetActive(true);
            portals[1].SetActive(false);
            portals[2].SetActive(false);
        }
        if (element == 2 && !ice)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(true);
            portals[2].SetActive(false);
            //ice = true;
        }
        if (element == 3)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(false);
            portals[2].SetActive(true);
        }
        if (ice)
        {
            iceTimer -= Time.deltaTime;
        }
        if (iceTimer <= 0)
        {
            ice = false;
            anim.SetBool("Ice", false);
            //iceTimer = 30f;
        }
        /*if (Input.GetKeyDown(KeyCode.U)) //for testing
        {
            anim.SetTrigger("Despawn"); //this will trigger the portal change
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (element == 1)
            {
                anim.SetTrigger("Shoot");
            }
            if (element == 2)
            {
                anim.SetTrigger("Shoot");
            }
            if(element == 3)
            {
                anim.SetTrigger("Shoot");
            }
        }*/
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
        /*if (Cha.top)
        {
            transform.parent.transform.localEulerAngles = new Vector3(180, 0, 0);
            
        }
        else
        {
            transform.parent.transform.localEulerAngles = new Vector3(0, 0, 0);
            
        }*/
    }
    public void ChangeElement()
    {
        if (element == 2 && anim.GetBool("Ice") == true)
        {
            element = 2;
        }
        else

            while (element == currentElement || element == 2 && ice)
            {
                element = Random.Range(1, 4);
            }

        currentElement = element;
    }
    public void NewPortal()
    {
        portals[currentElement - 1].GetComponent<Animator>().SetTrigger("Change");
    }
    public void Shoot()
    {
        if (element == 1)
        {
            GameObject fireBall = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
            fireBall.transform.position = transform.position + new Vector3(-5.755793f, -0.2495456f, 0);
        }
        if (element == 3)
        {
            GameObject thunderBall = Instantiate(Resources.Load("Prefabs/WyrmThunderBall") as GameObject);
            thunderBall.transform.position = transform.position + new Vector3(-5.755793f, -0.2495456f, 0);
        }
    }
    public void RiftAttack()
    {
        if (element == 2)
        {
            attacks[0].SetActive(true);
        }
        if (element == 3)
        {
            attacks[3].SetActive(true);
        }
    }
    public void Ray()
    {
        if (element == 1)
        {
            attacks[1].SetActive(true);
        }
        if (element == 2)
        {
            attacks[2].SetActive(true);
        }
    }

}
