using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkBomb : MonoBehaviour
{

    
    public float timeToExplode;
    public float speed = 5f;
    
    public Animator animator;
    EnemyHealth health;

    [SerializeField] CircleCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<CircleCollider2D>();
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 1;
        StartCoroutine(ExplodeTimer());
       
        
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
        
        FindObjectOfType<AudioManager>().Play("ClockworkBombExplode");
        animator.SetTrigger("Explode!");
      
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void Over()
    {
        Destroy(gameObject);
    }




}
