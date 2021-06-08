using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanGoblin : MonoBehaviour
{
    public float spawnTime;
    public float summonTime;
    public bool isPresent;
    public string[] summonName;
    public int summonType;
    public bool enemiespresent;
    Animator anim;
    public EnemyHealth health;
    public int myHealth;
    public Transform summonContainer;
    public EnemySpawner enemySpawner;

    [SerializeField] GameObject MoneyBagObject = null;
    // Start is called before the first frame update

    ObjectPooler myObjectPooler;
    string HealTag = "Heal";
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        MoneyBagObject.SetActive(false);
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        spawnTime = Random.Range(0.5f, 2f);
        anim = GetComponent<Animator>();
        summonTime = 1f;
        summonContainer = transform.Find("SummonContainer");
        if (transform.position.y > 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
        }
        if (transform.position.y < 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            //spawnTime = 30f;
            if (!isPresent && !enemiespresent)
            {
                health.health = myHealth;
                anim.SetTrigger("Spawn");
                MoneyBagObject.SetActive(true);
                isPresent = true;
            }

        }
        if (isPresent && !enemiespresent)
        {
            summonTime -= Time.deltaTime;
        }
        if (summonTime <= 0 && !enemiespresent)
        {
            anim.SetTrigger("Attack");

            summonType = Random.Range(0, summonName.Length);
            summonTime = Random.Range(2f, 4f);

        }
        if (summonContainer.childCount == 0)
        {
            enemiespresent = false;
        }
        if (health.health <= 0 && isPresent)
        {
            spawnTime = 8f;
            isPresent = false;
            if (health.CanSpawnHeal)
            {
                anim.SetTrigger("Die");
                Invoke("DisableMoneyBag", 1);
                if (GameStats.stats.monstersKilled < 400)
                {
                    GameStats.stats.monstersKilled++;
                }
            }
            else
            {
                anim.SetTrigger("Despawn");
                Invoke("DisableMoneyBag", 1);
            }
            
        }
        if (GameStats.stats.spawnHouse)
        {
            anim.SetTrigger("Despawn");
            Invoke("DisableMoneyBag", 1);
        }
    }

    void SpawnEnemies()
    {
        GameObject summon = Instantiate(Resources.Load("Prefabs/" + summonName[summonType]) as GameObject);
        summon.transform.position = transform.position + new Vector3(0, 0, 0);
        summon.transform.SetParent(summonContainer);
        enemiespresent = true;
        //health.TakeDamage(10);
    }
    void Over()
    {
        //enemySpawner.OneDown();
        //Destroy(gameObject);
        if (health.CanSpawnHeal == true)
        {
            //GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            //healthHeal.transform.position = transform.position;
            myObjectPooler.SpawnFromPool(HealTag, transform.position, Quaternion.identity);
        }
    }
    void LevelOver()
    {
        if (GameStats.stats.spawnHouse)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void DisableMoneyBag()
    {
        MoneyBagObject.SetActive(false);
    }
}
