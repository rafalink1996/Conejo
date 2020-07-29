using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
   
    public bool HealthAbsorb;

    GameObject cha;
    character thecharacrter;


    // Start is called before the first frame update
    void Start()
    {
        cha = GameObject.Find("Character");
        Destroy(gameObject, 0.792f);
        thecharacrter = cha.GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cha.transform.position; 
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy proyectile")
        {
            if (HealthAbsorb == true )

            {

                thecharacrter.Health += 1;
            }

            Destroy(gameObject);

            

        }
        
    }

    

  
}
