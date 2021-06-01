using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlant : MonoBehaviour
{
    public GameObject poisonAttack;
    public CarnovorousPlantSpawner leafAttack;
    //ParticleSystem poisonParticles;
    Animator anim;
    public float poisonTime;
    bool poison = false;
    public EnemyHealth health;
    public GameObject[] healthBar;
    public bool BossDead;

    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        //poisonParticles = poisonAttack.GetComponent<ParticleSystem>();
        //var main = poisonParticles.main;
        //main.duration = poisonTime;
        poisonTime = Random.Range(4f, 5f);
        health = GetComponent<EnemyHealth>();
        BossDead = false;
        GameStats.stats.bossDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (!poisonParticles.IsAlive() && poison)
        //{
        //    Invoke("DeactivatePoison", poisonTime);
        //}
        if (health.health <= 0 && !BossDead)
        {
            FindObjectOfType<AudioManager>().Play("CP_Death");
            anim.SetTrigger("Death");
            BossDead = true;
            GameStats.stats.bossDead = true;
        }
    }
    void ActivatePosion()
    {
        FindObjectOfType<AudioManager>().Play("CP_PosionLoop");
        //poisonParticles.Play();
        poisonAttack.SetActive(true);
        poison = true;
        Invoke("EndPoison", poisonTime);

    }

    void EndPoison()
    {
        FindObjectOfType<AudioManager>().Stop("CP_PosionLoop");
        //poisonAttack.SetActive(false);
        //poisonParticles.Stop();
        poisonAttack.GetComponent<Animator>().SetTrigger("End");
        anim.SetTrigger("Attack1End");
        poisonTime = Random.Range(4f, 5f);
        poison = false;
        health.TakeDamage(5);
    }
    void DeactivatePoison()
    {
        poisonAttack.SetActive(false);
    }
    void ActivateLeaves()
    {
        leafAttack.StartSpawning();
        health.TakeDamage(5);
        //Invoke("DeactivateLeaves", 4f);
    }

    void TakeDamageBite()
    {
        health.TakeDamage(5);
    }
    void DeactivateLeaves()
    {
        //leafAttack.StopSpawning();
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
