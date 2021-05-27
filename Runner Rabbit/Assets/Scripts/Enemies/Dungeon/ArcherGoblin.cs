using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherGoblin : MonoBehaviour
{
    Animator anim;
    //public int maxHealth = 5;
    //public int health;
    //public EnemySpawner enemySpawner;
    //public Slider healthSlider;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    public EnemyHealth health;
    public int myHealth;

    // Start is called before the first frame update
    void Start()
    {
        
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 30;
        anim = GetComponent<Animator>();
       /* if (transform.position.y > 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
        }
        if (transform.position.y < 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
        }*/
        //enemySpawner = FindObjectOfType<EnemySpawner>();
        //healthSlider = GetComponentInChildren<Slider>();
        //health = maxHealth;
        //healthSlider.maxValue = maxHealth;
        spawnTime = Random.Range(0.1f, 1f);
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
            FindObjectOfType<AudioManager>().Play("Goblin Spawn");
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
        health.TakeDamage(10);
    }
    void Arrow()
    {
        GameObject arrow = GameObject.Instantiate(Resources.Load("Prefabs/Arrow") as GameObject);
        arrow.transform.position = transform.position;
        FindObjectOfType<AudioManager>().Play("Goblin Hit");

    }
    void Over()
    {
        //enemySpawner.OneDown();
        Destroy(gameObject);
        if (health.CanSpawnHeal == true)
        {
            GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            healthHeal.transform.position = transform.position;
        }
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("Goblin Death");

    }

}
