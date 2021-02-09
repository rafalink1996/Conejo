using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageGoblin : MonoBehaviour
{
    public EnemyHealth health;
    public int myHealth;
    float attackTime;
    float invokeTime;
    bool attack;
    bool invoke;
    Animator anim;
    public GameObject troll1Object;
    public GameObject troll2Object;
    public bool bossTop;
    public GameObject[] healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 4f);
        invokeTime = Random.Range(8f, 15f);
        GameStats.stats.bossDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (troll1Object == null || troll2Object == null)
        {
            invokeTime -= Time.deltaTime;
        }
        if (invokeTime <= 0)
        {
            invoke = true;   
        }
        
        attackTime -= Time.deltaTime;
        if (attackTime <= 0 && !attack)
        {
            if (!invoke)
            {
                anim.SetTrigger("Attack");
                attack = true;
            }
            else
            {
                anim.SetTrigger("Invoke");
                attack = true;
            }
        }
        if (health.health <= 0)
        {
            anim.SetTrigger("Die");
            GameStats.stats.bossDead = true;
        }
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
    }
    void Attack()
    {
        GameObject fireball = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
        fireball.GetComponentInChildren<WyrmFireBall>().sourceTransform = gameObject.transform;
        fireball.transform.position = transform.position + new Vector3(-1.965444f, -0.1070113f, 0);
        attackTime = Random.Range(3f, 5f);
        attack = false;
        anim.SetBool("hasAttackedOnce", true);
        health.TakeDamage(5);
    }
    void Invoke()
    {
        if (troll1Object == null)
        {
            GameObject troll1 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll1Object = troll1;
            troll1.transform.position = new Vector3(transform.position.x - 6.2f, 4.31f, 0);
        }
        if (troll2Object == null)
        {
            GameObject troll2 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll2Object = troll2;
            troll2.transform.position = new Vector3(transform.position.x - 6.2f, -7.66f, 0);
        }
        attackTime = Random.Range(3f, 5f);
        attack = false;
        invokeTime = Random.Range(8f, 15f);
        invoke = false;
        health.TakeDamage(5);
        //anim.SetBool("hasAttackedOnce", true);
    }
    void DeactivateCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        healthBar[0].SetActive(false);
        healthBar[1].SetActive(false);
        healthBar[2].SetActive(false);
    }
    void ActivateCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        healthBar[0].SetActive(true);
        healthBar[1].SetActive(true);
        healthBar[2].SetActive(true);
    }
}
