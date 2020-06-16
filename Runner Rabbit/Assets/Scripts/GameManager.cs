using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject spawnerUp;
    public GameObject SpawnerDown;
    public GameObject Boss;

   

    

   

    // Update is called once per frame
    void Update()
    {
        if ( GameStats.stats.LevelCount == 3)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            Boss.SetActive(true);


        }
    }
}
