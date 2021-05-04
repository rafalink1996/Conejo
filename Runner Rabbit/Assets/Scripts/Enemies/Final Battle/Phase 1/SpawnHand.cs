using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHand : MonoBehaviour
{
    Animator PortalAnimator;
    BlueHandFollow HandFollow;
    BlueHandRandom HandRandom;

    private void Start()
    {
        PortalAnimator = GetComponent<Animator>();
        PortalAnimator.SetTrigger("Spawn");

        if (GetComponentInParent<BlueHandRandom>() != null)
        {
            HandRandom = GetComponentInParent<BlueHandRandom>();
        }

        if (GetComponentInParent<BlueHandFollow>() != null)
        {
            HandFollow = GetComponentInParent<BlueHandFollow>();
        }

    }

    public void SpawnDespawnHandTime()
    {

        if (HandRandom != null)
        {
            HandRandom.ActivateRenderer();
        }

        if (HandFollow != null)
        {
            HandFollow.ActivateRenderer();
        }
    }

    public void PortalAnimatorSetTrigger()
    {
        PortalAnimator.SetTrigger("Spawn");

    }

  
    

}
