using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        //transform.LookAt(target, Vector3.up);
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        Destroy(transform.parent.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-13 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rift")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
