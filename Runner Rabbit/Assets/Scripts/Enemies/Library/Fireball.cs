using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IPooledObject
{
    public float speed = 20f;
    public Animator fireballAnimator;
    bool reflected;
  
    void Start()
    {
        fireballAnimator = GetComponent<Animator>();
    }
    public void OnObjectSpawn()
    {
        transform.position = transform.parent.transform.position + new Vector3(-0.99f, 0.21f, 0);
    }


    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
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
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            }
        }
        if(collision.tag == "Enemy" && reflected)
        {

            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(20);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            fireballAnimator.SetTrigger("hit");
            FindObjectOfType<AudioManager>().Play("FireExplotion");

            speed = 3f;
        }
        if (collision.tag == "Player")
        {
            fireballAnimator.SetTrigger("hit");
            FindObjectOfType<AudioManager>().Play("FireExplotion");
            
            speed = 3f;
        }
       


    }
    
    public void HitEnd ()
    {
        gameObject.SetActive(false);
        //Destroy(transform.parent.gameObject);
    }
    
    
      
    
}
