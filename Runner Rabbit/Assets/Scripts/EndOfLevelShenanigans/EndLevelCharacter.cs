using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndLevelCharacter : MonoBehaviour
{

    [SerializeField]
    public Transform endMarker1;
    [SerializeField]
    public Transform endMarker2;
    [SerializeField]
    [Range(0f, 1f)]
    private float lerpPct = 0f;

    private Vector3 Currentpos;
    private int positionfailsafe;

    private bool IsLerping;
    public float Acceleration;
    public float speed;

    public Animator animator;
    public character cha;
    public LevelLoader levelLoader;

    

    private StartLevelCharacter levelecaracterscript;

    private void Start()
    {
     
    }



    // Update is called once per frame
    void Update()
    {


        Vector3 temp = Currentpos;
        temp.x += 10 * Time.deltaTime;
         Currentpos = temp;



       


        if (cha.EndLevel == true)


            

        {

            cha.upspeed = 0;
            cha.GetComponent<Rigidbody2D>().gravityScale = 0;

            positionfailsafe++;
            if (positionfailsafe == 2)
            {
                PlayerPosSave();
            }
            
            animator.SetTrigger("IsPulled");
            StartCoroutine(WaitForintro());
        }
           


        if (IsLerping == true)
        {

          


            if (lerpPct < 1)

            {
               // Destroy(cha.GetComponent<Rigidbody2D>());
                
                lerpPct += speed * Acceleration * Time.unscaledDeltaTime;

                
                if (cha.top)
                {

                    transform.position = Vector3.Lerp(Currentpos, endMarker2.position, lerpPct);
                }
                else
                {
                    transform.position = Vector3.Lerp(Currentpos, endMarker1.position, lerpPct);
                }
               
                
            }

            if (lerpPct == 1 )
            {
                
                IsLerping = false;
                StartCoroutine(startloading());

           
                

            }

            if (lerpPct > 1)
            {
                lerpPct = 1;
            }

        }



    }

    IEnumerator WaitForintro()
    {
        

        yield return new WaitForSecondsRealtime(0.01f);

        cha.EndLevel = false;

        IsLerping = true;
        
        animator.SetBool("IsPulled", false);



    }

    IEnumerator startloading()
    {
       
        yield return new WaitForSecondsRealtime(0f);
        levelLoader.changelevel();
        animator.SetTrigger("HouseHit");
        FindObjectOfType<AudioManager>().Play("TransitionSound");
        //animator.SetBool("IsPulled", false);
   
    }


    public void PlayerPosSave ()
    {
        Debug.Log("guardada posicion");
        Currentpos = transform.position;
    }



}
