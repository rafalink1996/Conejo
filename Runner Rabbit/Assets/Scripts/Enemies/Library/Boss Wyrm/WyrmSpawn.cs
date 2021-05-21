using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmSpawn : StateMachineBehaviour
{
    character Cha;
    BossWyrm wyrm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        wyrm = FindObjectOfType<BossWyrm>();
        if (Cha.top && !wyrm.bossTop)
        {
            wyrm.transform.parent.transform.localEulerAngles = new Vector3(180, 0, 0);
            wyrm.transform.parent.transform.position = new Vector3(wyrm.transform.parent.transform.position.x, -5.16f /*-4.340454f*/, wyrm.transform.parent.transform.position.z);
        }
        if (!Cha.top && wyrm.bossTop)
        {
            wyrm.transform.parent.transform.localEulerAngles = new Vector3(0, 0, 0);
            wyrm.transform.parent.transform.position = new Vector3(wyrm.transform.parent.transform.position.x, 5.16f /*4.340454f*/, wyrm.transform.parent.transform.position.z);
        }
        animator.SetBool("hasAttackedOnce", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
