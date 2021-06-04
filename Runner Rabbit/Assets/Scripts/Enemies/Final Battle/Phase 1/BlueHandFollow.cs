using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHandFollow : MonoBehaviour
{

    private Transform target;
    public float speed;
    private Animator animator;

    public float TimeBetweenAttacksMin;
    public float TimeBetweenAttacksMax;

    public EnemyHealth BlueMageHealth;
    public float AttackSelfDamage;
    public float offset;

    SpriteRenderer HandSpriteR;

    [SerializeField] string missleTag = "MageMissle";
    ObjectPooler myObjectPooler;


    // Start is called before the first frame update
    void Start()
    {
        HandSpriteR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Attack());

        myObjectPooler = ObjectPooler.Instance;
        missleTag = "MageMissle";
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y + offset), speed * Time.deltaTime);
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(TimeBetweenAttacksMin, TimeBetweenAttacksMax));
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f);
            //GameObject MageMissle = GameObject.Instantiate(Resources.Load("Prefabs/MageMissle") as GameObject);
            //MageMissle.transform.position = transform.position;
            //Destroy(MageMissle, 2f);

            GameObject ShootMissle = myObjectPooler.SpawnFromPool(missleTag, transform.position, Quaternion.identity, true);
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
