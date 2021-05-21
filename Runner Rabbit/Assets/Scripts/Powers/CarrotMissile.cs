using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMissile : MonoBehaviour
{
    public float speed;
    public bool Piercing;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            EnemyHealth CollisionEnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            CollisionEnemyHealth.TakeDamage(damage);
            CollisionEnemyHealth.Hit = true;
            
            print("hit " + collision.gameObject.name);

            if (Piercing == false)
            {
                Destroy(gameObject);
            } 
               
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            print("hit " + collision.gameObject.name);
            if (Piercing == false)
            {
                Destroy(gameObject);
            }

        }
    }
}
