using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageGoblin : MonoBehaviour
{
    public EnemyHealth health;
    public int myHealth;
   [SerializeField] float attackTime;
    float invokeTime;
   [SerializeField] bool attack;
   [SerializeField] bool invoke;
    Animator anim;
    GameObject troll1Object;
    GameObject troll2Object;
    trollGoblin troll1Cs;
    trollGoblin troll2Cs;
    public bool bossTop;
    public GameObject[] healthBar;
    bool isInvoking;

    [SerializeField] ObjectPooler myObjectPooler;
    string FireballTag = "GoblinFireBall";
    string TrollGoblinTag = "TrollGoblin";
    // Start is called before the first frame update
    void Start()
    {
        isInvoking = false;
        myObjectPooler = ObjectPooler.Instance;
        health = GetComponent<EnemyHealth>();
        health.maxHealth = myHealth;
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 4f);
        invokeTime = Random.Range(8f, 15f);
        GameStats.stats.bossDead = false;

        if (troll1Object == null)
        {
            GameObject troll1 = myObjectPooler.SpawnFromPool(TrollGoblinTag, transform.position, Quaternion.identity);
            troll1.SetActive(false);
            //    GameObject troll1 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll1Object = troll1;
            troll1.transform.position = new Vector3(transform.position.x - 6.2f, 4.31f, 0);
            troll1Cs = troll1Object.GetComponentInChildren<trollGoblin>();
            troll1Cs.TrollId = 1;

        }
        if (troll2Object == null)
        {
            GameObject troll2 = myObjectPooler.SpawnFromPool(TrollGoblinTag, transform.position, Quaternion.identity);
            troll2.SetActive(false);
            //    GameObject troll2 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll2Object = troll2;
            troll2.transform.position = new Vector3(transform.position.x - 6.2f, 3, 0);//y = -7.66f
            troll2.transform.localScale = new Vector3(1, -1);
            troll2Cs = troll2Object.GetComponentInChildren<trollGoblin>();
            troll2Cs.TrollId = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!troll1Cs.Alive && !troll2Cs.Alive)
        {

            invokeTime -= Time.deltaTime;
        }
        if (invokeTime <= 0)
        {
            invoke = true;
        }

        attackTime -= Time.deltaTime;
        if (attackTime <= 0 && !attack)
        {
            if (!invoke)
            {
                anim.SetTrigger("Attack");
                attack = true;
            }
            else
            {
                anim.SetTrigger("Invoke");
                Invoke();
                attack = true;
            }
        }
        if (health.health <= 0)
        {
            anim.SetTrigger("Die");
            GameStats.stats.bossDead = true;
        }
        if (transform.parent.transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
    }
    void Attack()
    {
        //GameObject fireball = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
        GameObject fireball = myObjectPooler.SpawnFromPool(FireballTag, transform.position, Quaternion.identity, true);
        fireball.GetComponentInChildren<WyrmFireBall>().sourceTransform = gameObject.transform;
        fireball.transform.position = transform.position + new Vector3(-1.965444f, -0.1070113f, 0);
        attackTime = Random.Range(3f, 5f);
        attack = false;
        anim.SetBool("hasAttackedOnce", true);
        health.TakeDamage(5);
    }

    IEnumerator InvokeTime()
    {
        yield return new WaitForSeconds(0.5f);
        if (troll1Object.activeSelf == false && troll1Cs.Alive == false)
        {
            troll1Object.SetActive(true);
            troll1Object.transform.position = new Vector3(transform.position.x - 6.2f, 4.31f, 0);
            IPooledObject pooledObj = troll1Object.GetComponentInChildren<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }
            else
            {
                Debug.Log("troll Goblin IPooledObject not found");
            }
        }
        if (troll2Object.activeSelf == false && troll2Cs.Alive == false)
        {
            troll2Object.SetActive(true);
            troll2Object.transform.position = new Vector3(transform.position.x - 6.2f, -4, 0); //y = -7.66f
            IPooledObject pooledObj = troll2Object.GetComponentInChildren<IPooledObject>();
            if (pooledObj != null)
            {
                pooledObj.OnObjectSpawn();
            }
            else
            {
                Debug.Log("troll Goblin IPooledObject not found");
            }

        }
        attack = false;
        health.TakeDamage(10);



    }
    void Invoke()
    {

        attackTime = Random.Range(3f, 5f);
        attack = false;
        invokeTime = Random.Range(8f, 15f);
        invoke = false;
        StartCoroutine(InvokeTime());
       
        //anim.SetBool("hasAttackedOnce", true);
    }
    void DeactivateCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        healthBar[0].SetActive(false);
        healthBar[1].SetActive(false);
        healthBar[2].SetActive(false);
    }
    void ActivateCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        healthBar[0].SetActive(true);
        healthBar[1].SetActive(true);
        healthBar[2].SetActive(true);
    }
}
