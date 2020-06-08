﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public character cha;
    public GameObject housePrefab;
    public Transform spawn1;
   public Transform spawn2;


    private void Start()
    {
        spawn1 = this.gameObject.transform.GetChild(0);
        spawn2 = this.gameObject.transform.GetChild(1);
    }
    public void spawnhouse()

    {
        
        if (cha.top)
        {
            GameObject house = Instantiate(housePrefab);
            house.transform.position = spawn2.position;
            house.GetComponent<SpriteRenderer>().flipY = true;
        } else
        {
            GameObject house = Instantiate(housePrefab);
            house.transform.position = spawn1.position; 
        }
       
    }

  
  




}
