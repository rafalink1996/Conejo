using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFlipDark : MonoBehaviour
{

    private character Cha;
    public Animator animator;


    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            
        }
        if (Cha.top == false)
        {
            animator.SetBool("Character Up", true);

        }
    }


    public void SpawnLightPower()
    {
        GameObject Lightpower = GameObject.Instantiate(Resources.Load("Prefabs/Power Light") as GameObject);
      Lightpower.transform.SetParent(GameObject.FindGameObjectWithTag("UIpower").transform, false);
    }
    public void CharacterUp()
    {

        Destroy(gameObject);
    }
}
