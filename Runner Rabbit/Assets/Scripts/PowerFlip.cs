using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFlip : MonoBehaviour
{
    // Start is called before the first frame update

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
            animator.SetBool("Character Down", true);
        }
        if (Cha.top == false)
        {
           
            
        }
    }


    public void SpawnDarkPower()
    {
        GameObject DarkPower = GameObject.Instantiate(Resources.Load("Prefabs/Power Dark") as GameObject);
        DarkPower.transform.SetParent(GameObject.FindGameObjectWithTag("UIpower").transform, false);
    }
    public void CharacterDown()
    {
        
        Destroy(gameObject);
    }
}
