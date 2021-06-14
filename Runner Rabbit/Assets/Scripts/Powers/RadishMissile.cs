using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishMissile : MonoBehaviour, IPooledObject
{
    public float speed;
    public float RotateSpeed = 50;
    public float damage;
    public Transform target = null;
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] List<GameObject> posibleEnemies = null;
    [SerializeField] ParticleSystem CollisionParticle;

    //public GameObject[] watchenemies;
    [SerializeField] float targetYPos;
   [SerializeField] float startYPos;
    [SerializeField] float startXpos;

    ObjectPooler myObjectPooler;
    string ColParticlesTag = "CollisionParticles";

    // Start is called before the first frame update
    private void Awake()
    {
        myObjectPooler = ObjectPooler.Instance;
        ColParticlesTag = "CollisionParticles";
    }
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        ColParticlesTag = "CollisionParticles";
        //Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnObjectSpawn()
    {
        //Invoke("Deactivate", 5);
        posibleEnemies.Clear();
        startYPos = transform.position.y;
        startXpos = transform.position.x;
        target = FindClosestEnemy();
        if (target != null)
        {
            // its ok bud
            targetYPos = target.position.y;
        }
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
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Enemy")
    //    {
    //        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
    //        collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
    //        //print("hit " + collision.gameObject.name);
    //        Destroy(gameObject);


    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            //Destroy(gameObject);
            target = null;
            Deactivate();
           
            if(myObjectPooler != null)
            {
              myObjectPooler.SpawnFromPool(ColParticlesTag, transform.position, Quaternion.identity);

            }
            else
            {
                Debug.Log("no objectPooler");
            }


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
                    if (allEnemies[i].transform.position.y >= 0 && allEnemies[i].transform.position.x > startXpos && allEnemies[i].activeSelf)
                    {
                        posibleEnemies.Add(allEnemies[i]);
                    }
                }
            }
            else if (startYPos < 0)
            {
                for (int i = 0; i < allEnemies.Length; i++)
                {
                    if (allEnemies[i].transform.position.y < 0 && allEnemies[i].transform.position.x > startXpos && allEnemies[i].activeSelf)
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
                if(currentEnemy != null)
                {
                    float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                    if (distanceToEnemy < distanceToClosestEnemy)
                    {
                        distanceToClosestEnemy = distanceToEnemy;
                        ClosestEnemy = currentEnemy;
                    }
                }
                else
                {
                    return null;
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


    void Deactivate()
    {
        target = null;
        gameObject.SetActive(false);
    }
}
