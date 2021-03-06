﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlant : MonoBehaviour
{
    [SerializeField] Transform ShootingPoint;
    private Transform target;
    Animator anim;
    public EnemySpawner enemySpawner;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;


    ObjectPooler myObjectPooler;
    string PoisonProyectileTag = "Poison";
    string HealTokenTag = "Heal";

    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        PoisonProyectileTag = "Poison";

        target = GameObject.FindWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 30;
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
        RotateTowards(target.position);
        transform.Find("Canvas").rotation = Quaternion.Euler(0, 0, 0);
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && spawned == false)
        {
            anim.SetTrigger("Spawn");
            GetComponent<SpriteRenderer>().enabled = true;
            FindObjectOfType<AudioManager>().Play("Plant Spawn");
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

    private void RotateTowards(Vector2 target)
    {
        var offset = 180f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
    void Peashooter()
    {
        //GameObject peashooter = GameObject.Instantiate(Resources.Load("Prefabs/Peashooter") as GameObject);
        //peashooter.transform.SetParent(transform);
        //peashooter.transform.localPosition = new Vector3 (-2.07f, -0.79f, 0);
        //peashooter.transform.SetParent(null);
        GameObject peashooterObj = myObjectPooler.SpawnFromPool(PoisonProyectileTag, ShootingPoint.position, Quaternion.identity, true);
        peashooter peashooterCs = peashooterObj.GetComponentInChildren<peashooter>();
        if(peashooterCs != null)
        peashooterCs.sourceTransform = this.transform;
        FindObjectOfType<AudioManager>().Play("PlantShoot");


    }
    void Over()
    {

        enemySpawner.OneDown();
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
