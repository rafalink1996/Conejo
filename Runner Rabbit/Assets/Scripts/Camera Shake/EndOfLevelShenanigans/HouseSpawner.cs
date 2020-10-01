using System.Collections;
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
        cha = FindObjectOfType<character>();
        spawn1 = this.gameObject.transform.GetChild(0);
        spawn2 = this.gameObject.transform.GetChild(1);
    }
    public void spawnhouse()

    {
        GameStats.stats.spawnHouse = true;
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
