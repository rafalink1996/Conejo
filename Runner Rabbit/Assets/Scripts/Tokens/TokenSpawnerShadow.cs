using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawnerShadow : MonoBehaviour
{
   [SerializeField] string TokenTag = "ShadowToken";
   [SerializeField] ObjectPooler myObjectPooler;
    bool SpawnTokens = true;

    private void Awake()
    {
       
    }
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        SpawnTokens = true;
        TokenTag = "ShadowToken";
        StartCoroutine(SpawnTime(true));
        StartCoroutine(SpawnTime(false));
    }
    private void Update()
    {
        if (GameStats.stats.bossDead)
        {
            SpawnTokens = false;
        }
    }

    void SpawnToken(Vector3 Position)
    {
        GameObject ShadowToken = myObjectPooler.SpawnFromPool(TokenTag, transform.position + Position, Quaternion.identity, false);
        //ShadowToken.transform.localPosition = Position;

    }

    IEnumerator SpawnTime(bool up)
    {
        while (SpawnTokens)
        {
            float timeBetweenSpawn;
            timeBetweenSpawn = Random.Range(10, 12);
            yield return new WaitForSeconds(timeBetweenSpawn);
            if (up)
            {
                Vector3 RandomPosition = new Vector3(0, Random.Range(2f, 8f));
                SpawnToken(RandomPosition);
            }
            else
            {
                Vector3 RandomPosition = new Vector3(0, Random.Range(-2f, -8f));
                SpawnToken(RandomPosition);
            }
           
        }
       
    }
}
