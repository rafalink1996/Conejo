using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanGoblin : MonoBehaviour
{
    public float spawnTime;
    public float summonTime;
    public bool isPresent;
    public string[] summonName;
    public int summonType;
    public bool enemiespresent;
    Animator anim;
    public EnemyHealth health;
    public int myHealth;
    public Transform summonContainer;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        spawnTime = Random.Range(0.5f, 2f);
        anim = GetComponent<Animator>();
        summonTime = 3f;
        summonContainer = transform.Find("SummonContainer");
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            //spawnTime = 30f;
            if (!isPresent && !enemiespresent)
            {
                health.health = myHealth;
                anim.SetTrigger("Spawn");
                isPresent = true;
            }

        }
        if (isPresent && !enemiespresent)
        {
            summonTime -= Time.deltaTime;
        }
        if (summonTime <= 0 && !enemiespresent)
        {
            anim.SetTrigger("Attack");
            
            summonType = Random.Range(0, summonName.Length);
            summonTime = Random.Range(2f, 4f);
           
        }
           if (summonContainer.childCount == 0)
        {
            enemiespresent = false;
        }
           if (health.health <= 0 && isPresent)
        {
            spawnTime = 8f;
            isPresent = false;
            if (health.Hit)
            {
                anim.SetTrigger("Die");
            }
            else
            {
                anim.SetTrigger("Despawn");
            }
        }
    }

    void SpawnEnemies()
    {
        GameObject summon = Instantiate(Resources.Load("Prefabs/" + summonName[summonType]) as GameObject);
        summon.transform.position = transform.position + new Vector3 (0, 3, 0);
        summon.transform.SetParent(summonContainer);
        enemiespresent = true;
        health.TakeDamage(10);
    }
}
