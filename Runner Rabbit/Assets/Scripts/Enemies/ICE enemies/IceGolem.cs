using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolem : MonoBehaviour
{

    Animator anim;
  
    public EnemySpawner enemySpawner;

    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;

    public IceGolemBoulder Boulder1;
    public IceGolemBoulder Boulder2;
    public IceGolemBoulder Boulder3;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 100;
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
            Boulder1.spawnboulder = true;
            Boulder2.spawnboulder = true;
            Boulder3.spawnboulder = true;

            GetComponent<SpriteRenderer>().enabled = true;
            FindObjectOfType<AudioManager>().Play("IceGolemspawn");
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
        if (health.health <= 0)
        {
            anim.SetTrigger("Die");
            Boulder3.BreakBoulder = true;
            if (GameStats.stats.monstersKilled < 400)
            {
                GameStats.stats.monstersKilled++;
            }
        }

        if (health.health <= 75)
        {
            Boulder1.BreakBoulder = true;
        }

        if (health.health <= 50)
        {
            Boulder2.BreakBoulder = true;
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
    void ThrowBoulders()
    {
        if (Boulder1.GoBack == false && Boulder2.GoBack == false && Boulder3.GoBack == false)
        {
            FindObjectOfType<AudioManager>().Play("IceGolemAttack");
            Boulder1.attack = true;
            Boulder2.attack = true;
            Boulder3.attack = true;

        }


    }
    void Over()
    {
        enemySpawner.OneDown();
        Destroy(gameObject);
        if (health.Hit == true)
        {
            GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            healthHeal.transform.position = transform.position;
        }
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("IceGolemdeath");

    }
}
