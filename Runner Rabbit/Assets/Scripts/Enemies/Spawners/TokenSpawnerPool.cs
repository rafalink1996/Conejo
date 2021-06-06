using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawnerPool : MonoBehaviour
{

    float TimeToSpawn;


    bool spawnCoins;
    ObjectPooler myObjectpooler;
    string CoinGroupTag = "coinGroupTag";


    private void Start()
    {
        myObjectpooler = ObjectPooler.Instance;
        spawnCoins = true;
        StartCoroutine(SpawnCoins(true));
        StartCoroutine(SpawnCoins(false));
    }

    IEnumerator SpawnCoins(bool up)
    {
        while (spawnCoins)
        {
            float TimeToSpawn = Random.Range(5,7);
            yield return new WaitForSeconds(TimeToSpawn);

            GameObject coinGroup = myObjectpooler.SpawnFromPool(CoinGroupTag, transform.position, Quaternion.identity);
            float randomYPos;
            if (up)
            {
                randomYPos = Random.Range(2f, 8f);
            }
            else
            {
                randomYPos = Random.Range(-2f, -8f);
            }
            coinGroup.transform.position += new Vector3(0, randomYPos);

            if (GameStats.stats.bossDead || GameStats.stats.spawnHouse)
            {
                spawnCoins = false;
            }
        }
    }
}
