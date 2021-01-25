using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIdle : StateMachineBehaviour
{
    float timeToAttack;
    public int attackType;
    bool isAttacking;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isAttacking = false;
        attackType = Random.Range(1, 101);
        timeToAttack = Random.Range(0.4f, 2f);
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
            if (attackType >= 1 && attackType <= 32)
            {
                animator.SetTrigger("Attack1");
            }
            if (attackType >= 33 && attackType <= 65)
            {
                animator.SetTrigger("Attack2");
            }
            if (attackType >= 66 && attackType <= 100)
            {
                animator.SetTrigger("Attack3");
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
