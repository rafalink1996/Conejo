using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHandRandom : MonoBehaviour
{

    public float speed;
    private Animator animator;

    public float minPosY;
    public float maxPosY;

    public float TimeBetweenAttacks;

    public float YPos;

    public EnemyHealth BlueMageHealth;
    public int AttackSelfDamage;

    SpriteRenderer HandSpriteR;
 
    



    // Start is called before the first frame update
    void Start()
    {
        HandSpriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        YPos = Random.Range(minPosY, maxPosY);
        StartCoroutine(Attack());
        AttackSelfDamage = 3;
        


    }

    // Update is called once per frame
    void Update()
    {

        
        if (Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(YPos))
        {
            RandomizePos();
        }
        else

        {
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, YPos, transform.position.z), speed * Time.deltaTime);
        }
        
    }


    public void RandomizePos()
    {
        
        YPos = Random.Range(minPosY, maxPosY);
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenAttacks);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageMissle") as GameObject);
            MageMissle.transform.position = transform.position;
            Destroy(MageMissle, 2f);
            BlueMageHealth.TakeDamage(AttackSelfDamage);
            
        }

    }

    public void ActivateRenderer()
    {
        if (HandSpriteR.enabled == false)
        {
            HandSpriteR.enabled = true;
        }
        else
        {
            HandSpriteR.enabled = false;
        }
        
    }

  

    



}

