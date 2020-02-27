using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public bool enemy;
    int enemyType = 1;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 6f);
        enemyType = Random.Range(1, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && !enemy)
        {
            if (enemyType == 1)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Firebook") as GameObject);
                enemy.transform.position = transform.position;
            }
            if (enemyType == 2) 
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Slime") as GameObject);
                enemy.transform.position = transform.position;
            }
            if (enemyType == 3)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 3") as GameObject);
                enemy.transform.position = transform.position;
            }
            if (enemyType == 4)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 4") as GameObject);
                enemy.transform.position = transform.position;
            }
            if (enemyType == 5)
            {
                GameObject enemy = GameObject.Instantiate(Resources.Load("Prefabs/Enemies 5") as GameObject);
                enemy.transform.position = transform.position;
            }
            enemy = true;
        }
    }

    public void RestartTime()
    {
        spawnTime = Random.Range(3f, 6f);
        enemy = false;
        enemyType = Random.Range(1, 6);
    }
}
