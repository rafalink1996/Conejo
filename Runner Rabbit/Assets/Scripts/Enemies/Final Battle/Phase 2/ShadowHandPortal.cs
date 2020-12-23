using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHandPortal : MonoBehaviour
{

    Animator PortalAnimator;
    ShadowMageHand ShadowHand;
    // Start is called before the first frame update
    void Start()
    {
        PortalAnimator = GetComponent<Animator>();
        FindObjectOfType<AudioManager>().Play("MageHandPortal");
        PortalAnimator.SetTrigger("Spawn");
        ShadowHand = GetComponentInParent<ShadowMageHand>();
    }

    public void SpawnDespawnHandTime()
    {
        ShadowHand.ActivateRenderer();
    }

    public void ActivatePortal()
    {
        PortalAnimator.SetTrigger("Spawn");
    }

}
