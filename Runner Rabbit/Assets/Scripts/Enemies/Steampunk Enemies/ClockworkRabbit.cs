using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkRabbit : MonoBehaviour
{

    Animator anim;
    public EnemySpawner enemySpawner;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;
    public Transform ProyectileSpawner;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 80;
        anim = GetComponent<Animator>();
        if (transform.position.y > 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
        }
        if (transform.position.y < 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
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
            attackTime = Random.Range(0.2f, 1.3f);
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
        health.TakeDamage(20);
    }
    void EnergyBall()
    {
        GameObject EnergyBall = GameObject.Instantiate(Resources.Load("Prefabs/BunnySteampunkProyectile") as GameObject);
        EnergyBall.transform.position = transform.position + new Vector3(-2.25f, -0.35f, 0);

    }
    void Over()
    {
        enemySpawner.OneDown();
        Destroy(gameObject);
        if (health.CanSpawnHeal == true)
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
