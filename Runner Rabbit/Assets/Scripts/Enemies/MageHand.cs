using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHand : MonoBehaviour
{

    private Transform target;
    public float speed;
    public float acceleration;
    private Animator animator;

    public EnemySpawner enemySpawner;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Attack(Random.Range(2f, 4f)));
        enemySpawner = GameObject.Find("Enemy Spawner (Hand)").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * acceleration * Time.deltaTime);
    }

    IEnumerator Attack (float time)

    {
        yield return new WaitForSeconds(time);
        GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageMissle") as GameObject);
        MageMissle.transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1f);

        enemySpawner.OneDown();

        Destroy(gameObject);



    }
}
