﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricBook : MonoBehaviour
{
    Animator anim;
    public int maxHealth = 8;
    public int health;
    EnemySpawner enemySpawner;
    public Slider healthSlider;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthSlider = GetComponentInChildren<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
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
        healthSlider.value = health;
        if (health <= 0)
        {
            anim.SetTrigger("Die");
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
        health = health - 1;
    }
    void ElectricBall()
    {
        GameObject electricBall = GameObject.Instantiate(Resources.Load("Prefabs/Electric ball") as GameObject);
        //electricBall.transform.SetParent(transform, false);
        electricBall.transform.position = transform.position;
        
    }
    void Over()
    {
        enemySpawner.OneDown();
        Destroy(gameObject);
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("BookDeSpawn");

    }


}
