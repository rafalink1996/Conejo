using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerChangeAnimation : MonoBehaviour
{

    private character Cha;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.RiftColition == true)
        {
            animator.SetBool("PowerChange", true);

        }
        else
        {
            animator.SetBool("PowerChange", false);
        }


       

    }
    
   
}
