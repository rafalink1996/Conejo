using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinBallProyectiles : MonoBehaviour
{
    public Transform target;
    Collider2D myCollider2D;
    bool reflected;
    float angle;
    public Transform sourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        sourceTransform = FindObjectOfType<BossGriffin>().gameObject.transform;
        target = GameObject.FindWithTag("Player").transform;
        //transform.LookAt(target, Vector3.up);
        Vector3 dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        myCollider2D = GetComponent<Collider2D>();
        Destroy(transform.parent.gameObject, 4f);

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-13 * Time.deltaTime, 0, 0);
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
                target = sourceTransform;
                Vector3 dir = target.position - transform.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
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
