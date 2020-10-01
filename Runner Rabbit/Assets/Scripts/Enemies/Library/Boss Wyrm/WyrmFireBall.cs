using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmFireBall : MonoBehaviour
{

    Transform target;
    public Transform sourceTransform;
    float angle;
    float speed = -23;
    bool reflected;
    // Start is called before the first frame update
    void Start()
    {
        //sourceTransform = GameObject.Find("Book Wyrm").transform;
        target = GameObject.FindWithTag("Player").transform;
        //transform.LookAt(target, Vector3.up);
        Vector3 dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        Destroy(transform.parent.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Kick")
        {
            reflected = true;
            if (collision.GetComponent<Kick>().reflect == true)
            {
                target = sourceTransform;
                Vector3 dir = target.position - transform.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(120, 240), Vector3.forward);
            }

        }
        if (collision.tag == "Enemy" && reflected)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            print("hit " + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
