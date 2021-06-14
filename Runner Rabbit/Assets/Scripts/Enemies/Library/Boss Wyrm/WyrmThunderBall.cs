using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmThunderBall : MonoBehaviour, IPooledObject
{
    Transform BunnyTarget;
    Transform target;
    public Transform sourceTransform;
    float speed = 7f;
    float rotateSpeed = 250f;
    Rigidbody2D rb;
    Animator anim;
    bool reflected = false;
    [SerializeField] AudioSource myAudioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        BunnyTarget = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        //sourceTransform = GameObject.Find("Book Wyrm").transform;
        rb = GetComponent<Rigidbody2D>();
        BunnyTarget = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        //Invoke("Hit", 4f);
    }
    public void OnObjectSpawn()
    {
        myAudioSource.Play();
        target = BunnyTarget;
        transform.position = transform.parent.transform.position;
        transform.rotation = transform.parent.transform.rotation;
        reflected = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > target.transform.position.x && !reflected)
        {

            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = rotateAmount * rotateSpeed;
            rb.velocity = transform.right * -speed;
        }
        else if (reflected)
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
        }


    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.name == "Kick")
        {
            print("reflected");
            reflected = true;
            rb.angularVelocity = 0;
            rb.velocity = Vector3.zero;
            if (collision.GetComponent<Kick>().reflect == false)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward);
            }
            else
            {
                target = sourceTransform;
                Vector3 dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            

        }
        if (collision.tag == "Enemy" && reflected)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            print("hit " + collision.gameObject.name);
            Hit();
        }
        if (collision.tag == "Player")
        {
            if (!reflected)
            {
                Hit();
            }
            //FindObjectOfType<AudioManager>().Play("FireExplotion");

        }


    }
    public void Hit()
    {
        anim.SetTrigger("Hit");
    }
    public void Destroyed()
    {
        transform.parent.gameObject.SetActive(false);
        //Destroy(transform.parent.gameObject);
    }
}