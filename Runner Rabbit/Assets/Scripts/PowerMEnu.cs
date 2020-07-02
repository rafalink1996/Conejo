using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMEnu : MonoBehaviour
{
    public Animator powerbuttontransition;
    
        

    public GameObject mainmenu;
    public GameObject powermenu;
    public GameObject TowerDark;
    public GameObject TowerLight;


    public float transitionTimein;
    public float transitionTimeout;



    public void PowerMenu ()
    {
        powerbuttontransition.SetTrigger("Powers");
       

        StartCoroutine(GoToPowersMenu());
    }

    public void PowerMenuBack()
    {
        powerbuttontransition.SetTrigger("Powers Out");
      

        StartCoroutine(backfromPowersMenu());
    }

    IEnumerator GoToPowersMenu ()
    {

        yield return new WaitForSeconds(transitionTimein);

        powermenu.SetActive(true);
        TowerDark.SetActive(false);
        TowerDark.SetActive(false);
        
        Debug.Log("powermenu!");

        yield return null;
    }

    IEnumerator backfromPowersMenu()
    {
        
        yield return new WaitForSeconds(transitionTimeout);

        mainmenu.SetActive(true);
        TowerDark.SetActive(true);
        TowerDark.SetActive(true);

        yield return null;
    }
}
