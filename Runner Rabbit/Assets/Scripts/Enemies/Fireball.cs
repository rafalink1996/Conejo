using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    Animator fireballAnimator;
    // Start is called before the first frame update
    void Start()
    {
        fireballAnimator = GetComponent<Animator>();
        Destroy(gameObject, 4f);
      
       // transform.position = GameObject.Find("Enemy Spawner").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            fireballAnimator.SetTrigger("hit");
            FindObjectOfType<AudioManager>().Play("FireExplotion");
            
            speed = -3f;


        }

    }

    public void HitEnd ()
    {
        
        Destroy(gameObject);
    }
    
    
      
    
}
