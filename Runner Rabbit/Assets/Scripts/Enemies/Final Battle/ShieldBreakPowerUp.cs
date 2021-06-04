using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBreakPowerUp : MonoBehaviour, IPooledObject
{
    public float speed;
    public float RotateSpeed = 50;
    public int damage;
    public Transform target = null;
    private Rigidbody2D rb;

    public GameObject[] watchenemies;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        FindClosestEnemy();
    }

    public void OnObjectSpawn()
    {
        Deactivate(5f);  
    }




    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * RotateSpeed;
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
            FindClosestEnemy();
            // Debug.Log("no target");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            print("hit " + collision.gameObject.name);
            gameObject.SetActive(false);
            //Destroy(gameObject);

        }
    }

    void FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject ClosestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (allEnemies.Length != 0)
        {

            Debug.Log("locatingEnemy");
            foreach (GameObject currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    ClosestEnemy = currentEnemy;
                }
            }

            target = ClosestEnemy.transform;
            Debug.Log("enemy located" + target.name); ;

        }
        else
        {
            // Debug.Log("no enemies");
        }

    }

    public void StartDeactivate(float time)
    {
        StartCoroutine(Deactivate(time));
    }
    IEnumerator Deactivate(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}


