using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{

public GameObject housePrefab;

public void spawnhouse()

    {
        GameObject house = Instantiate(housePrefab);
        house.transform.position = transform.position;
    }

  

}
