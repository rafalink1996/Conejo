using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour, IPooledObject
{
    Transform Bunnytarget;
    Transform target;
    public Transform sourceTransform;
    float speed = 6f;
    float rotateSpeed = 100f;
    Rigidbody2D rb;
    Animator anim;
    bool reflected;
    [SerializeField] CircleCollider2D myCircleCollider2D;
    bool ObjectHit = false;
    AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Bunnytarget = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        //myCircleCollider2D = GetComponent<CircleCollider2D>();
        //rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindWithTag("Player").transform;
        //anim = GetComponent<Animator>();
    }

    public void OnObjectSpawn()
    {
        myAudioSource.Play();
        target = Bunnytarget;
        reflected = false;
        ObjectHit = false;
        myCircleCollider2D.enabled = true;
        transform.position = transform.parent.transform.position;
        transform.rotation = transform.parent.transform.rotation;
    }


    void Update()
    {
        if (target != null && !reflected)
        {
            if (transform.position.x > target.transform.position.x)
            {
                Vector2 direction = (Vector2)target.position - rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.right).z;
                rb.angularVelocity = rotateAmount * rotateSpeed;
                rb.velocity = transform.right * -speed;

            }
        }
        else if (reflected)
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Kick")
        {
            //print("reflected");
            reflected = true;
            rb.angularVelocity = 0;
            rb.velocity = Vector3.zero;
            if (collision.GetComponent<Kick>().reflect == false)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward);
            }
            else
            {
                if(sourceTransform != null)
                {
                    target = sourceTransform;
                }
                
                Vector3 dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }


        }
        if (collision.tag == "Enemy" && reflected && !ObjectHit)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            Hit();
            ObjectHit = true;
            
        }
        if ((collision.tag == "Player" || collision.tag == "Rift") && !ObjectHit)
        {
            Hit();
            ObjectHit = true;
            //FindObjectOfType<AudioManager>().Play("FireExplotion");
        }

    }
    public void Hit()
    {
        Debug.Log("electriic ball hit");
        anim.SetTrigger("Hit");
        
        myCircleCollider2D.enabled = false;
    }
    public void Destroyed()
    {
        transform.parent.gameObject.SetActive(false);
        // Destroy(transform.parent.gameObject);
    }
}
