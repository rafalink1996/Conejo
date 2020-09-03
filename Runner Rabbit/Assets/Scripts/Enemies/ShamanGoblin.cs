using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanGoblin : MonoBehaviour
{
    public float spawnTime;
    public float summonTime;
    public bool isPresent;
    public string[] summonName;
    public int summonType;
    public bool enemiespresent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(0.5f, 2f);
        anim = GetComponent<Animator>();
        summonTime = 3f;
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
        if (isPresent && !enemiespresent)
        {
            summonTime -= Time.deltaTime;
            //enemiespresent = true;
        }
        if (summonTime <= 0 && !enemiespresent)
        {
            anim.SetTrigger("Attack");
            
            summonType = Random.Range(0, summonName.Length);
            summonTime = Random.Range(2f, 4f);
           
        }
           if (transform.childCount == 0)
        {
            enemiespresent = false;
        }
    }

    void SpawnEnemies()
    {
        print("Summon");
        GameObject summon = Instantiate(Resources.Load("Prefabs/" + summonName[summonType]) as GameObject);
        summon.transform.position = transform.position + new Vector3 (0, 3, 0);
        summon.transform.SetParent(transform);
        enemiespresent = true;
    }
}
