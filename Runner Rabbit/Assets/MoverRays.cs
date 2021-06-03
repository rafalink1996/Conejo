using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRays : MonoBehaviour
{

    [SerializeField] Animator myAnimator;
    [SerializeField] float StartTime;

    [SerializeField] RayEnemy RayUp;
    [SerializeField] RayEnemy RayDown;


    // Start is called before the first frame update

    void Start()
    {
        Invoke("MoveToPosition", StartTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.spawnHouse)
        {
            myAnimator.SetTrigger("End");
        }
    }

    void MoveToPosition()
    {
        myAnimator.SetTrigger("In");
    }

    void StartRays()
    {
        RayUp.StartRayLoop();
        RayDown.StartRayLoop();
    }
}
