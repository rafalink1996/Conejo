using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    public float speed = 10f;
    bool reflected;
    public Transform sourceTransform;
    // Start is called before the first frame update
    void Start()
    {

        sourceTransform = transform.parent.transform;
        Destroy(transform.parent.gameObject, 4f);

        // transform.position = GameObject.Find("Enemy Spawner").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        /*Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;*/
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
            Destroy(transform.parent.gameObject);
        }


    }

}