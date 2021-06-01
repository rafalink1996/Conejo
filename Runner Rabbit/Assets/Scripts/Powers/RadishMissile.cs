using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishMissile : MonoBehaviour
{
    public float speed;
    public float RotateSpeed = 50;
    public float damage;
    public Transform target = null;
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] List<GameObject> posibleEnemies = null;

    //public GameObject[] watchenemies;
    [SerializeField] float targetYPos;
   [SerializeField] float startYPos;
    [SerializeField] float startXpos;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        startYPos = transform.position.y;
        startXpos = transform.position.x;

        target = FindClosestEnemy();
        if(target != null)
        {
            // its ok bud
            targetYPos = target.position.y;
        }
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(speed * Time.deltaTime, 0, 0);
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
            //FindClosestEnemy();
            // Debug.Log("no target");
        }




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            Destroy(gameObject);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            Destroy(gameObject);


        }
    }

    Transform FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject ClosestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (allEnemies != null)
        {
            if (startYPos >= 0)
            {
                for (int i = 0; i < allEnemies.Length; i++)
                { 
                    if (allEnemies[i].transform.position.y >= 0 && allEnemies[i].transform.position.x > startXpos)
                    {
                        posibleEnemies.Add(allEnemies[i]);
                    }
                }
            }
            else if (startYPos < 0)
            {
                for (int i = 0; i < allEnemies.Length; i++)
                {
                    if (allEnemies[i].transform.position.y < 0 && allEnemies[i].transform.position.x > startXpos)
                    {
                        posibleEnemies.Add(allEnemies[i]);
                    }
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
       





        if (posibleEnemies.Count != 0)
        {

            //Debug.Log("locatingEnemy");
            foreach (GameObject currentEnemy in posibleEnemies)
            {

                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    ClosestEnemy = currentEnemy;
                }
            }

            //target = ClosestEnemy.transform;
            return ClosestEnemy.transform;
            //Debug.Log("enemy located" + target.name); ;

        }
        else
        {
            // Debug.Log("no enemies");
            return null;
        }

    }
}
