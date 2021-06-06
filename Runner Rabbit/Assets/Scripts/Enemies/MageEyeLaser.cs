using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEyeLaser : MonoBehaviour
{

    private Animator animator;
    private BoxCollider2D LaserCollider;
    public bool eyeIsFiring;
    [SerializeField] MageEye myMageEye;
    
    [SerializeField] ParticleSystem LaserParticles;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        LaserCollider = gameObject.GetComponent<BoxCollider2D>();
        LaserParticles.Stop();
       

    }

    public void Attack()
    {
        StartCoroutine(Laser());
    }



  IEnumerator Laser()
    {
        
        eyeIsFiring = true;
        float RandomTime = Random.Range(2f, 4f);
        yield return new WaitForSeconds(RandomTime);
        LaserParticles.Stop();
        animator.SetTrigger("Despawn");
        yield return new WaitForSeconds(1);
        eyeIsFiring = false;
        gameObject.SetActive(false);
        //Destroy(gameObject);
        myMageEye.StartDespawn();

    }

    void PlayParticles()
    {
        LaserParticles.Play();

    }

    
}
