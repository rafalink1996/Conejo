    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{

    public Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;

    // Movement
    public float upspeed;
    private float speed = 10f;
    public Animator animator;
    public bool top;
    private bool ForceFloat;
    public bool RiftColition;
   

    // Health System
    public int Health;
    public int NumOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;




    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb.AddForce(new Vector2(0, 200));


    }

    // Update is called once per frame
    void Update()


    {
      //Health system

           // can't have more health than max hearts

           if (Health > NumOfHearts)
           {
             Health = NumOfHearts;
           }
           // number of current hearts is established

           for (int i = 0; i < hearts.Length; i++)
           {
              if (i < Health)
              {
                hearts[i].sprite = FullHeart;
              }
               else
               {
                  hearts[i].sprite = EmptyHeart;
               }

            // number of max hearts is established

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        // Jump Controller with keyboard
/*
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, upspeed));

        }

            // Animation Controller

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("IsFalling", true);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("IsFalling", false);
            }


*/

        // Animation Controller

        if (ForceFloat)
        {
            animator.SetBool("IsFalling", true);
        } else
        {
            animator.SetBool("IsFalling", false);
        }






        // Character Moves forward
        Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // colission with rift

        if (collision.tag  == "Rift")
        {
            Rotation();
            
          
            rb.gravityScale *= -1;
            upspeed *= -1;
            rb.AddForce(new Vector2(0, (upspeed * 10)));
            RiftColition = true;
           
        }

      

        // colission with enemy proyectile

        if (collision.tag == "Enemy proyectile")
        {
            Health -= 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rift")
        {
           
            RiftColition = false;

        }
    }


    void Rotation()
    {

        {
            //transform.eulerAngles = new Vector3(0, 0, 180f);


            top = !top; // toggles onoff at each click

            if (top)
            {
                
                mySpriteRenderer.flipY = true;
            }
            else
            {
               
                mySpriteRenderer.flipY = false;
            }

        }   
    }

   


    public void Missile()
    {
        animator.SetTrigger("Missile");
        GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
        carrot.transform.position = transform.position + new Vector3 (1,0,0);
    }
    public void Defence()
    {
        animator.SetTrigger("Defence");
        //GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
        //carrot.transform.position = transform.position + new Vector3(1, 0, 0);
    }

    public void Float()
    {

        rb.AddForce(new Vector2(0, upspeed));
       

       ForceFloat = true;


    }

    public void Fall()
    {
        ForceFloat = false;
    }
}
