using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public GameObject SimpleEnemy;
    public GameObject SimpleEnemyStatic;
    public float respawnTime = 1.0f;
    public float respawnTimeRandom = 4.0f;

    public bool DarkSide = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SimpleEnemy != null)
        {
            StartCoroutine(SimpleEnemyWave());
        }

        if (SimpleEnemyStatic != null)
        {
            StartCoroutine(SimpleEnemyWaveStatic());
        }


    }

    // Update is called once per frame
    IEnumerator SimpleEnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
     
                spawnEnemyRandom();

        }
    }

    IEnumerator SimpleEnemyWaveStatic()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range (respawnTime, respawnTimeRandom));
     
                spawnEnemy();
     
        }
    }

     
    private void spawnEnemyRandom()
    {
       
            GameObject SE = Instantiate(SimpleEnemy) as GameObject;
            SE.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-8, 8));
        
    }

    private void spawnEnemy()
    {
       
            GameObject SE = Instantiate(SimpleEnemyStatic) as GameObject;
            SE.transform.position = new Vector2(transform.position.x, transform.position.y);
        if (DarkSide == true) 
        {
            SE.transform.eulerAngles += new Vector3(0, 0, 180);
        }
        
    }
}
