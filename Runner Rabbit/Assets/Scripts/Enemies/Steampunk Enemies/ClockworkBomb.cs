using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkBomb : MonoBehaviour, IPooledObject
{

    
    public float timeToExplode;
    public float speed = 5f;
    
    public Animator animator;
    [SerializeField] EnemyHealth health;

    [SerializeField] CircleCollider2D myCollider;


    // Start is called before the first frame update
    private void Awake()
    {
        //Debug.Log("bomb Instantiated");
        myCollider = GetComponent<CircleCollider2D>();
        health = GetComponent<EnemyHealth>();
        
        
    }

    void Start()
    {
        health.maxHealth = 1;
        StartCoroutine(ExplodeTimer());
    }

    public void OnObjectSpawn()
    {
        health.maxHealth = 1;
        StartCoroutine(ExplodeTimer());
        //Invoke("Deactivate", 3);
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
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void Over()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }




}
