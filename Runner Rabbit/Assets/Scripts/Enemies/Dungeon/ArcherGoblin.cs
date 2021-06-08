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

    ObjectPooler myObjectPooler;
    string arrowTag = "arrow";
    string HealTag = "Heal";

    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 9;
        anim = GetComponent<Animator>();
      
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
        health.TakeDamage(3);
    }
    void Arrow()
    {
        //GameObject arrow = GameObject.Instantiate(Resources.Load("Prefabs/Arrow") as GameObject);
        //arrow.transform.position = transform.position;
        GameObject arrow = myObjectPooler.SpawnFromPool(arrowTag, transform.position + new Vector3(-1.2f,-0.2f), Quaternion.identity, true);
        

        FindObjectOfType<AudioManager>().Play("Goblin Hit");

    }
    void Over()
    {
        //enemySpawner.OneDown();
        Destroy(gameObject);
        if (health.CanSpawnHeal == true)
        {
            // GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            //healthHeal.transform.position = transform.position;
            myObjectPooler.SpawnFromPool(HealTag, transform.position, Quaternion.identity);
        }
    }

    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("Goblin Death");

    }

}
