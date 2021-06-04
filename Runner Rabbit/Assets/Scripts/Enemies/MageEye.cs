using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEye : MonoBehaviour, IPooledObject
{
    private Transform target;
    public float speed;
    public float acceleration;
    private Animator animator;
    private bool AttackMode;

    public EnemySpawner enemySpawner;
    [SerializeField] HandEyeSpawner mySpawner;
    [SerializeField] GameObject Laser;
    


    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        mySpawner = FindObjectOfType<HandEyeSpawner>();
    }

    void Start()
    {
       
        //StartCoroutine(Attack(Random.Range(2f, 4f)));
        //enemySpawner = GameObject.Find("Enemy Spawner (Hand)").GetComponent<EnemySpawner>();
        AttackMode = false;
    }

    public void OnObjectSpawn()
    {
        AttackMode = false;
        StartCoroutine(Attack(Random.Range(2f, 4f)));
    }

    
    void Update()
    {
        if (AttackMode)
        {
            transform.position = transform.position;
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * acceleration * Time.deltaTime);
        }
    }


    IEnumerator Attack(float time)

    {
        
        yield return new WaitForSeconds(time);
        AttackMode = true;
        yield return new WaitForSeconds(1f);
        //GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageLaser") as GameObject);
        //MageMissle.transform.position = new Vector2(transform.position.x-10, transform.position.y);
        Laser.SetActive(true);
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1f);
        mySpawner.StartEnemyTimer();
        gameObject.SetActive(false);
        //enemySpawner.OneDown();
        //Destroy(gameObject);



    }
}
