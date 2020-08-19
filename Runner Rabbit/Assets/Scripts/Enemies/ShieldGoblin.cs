using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGoblin : MonoBehaviour
{
    Animator anim;
    EnemyHealth health;
    public int myHealth;
    float spawnTime;
    bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        spawnTime = Random.Range(0.1f, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && spawned == false)
        {
            anim.SetTrigger("Spawn");
            GetComponent<SpriteRenderer>().enabled = true;
            FindObjectOfType<AudioManager>().Play("Goblin Spawn");
            Invoke("LoseHealth", 2f);
            spawned = true;

        }
        if (health.health <= 0)
        {
            anim.SetTrigger("Despawn");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "character proyectile")
        {
            FindObjectOfType<AudioManager>().Play("Goblin Shield Hit");
        }
    }
    void LoseHealth()
    {
        health.TakeDamage(10);
        Invoke("LoseHealth", 2f);
    }
    void Over()
    {
        //enemySpawner.OneDown();
        Destroy(gameObject);
        if (health.Hit == true)
        {
            GameObject healthHeal = GameObject.Instantiate(Resources.Load("prefabs/HeartHeal") as GameObject);
            healthHeal.transform.position = transform.position;
        }
    }
    void Despawned()
    {
        FindObjectOfType<AudioManager>().Play("Goblin Death");

    }
}
