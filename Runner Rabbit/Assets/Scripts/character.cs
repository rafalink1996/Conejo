﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    ManaHandle mana;


    // Coin Collecting

    private float coins = 0;
    public TextMeshProUGUI CoinCounter;





    // Health System
    public int Health;
    public int NumOfHearts;

    public GameObject[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    bool hasPassedThroughRift;






    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb.AddForce(new Vector2(0, 200));
        mana = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<ManaHandle>();





        //heartanimator = GameObject.FindGameObjectWithTag("Heart").GetComponent<Animator>();

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
                hearts[i].GetComponent<Animator>().SetBool("Full", true);
            }
            else
            {
                hearts[i].GetComponent<Animator>().SetBool("Full", false);
            }

            // number of max hearts is established

            if (i < NumOfHearts)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
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
        }
        else
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

        if (collision.tag == "Rift")
        {
            Rotation();

            upspeed *= -1;
            //dashSpeed *= -1;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, (upspeed * 19 * Time.deltaTime)));
            RiftColition = true;
            FindObjectOfType<AudioManager>().Play("RiftPass");




        }

        //collision with coins

        if (collision.tag == "Coin")
        {
            coins++;
            CoinCounter.text = coins.ToString();
        }



        // colission with enemy proyectile

        if (collision.tag == "Enemy proyectile")
        {
            Health -= 1;
            animator.SetTrigger("GotHit");
            StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(0.8f, 0.7f, 0.7f, 1f), 0.2f, 0.2f));
            StartCoroutine(GetInvulnerable());



        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rift")
        {
            rb.gravityScale *= -1;
            RiftColition = false;
            hasPassedThroughRift = true;


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
        mana.RequiredDarkMana(10f);
        if (mana.CurrentDarkMana >= mana.DarkManaUsed)
        {
            animator.SetTrigger("Missile");
            GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
            carrot.transform.position = transform.position + new Vector3(1, 0, 0);
            mana.ReduceDarkMana();
            FindObjectOfType<AudioManager>().Play("MagicMissle");
        }


    }
    public void Defence()
    {
        mana.RequiredLightMana(10f);
        if (mana.CurrentLightMana >= mana.LightManaUsed)
        {
            animator.SetTrigger("Defence");
            //GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
            //carrot.transform.position = transform.position + new Vector3(1, 0, 0);
            mana.ReduceLightMana();
            FindObjectOfType<AudioManager>().Play("MagicDefence");

        }



    }

    public void Float()
    {
        if (hasPassedThroughRift)
        {
            rb.velocity = Vector3.zero;
            hasPassedThroughRift = false;
        }
        rb.AddForce(new Vector2(0, upspeed * Time.deltaTime));


        ForceFloat = true;


    }

    public void Fall()
    {
        ForceFloat = false;
    }



    IEnumerator DamageEffectSequence(SpriteRenderer mySpriteRenderer, Color dmgColor, float duration, float delay)
    {
        // save origin color
        Color originColor = mySpriteRenderer.color;

        // tint the sprite with damage color
        mySpriteRenderer.color = dmgColor;

        // you can delay the animation
        yield return new WaitForSeconds(delay);

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            mySpriteRenderer.color = Color.Lerp(dmgColor, originColor, t);

            yield return null;
        }

        // restore origin color
        mySpriteRenderer.color = originColor;
    }


    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }
}
