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
    [SerializeField] GameObject EyeLaser;
    


    private void Awake()
    {
        
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        mySpawner = FindObjectOfType<HandEyeSpawner>();
        //StartCoroutine(Attack(Random.Range(2f, 4f)));
        //enemySpawner = GameObject.Find("Enemy Spawner (Hand)").GetComponent<EnemySpawner>();
        AttackMode = false;
    }

    public void OnObjectSpawn()
    {
        AttackMode = false;
        StartCoroutine(Attack(Random.Range(2f, 4f)));
    }

    
    void LateUpdate()
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
        EyeLaser.SetActive(true);
        EyeLaser.GetComponent<MageEyeLaser>().Attack();
    }

    public void StartDespawn()
    {
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1f);
        mySpawner.StartEnemyTimer();
        gameObject.SetActive(false);
    }
}
