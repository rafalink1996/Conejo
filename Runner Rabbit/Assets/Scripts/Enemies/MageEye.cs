using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEye : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float acceleration;
    private Animator animator;
    private bool AttackMode;

    public EnemySpawner enemySpawner;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Attack(Random.Range(2f, 4f)));
        enemySpawner = GameObject.Find("Enemy Spawner (Hand)").GetComponent<EnemySpawner>();
        AttackMode = false;
    }

    // Update is called once per frame
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
        GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageLaser") as GameObject);
        MageMissle.transform.position = new Vector2(transform.position.x-10, transform.position.y);
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1f);

        enemySpawner.OneDown();

        Destroy(gameObject);



    }
}
