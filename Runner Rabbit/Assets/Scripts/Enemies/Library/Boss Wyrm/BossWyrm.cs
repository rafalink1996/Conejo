﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossWyrm : MonoBehaviour
{
    public int element = 1;
    public int currentElement = 1;
    public GameObject[] portals;
    public GameObject[] attacks;
    public bool ice;
    public float iceTimer;
    Animator anim;
    public float timeToChange;
    public bool isChanging;
    character Cha;
    public bool bossTop;
    EnemyHealth health;
    public GameObject[] healthBar;
    public bool BossDead;

    [SerializeField] ObjectPooler myObjectPooler;
    string fireBallTag = "BossFireBall";
    string electricBallTag = "BossElectricBall";
    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 150;
        anim = GetComponent<Animator>();
        timeToChange = Random.Range(15f, 25f);
        iceTimer = Random.Range(10f, 15f);
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        BossDead = false;
        GameStats.stats.bossDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChanging)
        {
            timeToChange -= Time.deltaTime;

        }
        if (element == 1)
        {
            portals[0].SetActive(true);
            portals[1].SetActive(false);
            portals[2].SetActive(false);
        }
        if (element == 2 && !ice)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(true);
            portals[2].SetActive(false);
            //ice = true;
        }
        if (element == 3)
        {
            portals[0].SetActive(false);
            portals[1].SetActive(false);
            portals[2].SetActive(true);
        }
        if (ice)
        {
            iceTimer -= Time.deltaTime;
        }
        if (iceTimer <= 0)
        {
            ice = false;
            anim.SetBool("Ice", false);
            //iceTimer = 30f;
        }
        /*if (Input.GetKeyDown(KeyCode.U)) //for testing
        {
            anim.SetTrigger("Despawn"); //this will trigger the portal change
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (element == 1)
            {
                anim.SetTrigger("Shoot");
            }
            if (element == 2)
            {
                anim.SetTrigger("Shoot");
            }
            if(element == 3)
            {
                anim.SetTrigger("Shoot");
            }
        }*/
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
        /*if (Cha.top)
        {
            transform.parent.transform.localEulerAngles = new Vector3(180, 0, 0);
            
        }
        else
        {
            transform.parent.transform.localEulerAngles = new Vector3(0, 0, 0);
            
        }*/
        if (health.health <= 0 && !BossDead)
        {
            anim.SetTrigger("Die");
            BossDead = true;
            GameStats.stats.bossDead = true;
        }
    }
    public void ChangeElement()
    {
        if (BossDead == false)
        {
            if (element == 2 && anim.GetBool("Ice") == true)
            {
                element = 2;
            }
            else

                while (element == currentElement || element == 2 && ice)
                {
                    element = Random.Range(1, 4);
                }

            currentElement = element;
        }
        
    }
    public void NewPortal()
    {
        portals[currentElement - 1].GetComponent<Animator>().SetTrigger("Change");
    }
    public void Shoot()
    {
        if (element == 1)
        {
            //GameObject fireBall = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
            //fireBall.transform.localPosition = transform.position + new Vector3(-3.479728f, -0.07675886f, 0);

            GameObject fireBall = myObjectPooler.SpawnFromPool(fireBallTag, transform.position + new Vector3(-3,0,0), Quaternion.identity, true);
            //fireBall.transform.localPosition = transform.position + new Vector3(-3.479728f, -0.07675886f, 0);
            WyrmFireBall myFireBall = fireBall.GetComponentInChildren<WyrmFireBall>();
            if(myFireBall != null)
            {
                myFireBall.sourceTransform = this.transform;
            }
            else
            {
                Debug.Log("no fireball cs");
            }
            

            health.TakeDamage(3);
        }
        if (element == 3)
        {
            //GameObject thunderBall = Instantiate(Resources.Load("Prefabs/WyrmThunderBall") as GameObject);
            GameObject thunderBall = myObjectPooler.SpawnFromPool(electricBallTag, transform.position, Quaternion.identity, true);
            thunderBall.transform.position = transform.position + new Vector3(-3.479728f, -0.07675886f, 0);
            thunderBall.GetComponentInChildren<WyrmThunderBall>().sourceTransform = this.transform;
            health.TakeDamage(3);
        }
    }
    public void RiftAttack()
    {
        if (element == 2)
        {
            attacks[0].SetActive(true);
            //health.TakeDamage(1);
        }
        if (element == 3)
        {
            attacks[3].SetActive(true);
            health.TakeDamage(3);
        }
    }
    public void Ray()
    {
        if (element == 1)
        {
            attacks[1].SetActive(true);
            health.TakeDamage(5);
        }
        if (element == 2)
        {
            attacks[2].SetActive(true);
           // health.TakeDamage(1);
        }
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

    public void DeactivatePortalAfterDeath()
    {

        portals[currentElement - 1].GetComponent<Animator>().SetTrigger("Change");
    }
    public void Death()
    {
        Destroy(transform.parent.gameObject);
    }
}
