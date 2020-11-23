using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlant : MonoBehaviour
{

    private Transform target;
    Animator anim;
    public EnemySpawner enemySpawner;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 50;
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
        if (health.health <= 0)
        {
            anim.SetTrigger("Die");
            if (GameStats.stats.monstersKilled < 400)
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
        GameObject peashooter = GameObject.Instantiate(Resources.Load("Prefabs/Peashooter") as GameObject);
        peashooter.transform.SetParent(transform);
        peashooter.transform.localPosition = new Vector3 (-2.07f, -0.79f, 0);
        peashooter.transform.SetParent(null);
        FindObjectOfType<AudioManager>().Play("PlantShoot");


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
        FindObjectOfType<AudioManager>().Play("BookDeSpawn");

    }
}
