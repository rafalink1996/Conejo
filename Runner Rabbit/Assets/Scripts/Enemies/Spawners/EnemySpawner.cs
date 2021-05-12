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
    character Cha;
    public Transform enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(3f, 6f);
        enemyType = Random.Range(0, enemyName.Length);
        Cha = FindObjectOfType<character>();
        GameStats.stats.bossDead = false;
    }

    
    void Update()
    {
        if (enemyContainer.childCount == 0 && enemies)
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
            foes.transform.SetParent(enemyContainer);
            
           
            enemy = true;
            enemies = true;
        }
    }
    public void SetEnemyCount (int count)
    {
        enemyCount = count;
        //print("enemy count");
    }

    public void OneDown()
    {
        enemyCount = enemyCount - 1;
    }
}
