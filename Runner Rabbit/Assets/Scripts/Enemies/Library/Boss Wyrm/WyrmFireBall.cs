using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmFireBall : MonoBehaviour, IPooledObject
{
    AudioSource myAudioSource;
    Transform bunnyTransform;
    Transform target;
    public Transform sourceTransform;
    float angle;
    float speed = -23;
    bool reflected;
    float DespawnTime = 4f;
    float MaxDespawendTime = 4;
    bool Despawned = false;
    // Start is called before the first frame update
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        bunnyTransform = GameObject.FindWithTag("Player").transform;
        
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        //sourceTransform = GameObject.Find("Book Wyrm").transform;
        bunnyTransform = GameObject.FindWithTag("Player").transform;
        // Destroy(transform.parent.gameObject, 4f);
    }


    public void OnObjectSpawn()
    {
        if(myAudioSource != null)
        {
            myAudioSource.Play();
        }
        //Debug.Log("wyrm fireball Spawned");
        target = bunnyTransform;
        transform.position = transform.parent.transform.position;
        transform.rotation = transform.parent.transform.rotation;
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        reflected = false;
        DespawnTime = MaxDespawendTime;
        Despawned = false;
        Vector3 dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }
    // Update is called once per frame
    void Update()
    {
        if (DespawnTime < 0 && !Despawned)
        {
            Despawned = true;
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            DespawnTime -= Time.deltaTime;
        }
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
            // print("hit " + collision.gameObject.name);
            // Destroy(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
