using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAnimator : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {

            animator.SetTrigger("Explode");

        }

    }
}
