using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartLevelCharacter : MonoBehaviour
{

    /*
    [SerializeField]
    private float start = 0;
    [SerializeField]
    private float end = 100;
    [SerializeField]
    [Range(0f,1f)]
    private float lerpPct = 0.5f;
    */


    [SerializeField]
    private Transform StartMarker;
    [SerializeField]
    private Transform endMarker;
    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPct = 0f;

    private bool IsLerping;
    public float Acceleration;
    public float speed;

    public Animator animator;

    private StartLevelCharacter levelecaracterscript;

    private void Start()
    {
        StartCoroutine(WaitForintro());

    }



    // Update is called once per frame
    void Update()
    {
        
       
        if (IsLerping == true)
        {
            if (lerpPct < 1)
            {
                animator.SetBool("start", true);
                lerpPct += speed * Acceleration * Time.unscaledDeltaTime;
                transform.position = Vector3.Lerp(StartMarker.position, endMarker.position, lerpPct);
            }

            if (lerpPct == 1)
            {
                IsLerping = false;
                animator.SetBool("start", false);
                animator.SetTrigger("Start");
                //levelecaracterscript.enabled = false;

            }

            if (lerpPct > 1)
            {
                lerpPct = 1;
            }

        }
        
    }

    IEnumerator WaitForintro ()
    {

        yield return new WaitForSecondsRealtime (1.5f);

        IsLerping = true;


    }
}
