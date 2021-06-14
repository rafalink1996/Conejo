using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IPooledObject
{
    public float speed = 20f;
    public Animator fireballAnimator;
    AudioSource myAudioSource;

    bool reflected;
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        fireballAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        fireballAnimator = GetComponent<Animator>();
    }
    public void OnObjectSpawn()
    {
        myAudioSource.Play();
        reflected = false;
        speed = 20;
        if(fireballAnimator == null)
        {
            fireballAnimator = GetComponent<Animator>();
        }
        transform.position = transform.parent.transform.position + new Vector3(-0.99f, 0.21f, 0);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        fireballAnimator.Play("Fireball");
    }


    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Kick")
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
       transform.parent.gameObject.SetActive(false);
        //Destroy(transform.parent.gameObject);
    }
    
    
      
    
}
