using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpLeafProyectile : MonoBehaviour, IPooledObject
{
    public float speed = 10f;
    bool reflected;
    public Transform sourceTransform;

    float deactivateTime;
    float MaxDeactivateTime = 4;
    // Start is called before the first frame update
    private void Awake()
    {
        MaxDeactivateTime = 4;
    }
    void Start()
    {
        MaxDeactivateTime = 4;
        //sourceTransform = transform.parent.transform;
        //Destroy(gameObject, 4f);
    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(-speed * Time.deltaTime, 0, 0);
        /*Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;*/
        TimedDeactivate();
    }
    public void OnObjectSpawn()
    {
        reflected = false;
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        deactivateTime = MaxDeactivateTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.name == "Kick")
        {
            reflected = true;
            speed = 20;
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
            Deactivate();
            //print("hit " + collision.gameObject.name);
            //Destroy(gameObject);
        }


    }

    void TimedDeactivate()
    {
        if(deactivateTime < 0)
        {
            Deactivate();
        }
        else
        {
            deactivateTime -= Time.deltaTime;
        }

    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
