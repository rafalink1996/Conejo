using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMissle : MonoBehaviour, IPooledObject
{
    public float speed = 3f;
    public bool reflected;
    public Transform sourceTransform;


    public void OnObjectSpawn()
    {
        Invoke("Deactivate", 5);
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
            print("kick");
            if (collision.GetComponent<Kick>().reflect == false && sourceTransform != null)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(120, 240), Vector3.forward);
            }
            else
            {
                Vector3 dir = sourceTransform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
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

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
