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
    
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        //poisonParticles = poisonAttack.GetComponent<ParticleSystem>();
        //var main = poisonParticles.main;
        //main.duration = poisonTime;
        poisonTime = Random.Range(4f, 5f);
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (!poisonParticles.IsAlive() && poison)
        //{
        //    Invoke("DeactivatePoison", poisonTime);
        //}
        if (health.health <= 0)
        {
            anim.SetTrigger("Death");
        }
    }
    void ActivatePosion()
    {
        //poisonParticles.Play();
        poisonAttack.SetActive(true);
        poison = true;
        Invoke("EndPoison", poisonTime);
    }

    void EndPoison()
    {
        //poisonAttack.SetActive(false);
        //poisonParticles.Stop();
        poisonAttack.GetComponent<Animator>().SetTrigger("End");
        anim.SetTrigger("Attack1End");
        poisonTime = Random.Range(4f, 5f);
        poison = false;
    }
    void DeactivatePoison()
    {
        poisonAttack.SetActive(false);
    }
    void ActivateLeaves()
    {
        leafAttack.StartSpawning();
        //Invoke("DeactivateLeaves", 4f);
    }
    void DeactivateLeaves()
    {
        //leafAttack.StopSpawning();
    }
}
