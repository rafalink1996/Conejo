using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkBomb : MonoBehaviour
{

    
    public float timeToExplode;
    public float speed = 5f;
    
    public Animator animator;
    EnemyHealth health;
    
    public CircleCollider2D ExplotionCollider;
    // Start is called before the first frame update
    void Start()
    {
        
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 10;
        StartCoroutine(ExplodeTimer());
        ExplotionCollider.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if (health.health <= 0 || GameStats.stats.spawnHouse)
        {
            animator.SetTrigger("Explode!");
          

        }

    }

    IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(timeToExplode);
        ExplotionCollider.enabled = true;
        FindObjectOfType<AudioManager>().Play("ClockworkBombExplode");
        animator.SetTrigger("Explode!");
        if (ExplotionCollider.radius < 1.25f)
        {
            ExplotionCollider.radius += 0.2f;
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }

    void Over()
    {
        Destroy(gameObject);
    }




}
