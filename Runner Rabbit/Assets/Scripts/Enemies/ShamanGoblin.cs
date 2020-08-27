using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanGoblin : MonoBehaviour
{
    public float spawnTime;
    public float summonTime;
    public bool isPresent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = 30f;
            if (!isPresent)
            {
                anim.SetTrigger("Spawn");
                isPresent = true;
            }
        }
        if (isPresent)
        {
            summonTime -= Time.deltaTime;
        }
        if (summonTime <= 0)
        {
            anim.SetTrigger("Attack");
           
        }
           
    }

    void SpawnEnemies()
    {
        //Spawn
    }
}
