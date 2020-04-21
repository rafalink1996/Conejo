using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    Animator anim;
    public int maxHealth = 3;
    public int health;
    EnemySpawner enemySpawner;
    public Slider healthSlider;
    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        healthSlider = GetComponentInChildren<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        spawnTime = Random.Range(0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            anim.SetTrigger("Spawn");
            GetComponent<SpriteRenderer>().enabled = true;

        }
        healthSlider.value = health;
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
        enemySpawner.OneDown();
        Destroy(gameObject);
    }

}
