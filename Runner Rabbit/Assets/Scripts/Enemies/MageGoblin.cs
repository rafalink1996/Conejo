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
    public GameObject troll1;
    public GameObject troll2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTime = Random.Range(3f, 8f);
        invokeTime = Random.Range(8f, 15f);

    }

    // Update is called once per frame
    void Update()
    {
        if (troll1 == null || troll2 == null)
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
            }
        }
    }
    void Attack()
    {
        GameObject fireball = Instantiate(Resources.Load("Prefabs/WyrmFireBall") as GameObject);
        fireball.GetComponentInChildren<WyrmFireBall>().sourceTransform = gameObject.transform;
        fireball.transform.position = transform.position + new Vector3(-5.5f, -0.1f, 0);
        attackTime = Random.Range(3f, 8f);
        attack = false;
    }
    void Invoke()
    {
        invoke = false;
    }
}
