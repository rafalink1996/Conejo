using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTabChange : MonoBehaviour
{

    public GameObject Upgrades;
    public GameObject Powers;
    private Animator animator;
    private bool powers = false;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void PowerTabChange()

    {
        if (powers == false)
        {
            animator.SetTrigger("DisplayChange");
            StartCoroutine(WaitForPowerChange());
            powers = true;
        }

    }

    public void upgradeTabChange()

    {

        if (powers == true)
        {
            animator.SetTrigger("DisplayChange");
            StartCoroutine(WaitForUpgradeChange());
            powers = false;
        }


    }

    IEnumerator WaitForPowerChange()
    {
        yield return new WaitForSeconds(0.6f);
        Powers.SetActive(true);
        Upgrades.SetActive(false);
    }

    IEnumerator WaitForUpgradeChange()
    {
        yield return new WaitForSeconds(0.6f);
        Powers.SetActive(false);
        Upgrades.SetActive(true);
    }

   

    
        
}

   
