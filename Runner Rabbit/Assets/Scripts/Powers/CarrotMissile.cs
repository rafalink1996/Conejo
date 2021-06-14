using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMissile : MonoBehaviour, IPooledObject
{
    public float speed;
    public bool Piercing;
    public float damage;

    ObjectPooler myObjectPooler;
    string ColParticlesTag = "CollisionParticles";
    // Start is called before the first frame update

    private void Awake()
    {
        myObjectPooler = ObjectPooler.Instance;
        ColParticlesTag = "CollisionParticles";
    }
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        ColParticlesTag = "CollisionParticles";
        //Destroy(gameObject, 5f);
    }
    public void OnObjectSpawn()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            EnemyHealth CollisionEnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            CollisionEnemyHealth.TakeDamage(damage);
            CollisionEnemyHealth.Hit = true;

            //print("hit " + collision.gameObject.name);
            if (myObjectPooler != null)
            {
                myObjectPooler.SpawnFromPool(ColParticlesTag, transform.position, Quaternion.identity);
                Debug.Log("should Spawn Particles");
            }
            else
            {
                Debug.Log("no objectPooler");
            }
            if (Piercing == false)
            {
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            collision.gameObject.GetComponent<EnemyHealth>().Hit = true;
            //print("hit " + collision.gameObject.name);
            if (myObjectPooler != null)
            {
                myObjectPooler.SpawnFromPool(ColParticlesTag, transform.position, Quaternion.identity);
                Debug.Log("should Spawn Particles");
            }
            else
            {
                Debug.Log("no objectPooler");
            }
            if (Piercing == false)
            {
                gameObject.SetActive(false);
               // Destroy(gameObject);
            }

        }
    }
}
