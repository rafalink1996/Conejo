using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockworkBomb : MonoBehaviour
{

    
    public float timeToExplode;
    public float speed = 5f;
    public Collider2D Col;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplodeTimer());
        Col.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(timeToExplode);
        Col.enabled = true;
        animator.SetTrigger("Explode!");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }
}
