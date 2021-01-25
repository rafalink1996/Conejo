using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueMage : MonoBehaviour
{
   
    Material BlueMageMaterial;
    public float TransformDissolve;
    public float maxTransformDissolve = 7;

    EnemyHealth BlueMageHealth;
    public float maxHealth;
    public float health;
    

    public BlueHandFollow HandFollow;
    public BlueHandRandom HandRandom;

    public GameObject HandRandom75;
    public GameObject HandRandom50;
    public GameObject HandRandom25;

    public GameObject HandFollow50;
    public GameObject HandFollow25;

    public SpawnHand[] SpawnPortals;

    public GameObject ShadowMage;


    



    // Start is called before the first frame update
    void Start()
    {
        BlueMageHealth = GetComponent<EnemyHealth>();
        BlueMageMaterial = GetComponent<SpriteRenderer>().material;

        
        maxTransformDissolve = 7;
        TransformDissolve = maxTransformDissolve;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ShadowMage.transform.position;

        health = BlueMageHealth.health;
        maxHealth = BlueMageHealth.maxHealth;
        

        float HealthPercetnage = Mathf.Round((health / maxHealth) * 100);
        

        TransformDissolve = (HealthPercetnage / 100) * maxTransformDissolve;

        BlueMageMaterial.SetFloat("_Dissolve", TransformDissolve -3);

        if (HealthPercetnage <= 75 && HealthPercetnage > 50)
        {
            HandFollow.speed = 8;
            HandFollow.TimeBetweenAttacks = 3;
            HandFollow.AttackSelfDamage = 2;
            HandRandom.AttackSelfDamage = 2;
            HandRandom.TimeBetweenAttacks = 3;
            HandRandom75.SetActive(true);
        }

        if (HealthPercetnage <= 50 && HealthPercetnage > 25)
        {
            HandFollow.speed = 10;
            HandFollow.TimeBetweenAttacks = 2;
            HandRandom.TimeBetweenAttacks = 2;

            HandFollow.AttackSelfDamage = 2;
            HandRandom.AttackSelfDamage = 2;

            HandRandom50.SetActive(true);
            HandFollow50.SetActive(true);
        }
        if (HealthPercetnage <= 25)
        {
            HandFollow.AttackSelfDamage = 1;
            HandFollow.speed = 12;
            HandFollow.TimeBetweenAttacks = 1;

            HandRandom.AttackSelfDamage = 1;
            HandRandom.TimeBetweenAttacks = 1;

            HandRandom25.SetActive(true);
            HandFollow25.SetActive(true);
        }

        if (HealthPercetnage <= 0)
        {
            SpawnPortals[0].PortalAnimatorSetTrigger();
            SpawnPortals[1].PortalAnimatorSetTrigger();
            SpawnPortals[2].PortalAnimatorSetTrigger();
            SpawnPortals[3].PortalAnimatorSetTrigger();
            SpawnPortals[4].PortalAnimatorSetTrigger();
            SpawnPortals[5].PortalAnimatorSetTrigger();
            SpawnPortals[6].PortalAnimatorSetTrigger();

            StartCoroutine(DeactivateHands());
            

           
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }

    IEnumerator DeactivateHands()
    {
        yield return new WaitForSeconds(1.5f);
        HandRandom25.SetActive(false);
        HandRandom50.SetActive(false);
        HandRandom75.SetActive(false);
        HandFollow.gameObject.SetActive(false);
        HandRandom.gameObject.SetActive(false);
        HandFollow50.SetActive(false);
        HandFollow25.SetActive(false);

        ShadowMage ShadowMageScript = ShadowMage.GetComponent<ShadowMage>();
        ShadowMageScript.ShadowMageStart();

        gameObject.SetActive(false);
    }
}
