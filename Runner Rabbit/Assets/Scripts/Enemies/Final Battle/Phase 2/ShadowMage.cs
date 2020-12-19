using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowMage : MonoBehaviour
{

    Animator ShadowMageAnimator;
    Material ShadowMageMaterial;

    public float YPos;
    public float minYPos;
    public float maxYPos;

    public float Speed;

    // dissolve parameteres
    public float TransformDissolve;
    

    //LifeBarUpdate

    public GameObject HealthSlider;
    EnemyHealth ShadowMageHealth;


    // ShadowLaser

    public GameObject ShadowLaser;

    //Spawners

    public GameObject EnemySpawnerUp;
    public GameObject EnemySpawnerDown;

    //Shield

    public GameObject ShadowShield;
    ShadowShield ShadowShieldCS;
    public bool ShieldIsUp;
    public GameObject ShieldTokenSpawner;
   


    void Start()
    {
        ShadowMageAnimator = GetComponent<Animator>();
        ShadowMageMaterial = GetComponent<SpriteRenderer>().material;
        ShadowMageHealth = GetComponent<EnemyHealth>();
        ShadowShieldCS = ShadowShield.GetComponent<ShadowShield>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(YPos))
        {
            YPos = Random.Range(minYPos, maxYPos);
        }
        else

        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, YPos, transform.position.z), Speed * Time.deltaTime);
        }


        if (ShadowMageHealth.health <= 0)
        {
            EnemySpawnerDown.SetActive(false);
            EnemySpawnerUp.SetActive(false);
            StartCoroutine(Dissolve());
            ShadowMageMaterial.SetFloat("_Fade", TransformDissolve);
        }

        // Shadow Shield Is Up

        if (ShadowShieldCS.isShielded == true)
        {
            ShieldIsUp = true;
        }
        else {
            ShieldIsUp = false;

        }


       

        



    }

    public void ShadowMageStart()
    {
        StartCoroutine(ShadwMagePhaseStart());
    }

   

    IEnumerator ShadwMagePhaseStart()
    {
        ShadowMageAnimator.SetTrigger("Transform");
        yield return new WaitForSeconds(5);
        HealthSlider.SetActive(true);
        ShadowMageHealth.health = 1;
        StartCoroutine(HealthHeal());
        yield return new WaitForSeconds(2);
        EnemySpawnerUp.SetActive(true);
        EnemySpawnerDown.SetActive(true);
        ShadowShield.SetActive(true);
        ShieldTokenSpawner.SetActive(true);
        StartCoroutine(ShadowMagelaserAttack(Random.Range(3f, 5f)));
    }

    IEnumerator HealthHeal()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (ShadowMageHealth.health < ShadowMageHealth.maxHealth)
            {
                ShadowMageHealth.health += 2;
            }
            else
            {
                break;
            }
        }
    }
    IEnumerator ShadowMagelaserAttack(float TimeBetweenLaserAttacks)
    {

        Animator ShadowLaserAnimator = ShadowLaser.GetComponent<Animator>();
        while (true)
        {
            if (ShadowMageHealth.health > 0)
            {
                yield return new WaitForSeconds(TimeBetweenLaserAttacks);
                ShadowLaser.SetActive(true);
                yield return new WaitForSeconds(Random.Range(3, 5));
                ShadowLaserAnimator.SetTrigger("EndLoop");

                if (ShieldIsUp != true)
                {
                    ShadowMageHealth.TakeDamage(5);
                }
                
                yield return new WaitForSeconds(1.5f);
                ShadowLaser.SetActive(false);
            }
            else
            {
                ShadowLaserAnimator.SetTrigger("EndLoop");
                yield return new WaitForSeconds(1.5f);
                ShadowLaser.SetActive(false);
                break;
            }

            

        }
        
    }

 
    IEnumerator Dissolve()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (TransformDissolve > 0)
            {
                TransformDissolve -= 0.01f;
            }
            else
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }

   

   
}
