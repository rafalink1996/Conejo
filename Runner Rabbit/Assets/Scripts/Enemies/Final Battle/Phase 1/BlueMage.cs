using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueMage : MonoBehaviour
{

    //Material BlueMageMaterial;

    public GameObject BlueMageMask;
    public float TransformDissolve;
    public float maxTransformDissolve = 7;

    EnemyHealth BlueMageHealth;
    public float maxHealth;
    public float health;


    //public BlueHandFollow HandFollow;
    //public BlueHandRandom HandRandom;

    //public GameObject HandRandom75;
    //public GameObject HandRandom50;
    //public GameObject HandRandom25;

    //public GameObject HandFollow50;
    //public GameObject HandFollow25;

    public SpawnHand[] SpawnPortals;

    public GameObject ShadowMage;

    [SerializeField] GameObject[] HandsRandoms;
    [SerializeField] GameObject[] Handsfollows;

    bool HandsActivated100;
    bool HandsActivated75;
    bool HandsActivated50;
    bool HandsActivated25;



    public float HealthPercetnage;



    // Start is called before the first frame update
    void Start()
    {
        BlueMageHealth = GetComponent<EnemyHealth>();

        HandsActivated75 = false;

        maxTransformDissolve = 5;
        TransformDissolve = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = ShadowMage.transform.position;

        health = BlueMageHealth.health;
        maxHealth = BlueMageHealth.maxHealth;


        HealthPercetnage = Mathf.Round((health / maxHealth) * 100);


        TransformDissolve = 5 - ((HealthPercetnage / 100) * maxTransformDissolve);
        BlueMageMask.transform.localPosition = new Vector3(5 - TransformDissolve, 0, 0);

        //BlueMageMaterial.SetFloat("_Dissolve", TransformDissolve -3);


        if (HealthPercetnage <= 100 && HealthPercetnage > 75 && !HandsActivated100)
        {
            for (int i = 0; i < 1; i++)
            {
                HandsRandoms[i].SetActive(true);
                BlueHandRandom HandRandomCS = HandsRandoms[i].GetComponent<BlueHandRandom>();
                HandRandomCS.AttackSelfDamage = 3;
                HandRandomCS.TimeBetweenAttacksMin = 2;
                HandRandomCS.TimeBetweenAttacksMax = 4;
            }
            for (int i = 0; i < 1; i++)
            {

                Handsfollows[i].SetActive(true);
                BlueHandFollow handFollowsCS = Handsfollows[i].GetComponent<BlueHandFollow>();
                handFollowsCS.AttackSelfDamage = 3;
                handFollowsCS.TimeBetweenAttacksMin = 2;
                handFollowsCS.TimeBetweenAttacksMax = 4;
            }

            Debug.Log("health in 100%");
            HandsActivated100 = true;
        }
        if (HealthPercetnage <= 75 && HealthPercetnage > 50 && !HandsActivated75)
        {
            for (int i = 0; i < 2; i++)
            {
                HandsRandoms[i].SetActive(true);
                BlueHandRandom HandRandomCS = HandsRandoms[i].GetComponent<BlueHandRandom>();
                HandRandomCS.AttackSelfDamage = 2;
                HandRandomCS.TimeBetweenAttacksMin = 3;
                HandRandomCS.TimeBetweenAttacksMax = 4;
            }
            for (int i = 0; i < 1; i++)
            {

                Handsfollows[i].SetActive(true);
                BlueHandFollow handFollowsCS = Handsfollows[i].GetComponent<BlueHandFollow>();
                handFollowsCS.AttackSelfDamage = 2;
                handFollowsCS.TimeBetweenAttacksMin = 3;
                handFollowsCS.TimeBetweenAttacksMax = 4;
            }

            Debug.Log("health in 75%");
            HandsActivated75 = true;
        }

        if (HealthPercetnage <= 50 && HealthPercetnage > 25 && !HandsActivated50)
        {
            for (int i = 0; i < 3; i++)
            {
                HandsRandoms[i].SetActive(true);
                BlueHandRandom HandRandomCS = HandsRandoms[i].GetComponent<BlueHandRandom>();
                HandRandomCS.AttackSelfDamage = 1;
                HandRandomCS.TimeBetweenAttacksMin = 3;
                HandRandomCS.TimeBetweenAttacksMax = 4;
            }
            for (int i = 0; i < 2; i++)
            {

                Handsfollows[i].SetActive(true);
                BlueHandFollow handFollowsCS = Handsfollows[i].GetComponent<BlueHandFollow>();
                handFollowsCS.AttackSelfDamage = 1;
                handFollowsCS.TimeBetweenAttacksMin = 3;
                handFollowsCS.TimeBetweenAttacksMax = 4;
            }
            Debug.Log("health in 50%");
            HandsActivated50 = true;
        }
        if (HealthPercetnage <= 25 && HealthPercetnage > 0 && !HandsActivated25)
        {
            for (int i = 0; i < 4; i++)
            {
                HandsRandoms[i].SetActive(true);
                BlueHandRandom HandRandomCS = HandsRandoms[i].GetComponent<BlueHandRandom>();
                HandRandomCS.AttackSelfDamage = 0.5f;
                HandRandomCS.TimeBetweenAttacksMin = 2;
                HandRandomCS.TimeBetweenAttacksMax = 3;

            }
            for (int i = 0; i < 3; i++)
            {

                Handsfollows[i].SetActive(true);
                BlueHandFollow handFollowsCS = Handsfollows[i].GetComponent<BlueHandFollow>();
                handFollowsCS.AttackSelfDamage = 0.5f;
                handFollowsCS.TimeBetweenAttacksMin = 2;
                handFollowsCS.TimeBetweenAttacksMax = 3;
            }

            Debug.Log("health in 25%");

            HandsActivated25 = true;
        }

        if (HealthPercetnage <= 0)
        {
            StartCoroutine(DeactivateHands());
            SpawnPortals[0].PortalAnimatorSetTrigger();
            SpawnPortals[1].PortalAnimatorSetTrigger();
            SpawnPortals[2].PortalAnimatorSetTrigger();
            SpawnPortals[3].PortalAnimatorSetTrigger();
            SpawnPortals[4].PortalAnimatorSetTrigger();
            SpawnPortals[5].PortalAnimatorSetTrigger();
            SpawnPortals[6].PortalAnimatorSetTrigger();





        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }

    IEnumerator DeactivateHands()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < Handsfollows.Length; i++)
        {
            Handsfollows[i].SetActive(false);
        }
        for (int i = 0; i < HandsRandoms.Length; i++)
        {
            HandsRandoms[i].SetActive(false);
        }

        //HandRandom25.SetActive(false);
        //HandRandom50.SetActive(false);
        //HandRandom75.SetActive(false);
        //HandFollow.gameObject.SetActive(false);
        //HandRandom.gameObject.SetActive(false);
        //HandFollow50.SetActive(false);
        //HandFollow25.SetActive(false);

        ShadowMage ShadowMageScript = ShadowMage.GetComponent<ShadowMage>();
        ShadowMageScript.ShadowMageStart();

        gameObject.SetActive(false);
    }
}
