using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class character : MonoBehaviour
{

    Rigidbody2D rb;
    private SpriteRenderer mySpriteRenderer;


   
    // Movement
    public float upspeed;
    private float speed = 2f;
    Animator animator;
    public bool top;
    private bool ForceFloat;
    public bool RiftColition;
    ManaHandle mana;
    private float maxspeed = 10f;
    private float acceleration = 2f;



    // Coin Collecting

    private float coins = 0;
    public TextMeshProUGUI CoinCounter;

    // crystal Collecting

    private float crystal = 0;
    public TextMeshProUGUI CrystalCounter;


    // Health System
    public int Health;
    public int NumOfHearts;
    public GameObject[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    bool hasPassedThroughRift;

    //Power Management
    public bool isUsingPower;
    public string lightPower;
    public string darkPower;

    public GameObject DamageEffect;
    public GameObject riftEffect;
    public RipplePostProcessor CamRipple;

    // End Of Level

    //public bool EndLevel;
    //public bool characterConstrains;

    //death

    public GameObject DeathScreen;
  
    
  

    /* 
   public Transform EndlessHouseTarget1;
   public Transform EndlessHouseTarget2;


   public float pulledspeed = 2f;
   private float pulledmaxspeed = 40f;
   public float pulledAcceleration = 0f;
   public LevelLoader levelLoader;


   [SerializeField]
   [Range(0f, 1f)]
   private float lerpPct = 0f;
   */

    //start level
    /*
        public Transform startMarker;
        public Transform endMarker;
        public float outOfportalSpeed;
        public float startTime;
        public float journeyLength;
        public bool gamestart;
        public PauseStart pausestart;
    */

    private float deceleration;
    public float outOfportalSpeed;
    private float maxstartspeed;
    public PauseStart pausestart;















    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb.AddForce(new Vector2(0, 200));
        mana = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<ManaHandle>();
        animator = GetComponent<Animator>();
        darkPower = GameStats.stats.darkPowerName;
        lightPower = GameStats.stats.lightPowerName;
        coins = GameStats.stats.coins; //sets held coins to value stored
        crystal = GameStats.stats.crystals; //sets held crystals to value stored
        CoinCounter.text = coins.ToString();
        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;

        //characterConstrains = false;


       
        //heartanimator = GameObject.FindGameObjectWithTag("Heart").GetComponent<Animator>();


        
    }

    // Update is called once per frame
    void Update()

    {
       
         

                animator.SetBool("start", false);

      


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


                // Death

            if (Health == 0 && GameStats.stats.fenixFeather == false)
                {
                    StartCoroutine(Death());
                }

            if (Health == 0 && GameStats.stats.fenixFeather == true)
                {
                    Health = NumOfHearts;

                }




            




            // Character Moves forward

            if (speed < maxspeed)
            {
                speed = speed + acceleration * Time.deltaTime;
            }

            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;

            GameStats.stats.coins = coins;//updates stored coin value;
            GameStats.stats.crystals = crystal;//updates stored crystal value;

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
                CamRipple.RippleEffect();
            




        }

        //collision with coins

        if (collision.tag == "Coin")
        {
           if (GameStats.stats.CoinTicket == false)
            {
                coins++;
                CoinCounter.text = coins.ToString();
            }
           if (GameStats.stats.CoinTicket == true)
            coins += 2;
            CoinCounter.text = coins.ToString();
        }

        if (collision.tag == "Crystal")
        {
            crystal++;
            CrystalCounter.text = crystal.ToString();
        }

        if (collision.tag == "Heart")
        {
            Health += 1;
        }



        // colission with enemy proyectile

        if (collision.tag == "Enemy proyectile")
        {
            Health -= 1;
            animator.SetTrigger("GotHit");
            StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(0.8f, 0.7f, 0.7f, 1f), 0.2f, 0.2f));
            StartCoroutine(GetInvulnerable());
            gameObject.GetComponent<DamageTime>().TimeDamageStop(0.05f, 10, 0.1f);
            Instantiate(DamageEffect, transform.position, Quaternion.identity);
        }
        if (collision.name == "jumpHeight")
        {
            hasPassedThroughRift = false;
        }

