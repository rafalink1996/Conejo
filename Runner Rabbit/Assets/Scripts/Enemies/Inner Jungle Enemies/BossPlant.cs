using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlant : MonoBehaviour
{
    public GameObject poisonAttack;
    public CarnovorousPlantSpawner leafAttack;
    ParticleSystem poisonParticles;
    Animator anim;
    public float poisonTime;
    bool poison = false;
    
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        poisonParticles = poisonAttack.GetComponent<ParticleSystem>();
        var main = poisonParticles.main;
        main.duration = poisonTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (!poisonParticles.IsAlive() && poison)
        //{
        //    Invoke("DeactivatePoison", poisonTime);
        //}
    }
    void ActivatePosion()
    {
        poisonParticles.Play();
        //poisonAttack.SetActive(true);
        poison = true;
        Invoke("DeactivatePoison", poisonTime);
    }

    void DeactivatePoison()
    {
        //poisonAttack.SetActive(false);
        poisonParticles.Stop();
        anim.SetTrigger("Attack1End");
        //poisonTime = 4f;
        poison = false;
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
