using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    Animator anim;
    public int attackNumber;
    public int attackMax;
    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackMax = Random.Range(1, 4);
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackNumber >= attackMax)
        {
            anim.SetTrigger("Die");
        }
    }
    void AddAttack()
    {
        attackNumber = attackNumber + 1;
    }
    void Over()
    {
        enemySpawner.RestartTime();
        Destroy(gameObject);
    }
    
}