/*
        if (collision.tag == "House")
        {
            //EndLevel = false;
            Debug.Log("house hit");
            levelLoader.changelevel();
            animator.SetTrigger("HouseHit");
            FindObjectOfType<AudioManager>().Play("TransitionSound");



        }
  */


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rift")
        {
            
            
                rb.gravityScale *= -1;
                RiftColition = false;
                hasPassedThroughRift = true;
                Instantiate(riftEffect, transform.position, Quaternion.identity);
                StartCoroutine(GetInvulnerableRift());
            


        }
    }


    void Rotation()
    {

        {
            //transform.eulerAngles = new Vector3(0, 0, 180f);


            top = !top; // toggles onoff at each click

            if (top)
            {
                transform.localEulerAngles = new Vector3(180, 0, 0);

                //mySpriteRenderer.flipY = true;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                //mySpriteRenderer.flipY = false;
            }

        }
        
    }




    public void LightPower()
    {

        
        
        mana.RequiredDarkMana(GameStats.stats.lightMana);
        if (mana.CurrentDarkMana >= mana.DarkManaUsed && !isUsingPower)
        {
            isUsingPower = true;
            animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerLight.id);
            mana.ReduceDarkMana();
            /*
            if (lightPower == "Missile")
            {
                animator.SetTrigger("Missile");
                GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                carrot.transform.position = transform.position + new Vector3(1, 0, 0);
                mana.ReduceDarkMana();
                FindObjectOfType<AudioManager>().Play("MagicMissle");
            }
            if (lightPower == "Defence")
            {
                animator.SetTrigger("Defence");
                GameObject shield = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shield.transform.position = transform.position;
                mana.ReduceDarkMana();
                FindObjectOfType<AudioManager>().Play("MagicDefence");
            }
             */
        }



    }
        public void DarkPower()
    {

       
         mana.RequiredLightMana(GameStats.stats.darkMana);
         if (mana.CurrentLightMana >= mana.LightManaUsed && !isUsingPower)
         {
             isUsingPower = true;
             animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerDark.id);
            mana.ReduceLightMana();
            /*
             if (darkPower == "Missile")
             {
                 animator.SetTrigger("Missile");
                 GameObject carrot = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                 carrot.transform.position = transform.position + new Vector3(1, 0, 0);
                 mana.ReduceLightMana();
                 FindObjectOfType<AudioManager>().Play("MagicMissle");
             }
             if (darkPower == "Defence")
             {
                 animator.SetTrigger("Defence");
                 GameObject shield = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                 shield.transform.position = transform.position;
                 mana.ReduceLightMana();
                 FindObjectOfType<AudioManager>().Play("MagicDefence");
             }
                */

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
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }

    IEnumerator GetInvulnerableRift()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }


    IEnumerator GetInvulnerablePower()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }
    IEnumerator Death()
    {
        Time.timeScale = 0;
        animator.SetTrigger("Dead");

        yield return new WaitForSecondsRealtime(1f);
        

        DeathScreen.SetActive(true);
    }

    
    



    public void ResetUsingPower()
    {
        isUsingPower = false;
        animator.SetBool("isUsingPower", false);

    }

    public void UsedPower(int id)
    {
        switch (id)
        {
            case 1:

                // carrot missle
                print("used missle T1");
                animator.SetTrigger("Missile");
                GameObject carrotT1 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                carrotT1.transform.position = transform.position + new Vector3(1, 0, 0);
                
                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 2:

                // carrot missle
                print("used missle T2");
                animator.SetTrigger("Missile");
                GameObject carrotT2 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                carrotT2.transform.position = transform.position + new Vector3(1, 0, 0);

                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 3:

                // carrot missle
                print("used missle T3");
                animator.SetTrigger("Missile");
                GameObject carrotT3 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                CarrotMissile CarrotT3Stats = carrotT3.GetComponent<CarrotMissile>();
                CarrotT3Stats.Piercing = true;

                carrotT3.transform.position = transform.position + new Vector3(1, 0, 0);

                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 4:

                // carrot missle
                print("used missle T4");
                animator.SetTrigger("Missile");
                GameObject carrotT4 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                carrotT4.transform.position = transform.position + new Vector3(1, 0.5f, 0);
                GameObject carrotT4Clone = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                CarrotMissile CarrotT4Stats = carrotT4.GetComponent<CarrotMissile>();
                CarrotT4Stats.Piercing = true;
                CarrotMissile CarrotT4CloneStats = carrotT4Clone.GetComponent<CarrotMissile>();
                CarrotT4CloneStats.Piercing = true;
                carrotT4Clone.transform.position = transform.position + new Vector3(1, -0.5f, 0);


                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;





            case 10:
                // eardefence
                print("used Shield T1");
                animator.SetTrigger("Defence");
                GameObject shieldT1 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT1.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());
                
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 11:
                // eardefence
                print("used Shield T2");
                animator.SetTrigger("Defence");
                GameObject shieldT2 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT2.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 12:
                // eardefence
                print("used Shield T3");
                animator.SetTrigger("Defence");
                GameObject shieldT3 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT3.transform.position = transform.position;
                Shield ShieldT3stats = shieldT3.GetComponent<Shield>();
                ShieldT3stats.HealthAbsorb = true;
                StartCoroutine(GetInvulnerablePower());

                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 13:
                // eardefence
                print("used Shield T4");
                animator.SetTrigger("Defence");
                GameObject shieldT4 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT4.transform.position = transform.position;
                Shield ShieldT4stats = shieldT4.GetComponent<Shield>();
                ShieldT4stats.HealthAbsorb = true;
                StartCoroutine(GetInvulnerablePower());

                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;




            case 20:
                // radish missile
                print("used spell 3");
                animator.SetTrigger("Missile");
                GameObject radish = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radish.transform.position = transform.position + new Vector3(1, 0, 0);

                FindObjectOfType<AudioManager>().Play("MagicMissle");

                break;
            case 30:
                // kick
                print("used spell 4");
                animator.SetTrigger("Kick");
                break;
            case 40:
                print("used spell 5");
                break;

            default:
                print("spell error");
                break;
        }
    }


  
}


