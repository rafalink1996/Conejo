using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManaUsingToChargingAnimLight : MonoBehaviour
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
        if (SceneManager.GetActiveScene().name == "Store")
        {
            return;
        }
        if (Cha.top == true)
        {
            animator.SetBool("ManaIsUsing", true);
        }

        if (Cha.top == false)
        {
            animator.SetBool("ManaIsUsing", false);
        }
    }
}
