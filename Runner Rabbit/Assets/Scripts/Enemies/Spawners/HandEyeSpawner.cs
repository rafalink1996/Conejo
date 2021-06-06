using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEyeSpawner : MonoBehaviour
{

    [SerializeField] float SpawnTime = 0;
    [SerializeField] string HandEnemyTag;
    [SerializeField] string EyeEnemyTag;

    ObjectPooler myObjectPooler;
    

    void Start()
    {
        HandEnemyTag = "MageHand";
        EyeEnemyTag = "MageEye";
        myObjectPooler = ObjectPooler.Instance;

        StartCoroutine(SpawnTimer(4));

    }

    private void Update()
    {
        if (GameStats.stats.spawnHouse)
        {
            StopAllCoroutines();
        }
    }


    IEnumerator SpawnTimer(float Time)
    {
        yield return new WaitForSeconds(Time);
        SpawnMagePart();
    }

    void SpawnMagePart()
    {
        int chance = Random.Range(0, 100);
        if(chance < 75)
        {
            GameObject Enemy = myObjectPooler.SpawnFromPool(HandEnemyTag, transform.position, Quaternion.identity, false);
            Enemy.transform.rotation = transform.rotation;
            Enemy.transform.position = transform.position;
        }
        else{
            GameObject Enemy = myObjectPooler.SpawnFromPool(EyeEnemyTag, transform.position, Quaternion.identity, false);
            Enemy.transform.rotation = transform.rotation;
            Enemy.transform.position = transform.position;
        }
    }

    public void StartEnemyTimer()
    {
        SpawnTime = Random.Range(3f, 6f);
        StartCoroutine(SpawnTimer(SpawnTime));

    }
}
