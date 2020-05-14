using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmIdle : StateMachineBehaviour
{
    BossWyrm wyrm;
    float timeToAttack;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wyrm = FindObjectOfType<BossWyrm>();
        wyrm.attacks[0].SetActive(false);//TODO. This is temporary. Only for testing. TODO
        wyrm.attacks[1].SetActive(false);
        wyrm.attacks[2].SetActive(false);
        wyrm.attacks[3].SetActive(false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*if (wyrm.currentElement == 1)
        {
            timeToAttack -= Time.deltaTime;
        }*/
        if (Input.GetKeyDown(KeyCode.U)) //for testing
        {
            animator.SetTrigger("Despawn"); //this will trigger the portal change

        }
        if (Input.GetKeyDown(KeyCode.I))//for testing
        {
            if (wyrm.element == 1)
            {
                animator.SetTrigger("Shoot");
            }
            if (wyrm.element == 2)
            {
                animator.SetTrigger("Rift");
            }
            if (wyrm.element == 3)
            {
                animator.SetTrigger("Shoot");
            }
        }
        if (Input.GetKeyDown(KeyCode.O))//for testing
        {
            if (wyrm.element == 1)
            {
                animator.SetTrigger("Ray");
            }
            if (wyrm.element == 2)
            {
                animator.SetTrigger("Ray");
            }
            if (wyrm.element == 3)
            {
                animator.SetTrigger("Rift");
            }
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
