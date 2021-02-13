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
   


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 30;
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
        //enemySpawner = FindObjectOfType<EnemySpawner>();
        //healthSlider = GetComponentInChildren<Slider>();
        //health = maxHealth;
        //healthSlider.maxValue = maxHealth;
        spawnTime = Random.Range(0.1f, 2f);
        attackTime = Random.Range(0.2f, 1.3f);
        
    }

    // Update is called once per frame
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
            attackTime = Random.Range(0.6f, 1.8f);
            attack = false;
        }
        //healthSlider.value = health;
        if (health.health <= 0 || GameStats.stats.spawnHouse)
        {
            anim.SetTrigger("Die");
            if (GameStats.stats.monstersKilled < 400)
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
        health.TakeDamage(10);
    }
    void ElectricBall()
    {
        GameObject electricBall = GameObject.Instantiate(Resources.Load("Prefabs/Electric ball") as GameObject);
        //electricBall.GetComponent<ElectricBall>().sourceTransform = this.transform;
        //electricBall.transform.SetParent(transform, false);
        electricBall.transform.position = transform.position;
        
    }
    void Over()
    {
        if (SceneManager.GetActiveScene().name != "Level 2 (dungeon)")
        {
            enemySpawner.OneDown();
        }
        Destroy(gameObject);
        if (health.Hit == true)
        {
            GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            healthHeal.transform.position = transform.position;
        }
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("BookDeSpawn");

    }


}
