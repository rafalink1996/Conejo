using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolemBoulder : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndMarker;

    public bool attack;
    public bool GoBack;
    public float speed;
    public float Acceleration;

    public bool BreakBoulder;
    public bool spawnboulder;

    Animator anim;

    [SerializeField] private float lerpPct = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPos.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnboulder == true)
        {
            anim.SetTrigger("Spawn");
        }

        if (BreakBoulder == true && attack == false)
        {

            StartCoroutine(breakBoulder());
        }


        if (attack == true)
        {
            if (lerpPct < 1)
            {
                
                lerpPct += speed * Acceleration * Time.deltaTime;
                transform.position = Vector3.Lerp(StartPos.position, EndMarker.position, lerpPct);
            }
            
        }

        if (GoBack == true)
        {
           
                lerpPct -= speed * Acceleration * Time.deltaTime;
                transform.position = Vector3.Lerp(StartPos.position, EndMarker.position, lerpPct);
            

        }

        if (lerpPct <= 0)
        {
            GoBack = false;
        }

        if (lerpPct < 0)
        {
            lerpPct = 0;
        }


        if (lerpPct == 1)
        {
            attack = false;
            GoBack = true;
        }

        

        if (lerpPct > 1)
        {
            lerpPct = 1;
        }

      
    }
     IEnumerator breakBoulder ()
    {
        anim.SetTrigger("Break");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
  
}
