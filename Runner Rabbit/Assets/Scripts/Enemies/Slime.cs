﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    Animator anim;
    //public int maxHealth = 3;
    //public int health;
    public EnemySpawner enemySpawner;
    //public Slider healthSlider;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;

    public int slimeHealth = 6;
    public int slimeSelfDamage = 2;

    ObjectPooler myObjectPooler;
    string slimeBallTag = "SlimeBall";
    string HealTokenTag = "Heal";
    

    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = slimeHealth;
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
            FindObjectOfType<AudioManager>().Play("SlimePreSpawn");
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
        health.TakeDamage(slimeSelfDamage);
    }
    void SlimeBall()
    {
        myObjectPooler.SpawnFromPool(slimeBallTag, transform.position, Quaternion.identity, true);
        //GameObject smileBall = GameObject.Instantiate(Resources.Load("Prefabs/Slime Ball") as GameObject);
        //smileBall.transform.position = transform.position;
    }
    void Over()
    {
        enemySpawner.OneDown();
        if (health.CanSpawnHeal == true)
        {
            myObjectPooler.SpawnFromPool(HealTokenTag, transform.position, Quaternion.identity);
            //GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            //healthHeal.transform.position = transform.position;
        }
        Destroy(gameObject);


    }

    void PLaySpawnSound()
    {
        FindObjectOfType<AudioManager>().Play("SlimeSpawn");
    }

    void PLayDeathSound ()
    {
        FindObjectOfType<AudioManager>().Play("SlimeDeath");
    }

}
