using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHandRandom : MonoBehaviour
{

    public float speed;
    private Animator animator;

    public float minPosY;
    public float maxPosY;

    public float TimeBetweenAttacksMax;
    public float TimeBetweenAttacksMin;


    public float YPos;

    public EnemyHealth BlueMageHealth;
    public float AttackSelfDamage;

    SpriteRenderer HandSpriteR;


    [SerializeField] string missleTag = "MageMissle";
    ObjectPooler myObjectPooler;



    // Start is called before the first frame update
    void Start()
    {
        HandSpriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        YPos = Random.Range(minPosY, maxPosY);
        StartCoroutine(Attack());

        myObjectPooler = ObjectPooler.Instance;
        missleTag = "MageMissle";
        //AttackSelfDamage = 1;



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
            yield return new WaitForSeconds(Random.Range(TimeBetweenAttacksMin, TimeBetweenAttacksMax));
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            GameObject ShootMissle = myObjectPooler.SpwanFromPool(missleTag, transform.position, Quaternion.identity);
            MageMissle myMageMissle = ShootMissle.GetComponent<MageMissle>();
            if (myMageMissle != null && BlueMageHealth.gameObject.transform != null)
            {
                myMageMissle.sourceTransform = BlueMageHealth.gameObject.transform;
            }

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

