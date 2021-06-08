using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBook : MonoBehaviour
{
    Animator anim;
    //public int maxHealth = 7;
    //public int health;
    public EnemySpawner enemySpawner;
    //public Slider healthSlider;
    float spawnTime;
    bool spawned = false;
    float attackTime;
    bool attack;
    EnemyHealth health;

    public int BookHealth = 18;
    public int BookSelfDamage = 6;

    ObjectPooler myObjectPooler;
    string iceLanceTag = "IceLanceBook";
    string HealTokenTag = "Heal";

    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        iceLanceTag = "IceLanceBook";

        if (GameStats.stats.LevelIndicator > 1)
        {
            BookHealth = 45;
            BookSelfDamage = 15;
        }

        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        health.maxHealth = BookHealth;
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
        if(attack)
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
        health.TakeDamage(BookSelfDamage);
    }
    void IceLance()
    {
        //GameObject iceLance = GameObject.Instantiate(Resources.Load("Prefabs/Ice Lance") as GameObject);
        //iceLance.transform.position = transform.position;
        GameObject iceLance = myObjectPooler.SpawnFromPool(iceLanceTag, transform.position, Quaternion.identity, true, true);
        for(int i = 0; i < iceLance.transform.childCount; i++)
        {
            GameObject iceLanceChild = iceLance.transform.GetChild(i).gameObject;
            if(iceLanceChild != null)
            {
                iceLanceChild.SetActive(true);
                IceLance iceLanceChildCS = iceLanceChild.GetComponent<IceLance>();
                if (iceLanceChildCS != null)
                {
                    iceLanceChildCS.OnObjectSpawn();
                    iceLanceChildCS.sourceTransform = gameObject.transform;
                }
            }
            else
            {
                Debug.Log("no Child ice lance");
            }
 
        }
        

        //iceLance.GetComponent<IceLance>().sourceTransform = gameObject.transform;
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

