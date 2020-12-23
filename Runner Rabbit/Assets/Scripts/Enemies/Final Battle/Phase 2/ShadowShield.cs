using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShield : MonoBehaviour
{

    
    CircleCollider2D Col2D;
    Animator Anim;
    public bool isShielded;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MageShieldUp");
        Anim = GetComponent<Animator>();
        Col2D = GetComponent<CircleCollider2D>();
        isShielded = true;
    }

    private void Update()
    {
        if (isShielded == true)
        {
            Col2D.enabled = true;
        }
        else
        {
            Col2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FinalBossToken")
        {
            FindObjectOfType<AudioManager>().Play("MageShieldBreak");
            Anim.SetTrigger("Break");
            StartCoroutine(RestoreTime());
            isShielded = false;


        }
        if (collision.tag == "character proyectile")
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator RestoreTime()
    {
        
        yield return new WaitForSeconds(15);
        FindObjectOfType<AudioManager>().Play("MageShieldUp");
        Anim.SetTrigger("Restore");
        isShielded = true;
    }
}
