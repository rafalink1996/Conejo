using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHand : MonoBehaviour, IPooledObject
{

    private Transform target;
    public float speed;
    public float acceleration;
    private Animator animator;

    // public EnemySpawner enemySpawner;
    [SerializeField] HandEyeSpawner mySpawner;
    [SerializeField] string missleTag = "MageMissle";
    ObjectPooler myObjectPooler;



    private void Awake()
    {
        missleTag = "MageMissle";
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        myObjectPooler = ObjectPooler.Instance;
        mySpawner = FindObjectOfType<HandEyeSpawner>();
        

        //enemySpawner = GameObject.Find("Enemy Spawner (Hand)").GetComponent<EnemySpawner>();
    }
    
    void Start()
    {
        //StartCoroutine(Attack(Random.Range(2f, 4f)));  
    }

    public void OnObjectSpawn()
    {
        
        StartCoroutine(Attack(Random.Range(2f, 4f)));
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * acceleration * Time.deltaTime);
    }

    IEnumerator Attack (float time)

    {
        yield return new WaitForSeconds(time);
        //GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageMissle") as GameObject);
        //MageMissle.transform.position = transform.position;
        GameObject ShootMissle = myObjectPooler.SpawnFromPool(missleTag, transform.position, Quaternion.identity, true);
        ShootMissle.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1f);

        mySpawner.StartEnemyTimer();
        gameObject.SetActive(false);
        //enemySpawner.OneDown();

       // Destroy(gameObject);



    }
}
