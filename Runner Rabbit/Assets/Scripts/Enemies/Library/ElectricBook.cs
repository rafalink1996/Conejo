using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElectricBook : MonoBehaviour
{
    Animator anim;
    //public int maxHealth = 8;
    //public int health;
    public EnemySpawner enemySpawner;
    //public Slider healthSlider;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;
    public int BookHealth = 6;
    public int BookSelfDamage = 2;

    ObjectPooler myObjectPooler;
    string electricBallTag = "ElectricBallBook";
    string HealTokenTag = "Heal";



    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        electricBallTag = "ElectricBallBook";
        if (GameStats.stats.LevelIndicator > 1)
        {
            BookHealth = 18;
            BookSelfDamage = 6;
        }
        health = GetComponent<EnemyHealth>();
        health.maxHealth = BookHealth;
        anim = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name != "Level 2 (dungeon)")
        {
            if (transform.position.y > 0)
            {
                enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
            }
            if (transform.position.y < 0)
            {
                enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
            }
        }
       
        spawnTime = Random.Range(0.1f, 2f);
        attackTime = Random.Range(0.2f, 1.3f);
        
    }

    
    void Update()
    {
        //print(SceneManager.GetActiveScene().name);
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && spawned == false)
        {
            anim.SetTrigger("Spawn");
            GetComponent<SpriteRenderer>().enabled = true;
            FindObjectOfType<AudioManager>().Play("BookSpawn");
            spawned = true;


        }
        if (attack)
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0)
        {
            anim.SetTrigger("Attack");
            attackTime = Random.Range(1f, 2.5f);
            attack = false;
        }
        //healthSlider.value = health;
        if (health.health <= 0 || GameStats.stats.spawnHouse)
        {
            anim.SetTrigger("Die");
            if (GameStats.stats.monstersKilled < 400 && health.Hit)
            {
                GameStats.stats.monstersKilled++;
            }

        }
    }
    void AttackTime()
    {
        if (!attack)
        {
            attack = true;
        }
    }
    void Attack()
    {
        health.TakeDamage(BookSelfDamage);
    }
    void ElectricBall()
    {
        //GameObject electricBall = GameObject.Instantiate(Resources.Load("Prefabs/Electric ball") as GameObject);
        //electricBall.transform.position = transform.position;

        GameObject electricBall = myObjectPooler.SpawnFromPool(electricBallTag, transform.position, Quaternion.identity, true);
        ElectricBall myElectriBall = electricBall.GetComponentInChildren<ElectricBall>();
        myElectriBall.sourceTransform = gameObject.transform;
        
    }
    void Over()
    {
        if (SceneManager.GetActiveScene().name != "Level 2 (dungeon)")
        {
            enemySpawner.OneDown();
        }
        Destroy(gameObject);
        if (health.CanSpawnHeal == true)
        {
            //GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            //healthHeal.transform.position = transform.position;
            myObjectPooler.SpawnFromPool(HealTokenTag, transform.position, Quaternion.identity);
        }
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("BookDeSpawn");

    }


}
