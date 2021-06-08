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
    public float batTime;
    bool attack;
    bool punch;
    bool bat;
    public GameObject[] bats;
    public GameObject[] healthBar;

    ObjectPooler myObjectPooler;
    string IcePunchTag = "IcePunch";
    string IceLanceTag = "IceLanceYeti";
    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        FindObjectOfType<AudioManager>().Play("YetiSpawn");
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        GameStats.stats.bossDead = false;
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 4f);
        punchTime = Random.Range(3f, 6f);
        batTime = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
        if (!GameStats.stats.bossDead)
        {
            attackTime -= Time.deltaTime;
            punchTime -= Time.deltaTime;
            batTime -= Time.deltaTime;
        }
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
            //GameObject icePunch = GameObject.Instantiate(Resources.Load("Prefabs/IcePunch") as GameObject);
            myObjectPooler.SpawnFromPool(IcePunchTag, transform.position, Quaternion.identity);
            health.TakeDamage(5);
            punch = false;
            punchTime = Random.Range(5f, 7f);
        }
        if (batTime <= 0 && !bat)
        {
            bat = true;
        }
        if (bat)
        {
            if (bats[0] == null)
            {
                bats[0] = Instantiate(Resources.Load("Prefabs/IceBat") as GameObject);
                bats[0].transform.SetParent(transform.parent);
                bats[0].transform.localPosition = new Vector3(0.77f, 4.15f, 0);
            }
            if (bats[1] == null)
            {
                bats[1] = Instantiate(Resources.Load("Prefabs/IceBat") as GameObject);
                bats[1].transform.SetParent(transform.parent);
                bats[1].transform.localPosition = new Vector3(0.77f, -3.59f, 0);
            }
            if (bats[2] == null)
            {
                bats[2] = Instantiate(Resources.Load("Prefabs/IceBat") as GameObject);
                bats[2].transform.SetParent(transform.parent);
                bats[2].transform.localPosition = new Vector3(0.77f, -7.09f, 0);
            }
            if (bats[3] == null)
            {
                bats[3] = Instantiate(Resources.Load("Prefabs/IceBat") as GameObject);
                bats[3].transform.SetParent(transform.parent);
                bats[3].transform.localPosition = new Vector3(0.77f, -14.83f, 0);
            }
            bat = false;
            batTime = Random.Range(4f, 7f);
        }
        if (health.health <= 0 && !GameStats.stats.bossDead)
        {
            FindObjectOfType<AudioManager>().Play("YetiDeath");
            anim.SetTrigger("Die");
            GameStats.stats.bossDead = true;
        }
    }
    public void Attack()
    {
        //GameObject iceLances = GameObject.Instantiate(Resources.Load("Prefabs/IceLances") as GameObject);
        GameObject iceLances = myObjectPooler.SpawnFromPool(IceLanceTag, transform.position, Quaternion.identity);
       
        iceLances.transform.position = transform.position + new Vector3(-1.57f, 0.27f, 0);
        attackTime = Random.Range(2f, 3f);
        attack = false;
        anim.SetBool("hasAttackedOnce", true);
        health.TakeDamage(5);
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
