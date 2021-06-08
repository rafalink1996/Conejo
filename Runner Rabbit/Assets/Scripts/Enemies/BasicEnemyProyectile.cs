using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemyProyectile : MonoBehaviour, IPooledObject
{

    public float speed = 20f;
    bool reflected;
    public bool piercing = false;

    Transform myParent;
    [SerializeField] bool hasParent;


    void Start()
    {
        if (hasParent)
        {
            myParent = transform.parent;
        }
        //Destroy(transform.parent.gameObject, 7f);
    }

    public void OnObjectSpawn()
    {
        if (myParent != null)
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.rotation = myParent.rotation;

        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }

        Invoke("Deactivate", 3);
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
            if (collision.GetComponent<Kick>().reflect == false)
            {
                transform.rotation = Quaternion.AngleAxis(Random.Range(120, 240), Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            }
        }
        if (collision.tag == "Enemy" && reflected)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            // Destroy(transform.parent.gameObject);
            if (myParent != null)
            {
                myParent.gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        if (collision.tag == "Player")
        {
            if (!piercing)
            {
                //Destroy(transform.parent.gameObject);
                if (myParent != null)
                {
                    myParent.gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }    
        }
    }

    void Deactivate()
    {
        if (myParent != null)
        {
            myParent.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }



}