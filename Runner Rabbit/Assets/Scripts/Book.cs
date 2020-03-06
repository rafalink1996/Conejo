﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    Animator anim;
    public int maxHealth = 5;
    public int health;
    EnemySpawner enemySpawner;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthSlider = GetComponentInChildren<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        if (health <= 0)
        {
            anim.SetTrigger("Die");
        }
    }
    void Attack()
    {
        health = health - 1;
    }
    void FireBall()
    {
        GameObject fireBall = GameObject.Instantiate(Resources.Load("Prefabs/Fireball") as GameObject);
        fireBall.transform.position = transform.position;
    }
    void Over()
    {
        enemySpawner.RestartTime();
        Destroy(gameObject);
    }
    
}
