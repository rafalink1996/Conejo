using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMageHand : MonoBehaviour
{
    SpriteRenderer HandSpriteR;
    private Animator animator;
    ShadowHandPortal Portal;
    // Start is called before the first frame update
    void Start()
    {
        HandSpriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Portal = GetComponentInChildren<ShadowHandPortal>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        GameObject MageShadowMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageShadowMissle") as GameObject);
        MageShadowMissle.transform.position = transform.position;
        MageShadowMissle.transform.rotation = transform.rotation;
        Destroy(MageShadowMissle, 2f);


    }

    public void ActivateRenderer()
    {
        if (HandSpriteR.enabled == false)
        {
            HandSpriteR.enabled = true;
        }
        else
        {
            HandSpriteR.enabled = false;
        }
    }

    public void StartAttacking()
    {
        StartCoroutine(Attack());
    }

    public void StartDespawning()
    {
        StartCoroutine(DespawnShadowHand());
    }

    IEnumerator DespawnShadowHand()
    {
        Portal.ActivatePortal();
        yield return new WaitForSeconds(2);
        
        Destroy(gameObject);

    }
}
