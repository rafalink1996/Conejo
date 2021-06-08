using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayEnemy : MonoBehaviour
{

    [SerializeField] GameObject Ray;
    [SerializeField] ParticleSystem SparkparticleSystem;
    [SerializeField] Slider ChargeSlider;
    Animator RayAnimator;
    AudioManager myAudiomanager;


    float laserCharge = 0;
    bool laserCharged = false;
    int numOfSparks = 0;

    [SerializeField] float chargeRate;

    // Start is called before the first frame update
    void Start()
    {
        myAudiomanager = FindObjectOfType<AudioManager>();
        numOfSparks = 0;
        laserCharge = 0;
        ChargeSlider.value = laserCharge;
        
        RayAnimator = Ray.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ChargeSlider.value = laserCharge;
    }

    void LaserParticleSparks()
    {
        // play sound
        SparkparticleSystem.Play();
    }


    IEnumerator LaserSparks()
    {
        while (numOfSparks < 4)
        {
            yield return new WaitForSeconds(1);
            numOfSparks++;
            myAudiomanager.Play("SparkSFX");
            LaserParticleSparks();
        }
        FireLaser();
    }

    IEnumerator ChargeLaserOverTime()
    {
        StartCoroutine(ChargeLaserSFXDelay());
        while (!laserCharged)
        {
            yield return new WaitForSeconds(0.1f);
            laserCharge += chargeRate;
           
            if (laserCharge >= ChargeSlider.maxValue)
            {
                laserCharged = true;
                //Debug.Log("laserCharged");
            }

        }

        StartCoroutine(LaserSparks());
    }


    IEnumerator ChargeLaserSFXDelay()
    {
        yield return new WaitForSeconds(0.5f);
        myAudiomanager.Play("ChargeSFX");

    }
    void FireLaser()
    {
        Ray.SetActive(true);
        StartCoroutine(LaserTimer(7));

    }

    IEnumerator LaserTimer(float time)
    {
        myAudiomanager.Play("LaserStartSFX");
        myAudiomanager.Play("LaserLoopSFX");
        yield return new WaitForSeconds(time);
        RayAnimator.SetTrigger("StopRay");
        myAudiomanager.Stop("LaserLoopSFX");
        yield return new WaitForSeconds(0.6f);
        Ray.SetActive(false);
        StartCoroutine(DechargeLaser());

    }

    IEnumerator DechargeLaser()
    {
        while (laserCharged)
        {
            laserCharge -= chargeRate * 2;
            yield return new WaitForSeconds(0.1f);
            if(laserCharge <= ChargeSlider.minValue)
            {
                laserCharged = false;

            }
        }

        laserCharge = 0;
        numOfSparks = 0;

        StartCoroutine(TimeBetweenFires(3));

    }

    IEnumerator TimeBetweenFires(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(ChargeLaserOverTime());

    }

    public void StartRayLoop()
    {
        StartCoroutine(ChargeLaserOverTime());
    }




}
