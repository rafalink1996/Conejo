using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEyeLaser : MonoBehaviour
{

    private Animator animator;
    private BoxCollider2D LaserCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Laser());
        LaserCollider = gameObject.GetComponent<BoxCollider2D>();
        LaserCollider.enabled = false;

    }

  IEnumerator Laser()
    {
       yield return new WaitForSeconds(0.5f);
        LaserCollider.enabled = true;

        yield return new WaitForSeconds(2.5f);
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }
}
