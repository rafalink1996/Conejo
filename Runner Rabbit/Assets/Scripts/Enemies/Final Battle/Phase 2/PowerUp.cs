﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IPooledObject
{
    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 1.0f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 1.0f;
    Animator anim;
    Vector3 pos;
    Vector3 axis;
    [SerializeField] TokenSpawnerShadow TKSpawner;

    [SerializeField] string tokenTag = "ShadowTokenArrow";
    ObjectPooler myObjectPooler;
    bool canCollide = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //StartCoroutine(Destroy());
        TKSpawner = FindObjectOfType<TokenSpawnerShadow>();
       

    }
    private void Start()
    {
        
        myObjectPooler = ObjectPooler.Instance;
        tokenTag = "ShadowTokenArrow";
    }
    public void OnObjectSpawn()
    {
        canCollide = true;
        speed = 1;
        frequency = 1;
        magnitude = 1;
        pos = transform.position;
        axis = transform.up;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canCollide)
        {
            anim.SetTrigger("Activate!");
            StartCoroutine(SpawnShadowMissle());
            speed = -10;
            frequency = 0;
            magnitude = 0;
            canCollide = false;
        }
    }

    void Update()
    {
        pos += Vector3.left * Time.deltaTime * speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude; // y = A sin(B(x)) , here A is Amplitude, and axis * magnitude is acting as amplitude. Amplitude means the depth of the sin curve
    }

    IEnumerator Destroy()
    {

        yield return new WaitForSeconds(10f);
        //TKSpawner.OneDown();
        //Destroy(gameObject);
    }

    IEnumerator SpawnShadowMissle()
    {

        yield return new WaitForSeconds(0.2f);
        //GameObject shadowArrow = GameObject.Instantiate(Resources.Load("Prefabs/ShadowArrow") as GameObject);
        //shadowArrow.transform.position = transform.position;
        //Destroy(shadowArrow, 5f);
        GameObject shadowArrow = myObjectPooler.SpawnFromPool(tokenTag, transform.position, Quaternion.identity, false);
        ShieldBreakPowerUp shadowArrowCs = shadowArrow.GetComponent<ShieldBreakPowerUp>();
        if(shadowArrowCs != null)
        {
            shadowArrowCs.StartDeactivate(5f);
        }
       
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);

        //TKSpawner.OneDown();
        //Destroy(gameObject);

    }

}
