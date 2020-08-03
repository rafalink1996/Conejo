using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmThunderBall : MonoBehaviour
{
    Transform target;
    public Transform sourceTransform;
    float speed = 7f;
    float rotateSpeed = 250f;
    Rigidbody2D rb;
    Animator anim;
    bool reflected = false;
    // Start is called before the first frame update
    void Start()
    {
        sourceTransform = GameObject.Find("Book Wyrm").transform;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        Invoke("Hit", 4f);
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
        Destroy(transform.parent.gameObject);
    }
}