using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeal : MonoBehaviour
{

    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.tag == "Player")
        {
            Destroy(gameObject);
           // FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}
