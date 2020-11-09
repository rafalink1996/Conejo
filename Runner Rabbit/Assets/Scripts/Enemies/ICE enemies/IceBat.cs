using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBat : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndMarker;

    public float spawnTime;
    public bool spawned = false;
    public float attackTime;
    public bool attack;
    
    public bool GoBack;
    public float speed;
    public float Acceleration;
    EnemyHealth health;
    public EnemySpawner enemySpawner;
    public bool BreakBoulder;
    public bool spawnboulder;
    public bool batTop;
    Animator anim;
    public character Cha;
  

    [SerializeField] private float lerpPct = 0f;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        //transform.position = StartPos.position;
        anim = GetComponent<Animator>();
        //health.maxHealth = 30;
        if (transform.position.y > 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Up)").GetComponent<EnemySpawner>();
        }
        if (transform.position.y < 0)
        {
            enemySpawner = GameObject.Find("Enemy Spawner (Down)").GetComponent<EnemySpawner>();
        }
        spawnTime = Random.Range(0.1f, 2f);
        attackTime = Random.Range(1.2f, 3.3f);
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 && spawned == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, StartPos.position, 9f * Time.deltaTime);
            //anim.SetTrigger("Spawn");
            print("move");
        }
        if (transform.position == StartPos.position)
        {
            spawned = true;
        }
        if (!spawned)
        {
            return;
        }

        if (!attack && batTop == Cha.top && spawned)
        {
            attackTime -= Time.deltaTime;
            
        }
        if (attackTime <= 0)
        {
            anim.SetTrigger("Attack");
            attackTime = Random.Range(1.2f, 3.3f);
           
            attack = true;
        }
        if (!attack && !GoBack)
        {
            EndMarker.position = Cha.transform.position;
        }

        if (attack == true)
        {
            if (lerpPct < 1)
            {

                lerpPct += speed * Acceleration * Time.deltaTime;
                transform.position = Vector3.Lerp(StartPos.position, EndMarker.position, lerpPct);
            }

        }

        if (GoBack == true)
        {

            lerpPct -= speed * Acceleration * Time.deltaTime;
            transform.position = Vector3.Lerp(StartPos.position, EndMarker.position, lerpPct);


        }

        if (lerpPct <= 0)
        {
            GoBack = false;
        }

        if (lerpPct < 0 && spawned)
        {
            lerpPct = 0;
        }


        if (lerpPct == 1)
        {
            attack = false;
            GoBack = true;
        }



        if (lerpPct > 1)
        {
            lerpPct = 1;
        }
        if (transform.parent.transform.position.y > 0)
        {
            batTop = false;
        }
        else
        {
            batTop = true;
        }
        
    }
}
