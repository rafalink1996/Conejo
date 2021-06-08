using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLance : MonoBehaviour, IPooledObject
{
    public float speed = 3f;
    public bool reflected;
    public Transform sourceTransform;
    Animator myAnimator;
    [SerializeField] int ID;
    float finalPos;
    bool separate;
    float separationSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (ID == 1)
        {
            finalPos = 1.0f;
        }
        else if (ID == 2)
        {
            finalPos = -1.0f;
        }
    }

    public void OnObjectSpawn()
    {
        reflected = false;
        transform.localPosition =  new Vector3(-0.8f, 0, 0);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        separate = false;

    }


    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (separate == false)
        {
            if(ID == 1)
            {
                if (!(transform.localPosition.y >= finalPos))
                {
                    
                        transform.localPosition += new Vector3(0, separationSpeed * Time.deltaTime);
                }
                else
                {
                    separate = true;
                }
            }else if(ID == 2)
            {
                if (!(transform.localPosition.y <= finalPos))
                {

                    transform.localPosition -= new Vector3(0, separationSpeed * Time.deltaTime);
                }
                else
                {
                    separate = true;
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Kick")
        {
            reflected = true;
            print("kick");
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
            //print("hit " + collision.gameObject.name);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }

}
