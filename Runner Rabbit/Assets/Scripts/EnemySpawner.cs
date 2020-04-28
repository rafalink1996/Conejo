using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public bool enemy;
    public int enemyType = 1;
    public float enemyCount = 0;
    public string[] enemyName;
    bool enemies;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 6f);
        enemyType = Random.Range(0, enemyName.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= 0 && enemies)
        {
            spawnTime = Random.Range(3f, 6f);
            enemyType = Random.Range(0, enemyName.Length);
            enemy = false;
            enemies = false;
            
        }
        if (!enemy)
        {
            spawnTime -= Time.deltaTime;
        }
       

        if (spawnTime <= 0 && !enemy)
        {
            enemyCount = 1;
            GameObject foes = Instantiate(Resources.Load("Prefabs/" + enemyName[enemyType]) as GameObject);
            foes.transform.position = transform.position;
           


            /*if (enemyType == 1)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Firebook") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 2)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Slime") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 3)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 3") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 3;
            }
            if (enemyType == 4)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 4") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 4;
            }
            if (enemyType == 5)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 5") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 4;
            }
            if (enemyType == 6)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Book (ice)") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }
            if (enemyType == 7)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Book (Electric)") as GameObject);
                enemy.transform.position = transform.position;
                enemyCount = 1;
            }*/
            enemy = true;
            enemies = true;
        }
       
    }
    public void SetEnemyCount (int count)
    {
        enemyCount = count;
        print("enemy count");
    }

    public void OneDown()
    {
        enemyCount = enemyCount - 1;
    }
}
