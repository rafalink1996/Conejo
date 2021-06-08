using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnovorousPlantSpawner : MonoBehaviour
{
    public GameObject SimpleEnemy;

    public float respawnTime = 1.0f;
    public float respawnTimeRandom = 4.0f;
    public float SpawnTimer = 4f;

    public bool DarkSide = false;
    [SerializeField] Transform sourceTransform;

    ObjectPooler myObjectPooler;
    string sharpLeafTag = "SharpLeaf";

    private IEnumerator Spawner;


    private void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        sharpLeafTag = "SharpLeaf";
    }
    public void StartSpawning()
    {
        /*
             if (Spawner != null)
                 StopCoroutine(Spawner);

             Spawner = SimpleEnemyWave();
             StartCoroutine(Spawner);
        */

        StartCoroutine(SimpleEnemyWave());



    }




    // Update is called once per frame
    IEnumerator SimpleEnemyWave()
    {
        float StartTime = Time.time;
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            spawnEnemyRandom();

            if (Time.time - StartTime > SpawnTimer)
            {
                break;
            }

        }
    }




    private void spawnEnemyRandom()
    {

        //GameObject SE = Instantiate(SimpleEnemy) as GameObject;
        //SE.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-8, 8));
        GameObject SE = myObjectPooler.SpawnFromPool(sharpLeafTag, new Vector2(transform.position.x, transform.position.y + Random.Range(-8, 8)), Quaternion.identity);
        SharpLeafProyectile SES = SE.GetComponent<SharpLeafProyectile>();
        if (SES != null)
        {
            SES.sourceTransform = sourceTransform;
        }

    }


}

