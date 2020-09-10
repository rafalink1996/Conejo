using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject spawnerUp;
    public GameObject SpawnerDown;
    public GameObject SpawnerMiddle;
    public GameObject Boss;
    public GameObject ProgressBar;

   

    

   

    // Update is called once per frame
    void Update()
    {
        if ( GameStats.stats.LevelCount == 3)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            SpawnerMiddle.SetActive(false);
            ProgressBar.SetActive(false);


            Boss.SetActive(true);



        }
    }

   
}
