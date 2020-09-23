using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollGoblin : MonoBehaviour
{
    public float attackTime;
    bool attack;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = Random.Range(1.3f, 4f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attack)
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0 && !attack)
        {
            anim.SetFloat("AttackType", Random.Range(1, 3));
            anim.SetTrigger("Attack");
            attack = true;
        }
    }
    void Attack()
    {
        //instantiate thingy
        attackTime = Random.Range(1.3f, 4f);
        attack = false;
    }
}
