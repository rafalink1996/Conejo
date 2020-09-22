using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageGoblin : MonoBehaviour
{
    float attackTime;
    float invokeTime;
    bool attack;
    bool invoke;
    Animator anim;
    public GameObject troll1Object;
    public GameObject troll2Object;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 4f);
        invokeTime = Random.Range(8f, 15f);

    }

    // Update is called once per frame
    void Update()
    {
        if (troll1Object == null || troll2Object == null)
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
                attack = true;
            }
        }
    }
    void Attack()
    {
        GameObject fireball = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
        fireball.GetComponentInChildren<WyrmFireBall>().sourceTransform = gameObject.transform;
        fireball.transform.position = transform.position + new Vector3(-5.5f, -0.1f, 0);
        attackTime = Random.Range(3f, 5f);
        attack = false;
    }
    void Invoke()
    {
        if (troll1Object == null)
        {
            GameObject troll1 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll1Object = troll1;
            troll1.transform.position = new Vector3(transform.position.x - 6.2f, 4.31f, 0);
        }
        if (troll2Object == null)
        {
            GameObject troll2 = Instantiate(Resources.Load("Prefabs/TrollGoblin") as GameObject);
            troll2Object = troll2;
            troll2.transform.position = new Vector3(transform.position.x - 6.2f, -4.31f, 0);
        }
        attackTime = Random.Range(3f, 5f);
        attack = false;
        invokeTime = Random.Range(8f, 15f);
        invoke = false;
    }
}
