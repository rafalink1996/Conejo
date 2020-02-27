using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Animator anim;
    public int health = 3;
    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Die");
        }
    }
    void Attack()
    {
        health = health - 1;
    }
    void SlimeBall()
    {
        GameObject smileBall = GameObject.Instantiate(Resources.Load("Prefabs/Slime Ball") as GameObject);
        smileBall.transform.position = transform.position;
    }
    void Over()
    {
        enemySpawner.RestartTime();
        Destroy(gameObject);
    }

}
