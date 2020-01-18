    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;


    public float upspeed;
    
    private float speed = 10f;

    public Animator animator;

    public bool top;


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb.AddForce(new Vector2(0, 200));


    }

    // Update is called once per frame
    void Update()


    {

      

        // Jump Controller

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



        


            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("rift entered");
        Rotation();
        rb.gravityScale *= -1;
        upspeed *= -1;
        rb.AddForce(new Vector2(0, (upspeed*10)));

    }

    void Rotation()
    {

        {
            //transform.eulerAngles = new Vector3(0, 0, 180f);


            top = !top; // toggles onoff at each click

            if (top)
            {
                print("left");
                mySpriteRenderer.flipY = true;
            }
            else
            {
                print("right");
                mySpriteRenderer.flipY = false;
            }

        }   
    }

}
