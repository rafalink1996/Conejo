using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollGoblin : MonoBehaviour, IPooledObject
{
    public float attackTime;
    bool attack;
    Animator anim;
    public EnemyHealth health;
    public int myHealth = 100;
    public bool Agonize;
    public bool Alive;
    public int TrollId;

    ObjectPooler myObjectPooler;
    string slimeSlashTag = "SlimeSlash";

    // Start is called before the first frame update
    private void Awake()
    {
        myObjectPooler = ObjectPooler.Instance;
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Agonize = false;
        //FindObjectOfType<AudioManager>().Play("Troll_Spawn");
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        attackTime = Random.Range(1.3f, 4f);
        anim = GetComponent<Animator>();
    }

    public void OnObjectSpawn()
    {
        Alive = true;
        FindObjectOfType<AudioManager>().Play("Troll_Spawn");
        Agonize = false;
        health.maxHealth = myHealth;
        health.health = health.maxHealth;
        attackTime = Random.Range(1.3f, 4f);
        attack = false;
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
        if (health.health <= 0 || GameStats.stats.bossDead)
        {
            if (!Agonize)
            {
                FindObjectOfType<AudioManager>().Play("Troll_Death");
                anim.SetTrigger("Die");
                Agonize = true;
            }

            //FindObjectOfType<AudioManager>().Play("Troll_Death");
            //anim.SetTrigger("Die");
        }
    }
    void Attack()
    {
        //GameObject proyectile = Instantiate(Resources.Load("Prefabs/TrollProyectile") as GameObject);
        //proyectile.transform.position = transform.position + new Vector3(-3.359951f, 1.431809f, 0);

        GameObject proyectile = myObjectPooler.SpawnFromPool(slimeSlashTag, transform.position, Quaternion.identity, true);
        if(TrollId == 1)
        {
            proyectile.transform.position += new Vector3(-3.359951f, 1.431809f, 0);
        }
        else if(TrollId == 2)
        {
            proyectile.transform.position += new Vector3(-3.359951f, -1.431809f, 0);
        }
        attackTime = Random.Range(1.3f, 4f);
        attack = false;
        health.TakeDamage(9);
    }
    void Die()
    {
        Alive = false;
        transform.parent.gameObject.SetActive(false);
       // Destroy(transform.parent.gameObject);
    }


}
