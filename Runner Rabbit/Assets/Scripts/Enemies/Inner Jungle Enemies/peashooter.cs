using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashooter : MonoBehaviour, IPooledObject
{
    Transform BunnyTarget;
    [SerializeField] Transform target;
    Collider2D myCollider2D;
    Animator myAnimator;
    bool reflected;
    float angle;
    public Transform sourceTransform;

    float deactivateTime;
    float maxDeactivateTime = 4f;
    // Start is called before the first frame update
    private void Awake()
    {
        BunnyTarget = GameObject.FindWithTag("Player").transform;
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        maxDeactivateTime = 4f;

        BunnyTarget = GameObject.FindWithTag("Player").transform;
        myCollider2D = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();




        //sourceTransform = transform.parent.transform;
        //Destroy(transform.parent.gameObject, 4f);

    }

    public void OnObjectSpawn()
    {
        target = BunnyTarget;
        myAnimator.Play("seed idle");
        reflected = false;
        deactivateTime = maxDeactivateTime;
        transform.position = transform.parent.gameObject.transform.position;
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        Vector3 dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(deactivateTime < 0)
        {
            DestroyPoison();
        }
        else
        {
            deactivateTime -= Time.deltaTime;
        }
        transform.Translate(-13 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rift" || collision.tag == "Player")
        {
            
            myAnimator.SetTrigger("Destroy");
            myCollider2D.enabled = false;

        }
        if (collision.name == "Kick")
        {
            reflected = true;
            //print("kick");
            if (collision.GetComponent<Kick>().reflect == false)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(120, 240), Vector3.forward);
            }
            else
            {
                target = sourceTransform;
                Vector3 dir = target.position - transform.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            }
        }

        if (collision.tag == "Enemy" && reflected)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            myAnimator.SetTrigger("Destroy");
            //Destroy(transform.parent.gameObject);
        }
    }

    private void DestroyPoison()
    {
        transform.parent.gameObject.SetActive(false);
       // Destroy(transform.parent.gameObject);
    }
}
