using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollGoblin : MonoBehaviour
{
    public float attackTime;
    bool attack;
    Animator anim;
    public EnemyHealth health;
    public int myHealth = 100;
    public bool Agonize;
    // Start is called before the first frame update
    void Start()
    {
        Agonize = false;
        FindObjectOfType<AudioManager>().Play("Troll_Spawn");
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        attackTime = Random.Range(1.3f, 4f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attack)
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0 && !attack)
        {
            anim.SetFloat("AttackType", Random.Range(1, 3));
            
            FindObjectOfType<AudioManager>().Play("Troll_Attack");
            anim.SetTrigger("Attack");
            attack = true;
        }
        if (health.health <= 0 || GameStats.stats.spawnHouse)
        {
            if (!Agonize)
            {
                FindObjectOfType<AudioManager>().Play("Troll_Death");
                Agonize = true;
            }

            FindObjectOfType<AudioManager>().Play("Troll_Death");
            anim.SetTrigger("Die");
        }
    }
    void Attack()
    {
        GameObject proyectile = Instantiate(Resources.Load("Prefabs/TrollProyectile") as GameObject);
        proyectile.transform.position = transform.position + new Vector3(-3.359951f, 1.431809f, 0);
        attackTime = Random.Range(1.3f, 4f);
        attack = false;
        health.TakeDamage(10);
    }
    void Die()
    {
        Destroy(transform.parent.gameObject);
    }


}
