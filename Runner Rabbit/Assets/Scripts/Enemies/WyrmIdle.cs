using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmIdle : StateMachineBehaviour
{
    BossWyrm wyrm;
    float timeToAttack;
    public int attackType;
    bool isAttacking;
    character Cha;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wyrm = FindObjectOfType<BossWyrm>();
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        isAttacking = false;
        attackType = Random.Range(1, 101);
        timeToAttack = Random.Range(0.4f, 2f);
        if (wyrm.bossTop != Cha.top && animator.GetBool("hasAttackedOnce") == true)
        {
            animator.SetTrigger("Despawn");
            wyrm.isChanging = true;
        }
        if (wyrm.timeToChange <= 0)
        {
            animator.SetTrigger("Despawn");
            wyrm.isChanging = true;
        }
        if (wyrm.isChanging)
        {
            wyrm.isChanging = false;
            wyrm.timeToChange = Random.Range(15f, 25f);
        }
        if (wyrm.element == 2)
        {
            timeToAttack = 0.1f;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isAttacking)
        {
            timeToAttack -= Time.deltaTime;
        }
        if (timeToAttack <= 0 && !isAttacking)
        {
            if (wyrm.element == 1)
            {
                if (attackType >= 1 && attackType <= 79)
                {
                    animator.SetTrigger("Shoot");
                }
                if (attackType >= 80 && attackType <= 100)
                {
                    animator.SetTrigger("Ray");
                }
            }
            if (wyrm.element == 2)
            {
                if (animator.GetBool("Ice") == false)
                {
                    animator.SetTrigger("Rift");
                    
                }
                if (animator.GetBool("Ice") == true)
                {
                    animator.SetTrigger("Ray");
                }
            }
            if (wyrm.element == 3)
            {
                if (attackType >= 1 && attackType <= 49)
                {
                    animator.SetTrigger("Shoot");
                }
                if (attackType >= 50 && attackType <= 100)
                {
                    if (animator.GetBool("Thunder") == false)
                    {
                        animator.SetTrigger("Rift");
                        animator.SetBool("Thunder", true);
                    }
                    else
                    {
                        animator.SetTrigger("Shoot");
                    }
                }
            }

            isAttacking = true;
        }

        
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
