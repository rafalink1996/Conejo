using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public GameObject SimpleEnemy;
    public GameObject SimpleEnemyStatic;
    public float respawnTime = 1.0f;
    public float respawnTimeRandom = 4.0f;



    [SerializeField] string EnemyRandomTag;
    [SerializeField] string EnemyStaticTag;
    ObjectPooler myObjectPooler;


    [SerializeField] bool spawnSimpleEnemies;
    [SerializeField] bool spawnRandomEnemies;



    public bool DarkSide = false;
    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        if (GameStats.stats.LevelIndicator == 5)
        {
            EnemyRandomTag = "ClockworkBombs";
            EnemyStaticTag = null;
        }else if(GameStats.stats.LevelIndicator == 4)
        {
            EnemyRandomTag = "GyratoryPlant";
            EnemyStaticTag = "BitePlant";
        }


        if (GameStats.stats.LevelCount == 3)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (spawnRandomEnemies)
            {
                StartCoroutine(SimpleEnemyWave());
            }

            if (spawnSimpleEnemies)
            {
                StartCoroutine(SimpleEnemyWaveStatic());
            }
        }
       


    }






    IEnumerator SimpleEnemyWaveStatic()
    {

        yield return new WaitForSeconds(Random.Range(4, 6));
        spawnEnemy();
        yield return new WaitForSeconds(1.3f);
        spawnEnemy();
        yield return new WaitForSeconds(1.3f);
        spawnEnemy();
        StartCoroutine(SimpleEnemyWaveStatic());


    }



    private void spawnEnemy()
    {

        //GameObject SE = Instantiate(SimpleEnemyStatic);
        //SE.transform.position = new Vector2(transform.position.x, transform.position.y);
        //if (DarkSide == true)
        //{
        //    SE.transform.eulerAngles += new Vector3(0, 0, 180);
        //}

        GameObject SE = myObjectPooler.SpawnFromPool(EnemyStaticTag, transform.position, Quaternion.identity);
        SE.transform.position = new Vector2(transform.position.x, transform.position.y);
        if (DarkSide == true)
        {
           SE.transform.eulerAngles += new Vector3(0, 0, 180);
        }

    }



    IEnumerator SimpleEnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            spawnEnemyRandom();

        }
    }


    private void spawnEnemyRandom()
    {

        //GameObject SE = Instantiate(SimpleEnemy) as GameObject;
        //SE.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-8, 8));

        GameObject SE = myObjectPooler.SpawnFromPool(EnemyRandomTag, transform.position, Quaternion.identity);
        SE.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-8, 8));
        


    }

}
