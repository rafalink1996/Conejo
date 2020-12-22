using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinIdle : StateMachineBehaviour
{
    float timeToAttack;
    public int attackType;
    bool isAttacking;
    character Cha;
    BossGriffin griffin;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        griffin = FindObjectOfType<BossGriffin>();
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        isAttacking = false;
        attackType = Random.Range(1, 101);
        timeToAttack = Random.Range(0.4f, 2f);
        if (griffin.bossTop != Cha.top && animator.GetBool("hasAttackedOnce") == true)
        {
            animator.SetTrigger("Despawn");
 
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
            isAttacking = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
