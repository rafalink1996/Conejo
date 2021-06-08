using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyratoryPlant : MonoBehaviour, IPooledObject
{
    public float speed = 3f;
    [SerializeField] EnemyHealth myEnemyHealth;
    [SerializeField] Animator myAnimator;
    [SerializeField] BoxCollider2D myBoxCollider2D;
    public float shineTime;

    float deactivateTime;
    float MaxDeactivateTime = 4;


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myEnemyHealth = GetComponent<EnemyHealth>();
        MaxDeactivateTime = 4;
    }
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myEnemyHealth = GetComponent<EnemyHealth>();
        MaxDeactivateTime = 4;
        //Destroy(gameObject, 4f);

    }

    public void OnObjectSpawn()
    {
        deactivateTime = MaxDeactivateTime;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
        if (myEnemyHealth != null)
        {
            if (myEnemyHealth.health <= 0)
            {
                if (myAnimator != null)
                {
                    myAnimator.SetTrigger("Die");
                }

                if (myBoxCollider2D != null)
                {
                    myBoxCollider2D.enabled = false;
                }
            }
        }

        DeactivateTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void DeactivateTime()
    {
        if(deactivateTime < 0)
        {
            Shine();
        }
        else
        {
            deactivateTime -= Time.deltaTime;
        }
    }


    public void SFXPLantBite()
    {
        FindObjectOfType<AudioManager>().Play("Plant Bite");
    }

    void Shine()
    {

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}


