using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeti : MonoBehaviour
{
    public EnemyHealth health;
        public int myHealth;
    public bool bossTop;
    Animator anim;
    public float attackTime;
    public float punchTime;
    bool attack;
    bool punch;
    public GameObject[] healthBar;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("YetiSpawn");
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        GameStats.stats.bossDead = false;
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 4f);
        punchTime = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
        attackTime -= Time.deltaTime;
        punchTime -= Time.deltaTime;
        if (attackTime <= 0 && !attack)
        {
            FindObjectOfType<AudioManager>().Play("YetiAttack");
            anim.SetTrigger("Attack");
            attack = true;
            
        }
        if (punchTime <= 0 && !punch)
        {
            punch = true;
        }
        if (punch)
        {
            
            GameObject icePunch = GameObject.Instantiate(Resources.Load("Prefabs/IcePunch") as GameObject);
            punch = false;
            punchTime = Random.Range(5f, 7f);
        }
        if (health.health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("YetiDeath");
            anim.SetTrigger("Die");
            GameStats.stats.bossDead = true;
        }
    }
    public void Attack()
    {
        GameObject iceLances = GameObject.Instantiate(Resources.Load("Prefabs/IceLances") as GameObject);
        iceLances.transform.position = transform.position + new Vector3(-1.57f, 0.27f, 0);
        attackTime = Random.Range(2f, 3f);
        attack = false;
        anim.SetBool("hasAttackedOnce", true);
    }
    void DeactivateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        healthBar[0].SetActive(false);
        healthBar[1].SetActive(false);
        healthBar[2].SetActive(false);
    }
    void ActivateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        healthBar[0].SetActive(true);
        healthBar[1].SetActive(true);
        healthBar[2].SetActive(true);
    }
}
