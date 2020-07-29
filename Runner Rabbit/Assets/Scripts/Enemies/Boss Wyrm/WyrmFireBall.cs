using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmFireBall : MonoBehaviour
{

    Transform target;
    float angle;
    float speed = -23;
    // Start is called before the first frame update
    void Start()
    {
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
            print("kick");
            transform.rotation = Quaternion.AngleAxis(Random.Range(150, 250), Vector3.forward);
            //speed = 0;

        }
    }
}
