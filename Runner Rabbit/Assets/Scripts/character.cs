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
    public bool hit;



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
    public bool silenced;

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

    public bool endlevel = false;

    //laser

    public LineRenderer laser;

    public Transform StartLaserPos;
    public GameObject startVFX;
    public GameObject endVFX;




    public bool HoldPower = false;


    public int LaserlayerMask;


    // FenixFeather Used

    public GameObject FenixFeatherAnim;












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
        CrystalCounter.text = crystal.ToString();

        NumOfHearts = GameStats.stats.numOfHearts;




        if (GameStats.stats.ExtraHearts == true)
        {
            NumOfHearts += 2;
            GameStats.stats.ExtraHearts = false;
            GameStats.stats.SaveStats();
        }

        Health = NumOfHearts;
        endlevel = false;

        startVFX.GetComponent<ParticleSystem>().Stop();
        endVFX.GetComponent<ParticleSystem>().Stop();


        startVFX.SetActive(false);
        endVFX.SetActive(false);
        laser.enabled = false;







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
            if (GameStats.stats.diedTimes < 50)
            {
                GameStats.stats.diedTimes++;
            }
        }

        if (Health == 0 && GameStats.stats.fenixFeather == true)
        {
            Health = NumOfHearts;
            GameStats.stats.fenixFeather = false;
            Animator FeatherAnimator = FenixFeatherAnim.GetComponent<Animator>();
            FeatherAnimator.SetTrigger("FenixFeatherUsed");


        }









        // Character Moves forward

        if (speed < maxspeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        if (speed > maxspeed)
        {
            speed = maxspeed;
        }

        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        GameStats.stats.coins = coins;//updates stored coin value;
        GameStats.stats.crystals = crystal;//updates stored crystal value;





        if (endlevel == true)
        {
            StartCoroutine(GetInvulnerableEndLevel());
        }


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

            StartCoroutine(GetInvulnerableRift());





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

        if (collision.tag == "Enemy proyectile" || collision.tag == "Enemy")
        {
            LoseHealth();
            /*Health -= 1;
            animator.SetTrigger("GotHit");
            StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(0.8f, 0.7f, 0.7f, 1f), 0.2f, 0.2f));
            StartCoroutine(GetInvulnerable());
            gameObject.GetComponent<DamageTime>().TimeDamageStop(0.05f, 10, 0.1f);
            Instantiate(DamageEffect, transform.position, Quaternion.identity);*/
        }
        if (collision.name == "jumpHeight")
        {
            hasPassedThroughRift = false;
        }
        if (collision.name == "Silence")
        {
            silenced = true;
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

            if (GameStats.stats.powerDark.id >= 52)
            {
                DarkPowerHoldStop();
            }
            if (GameStats.stats.powerLight.id >= 52)
            {
                LightPowerHoldStop();
            }


        }
        if (collision.name == "Silence")
        {
            silenced = false;
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
        if (mana.CurrentDarkMana >= mana.DarkManaUsed && !isUsingPower && !silenced)
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

    public void LightPowerHold()
    {
        mana.RequiredDarkMana(GameStats.stats.lightMana + 5);
        if (mana.CurrentDarkMana >= mana.DarkManaUsed && !silenced)
        {

            animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerLight.id);
            mana.ReduceDarkMana();
            HoldPower = true;
            startVFX.SetActive(true);
            endVFX.SetActive(true);
        }
        else
        {
            LightPowerHoldStop();
        }


    }

    public void LightPowerHoldStop()
    {
        animator.SetBool("isUsingPower", false);
        UsedPower(GameStats.stats.powerLight.id);
        HoldPower = false;
    }

    public void DarkPowerHold()
    {
        mana.RequiredLightMana(GameStats.stats.darkMana);
        if (mana.CurrentLightMana >= mana.LightManaUsed + 5 && !silenced)
        {
            //print("UsingPower");
            animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerDark.id);
            mana.ReduceLightMana();
            HoldPower = true;
            startVFX.SetActive(true);
            endVFX.SetActive(true);

        }
        else
        {
            DarkPowerHoldStop();
        }

    }

    public void DarkPowerHoldStop()
    {
        animator.SetBool("isUsingPower", false);
        UsedPower(GameStats.stats.powerDark.id);
        HoldPower = false;
    }


    public void DarkPower()
    {


        mana.RequiredLightMana(GameStats.stats.darkMana);
        if (mana.CurrentLightMana >= mana.LightManaUsed && !isUsingPower && !silenced)
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
    public void LoseHealth()
    {
        Health -= 1;
        animator.SetTrigger("GotHit");
        StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(0.8f, 0.7f, 0.7f, 1f), 0.2f, 0.2f));
        StartCoroutine(GetInvulnerable());
        gameObject.GetComponent<DamageTime>().TimeDamageStop(0.05f, 10, 0.4f);
        Instantiate(DamageEffect, transform.position, Quaternion.identity);
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

            
        }

        // restore origin color
        mySpriteRenderer.color = originColor;
    }


    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        hit = true;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        hit = false;


    }

    IEnumerator GetInvulnerableRift()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }

    IEnumerator GetInvulnerableEndLevel()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(20f);
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
                CarrotMissile CarrotT1Stats = carrotT1.GetComponent<CarrotMissile>();
                CarrotT1Stats.Piercing = false;
                CarrotT1Stats.damage = 10;
                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 2:

                // carrot missle
                print("used missle T2");
                animator.SetTrigger("Missile");
                GameObject carrotT2 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                carrotT2.transform.position = transform.position + new Vector3(1, 0, 0);
                CarrotMissile CarrotT2Stats = carrotT2.GetComponent<CarrotMissile>();
                CarrotT2Stats.Piercing = false;
                CarrotT2Stats.damage = 15;
                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 3:

                // carrot missle
                print("used missle T3");
                animator.SetTrigger("Missile");
                GameObject carrotT3 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                CarrotMissile CarrotT3Stats = carrotT3.GetComponent<CarrotMissile>();
                CarrotT3Stats.Piercing = true;
                CarrotT3Stats.damage = 20;
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
                CarrotT4Stats.damage = 25;
                CarrotMissile CarrotT4CloneStats = carrotT4Clone.GetComponent<CarrotMissile>();
                CarrotT4CloneStats.Piercing = true;
                CarrotT4CloneStats.damage = 25;
                carrotT4Clone.transform.position = transform.position + new Vector3(1, -0.5f, 0);


                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;





            case 11:
                // eardefence
                print("used Shield T1");
                animator.SetTrigger("Defence");
                GameObject shieldT1 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT1.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());

                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 12:
                // eardefence
                print("used Shield T2");
                animator.SetTrigger("Defence");
                GameObject shieldT2 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                shieldT2.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 13:
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

            case 14:
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




            case 21:
                // radish missile
                print("used spell 3");
                animator.SetTrigger("Missile");
                GameObject radishT1 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT1.transform.position = transform.position + new Vector3(1, 0, 0);
                RadishMissile RadishT1stats = radishT1.GetComponent<RadishMissile>();
                RadishT1stats.damage = 15;
                FindObjectOfType<AudioManager>().Play("MagicMissle");

                break;
            case 22:
                // radish missile
                print("used spell 3");
                animator.SetTrigger("Missile");
                GameObject radishT2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT2.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                RadishMissile RadishT2stats = radishT2.GetComponent<RadishMissile>();
                RadishT2stats.damage = 15;
                GameObject radishT2clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT2clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                RadishMissile RadishT2statsclone = radishT2clone.GetComponent<RadishMissile>();
                RadishT2statsclone.damage = 15;
                FindObjectOfType<AudioManager>().Play("MagicMissle");

                break;
            case 23:
                // radish missile
                print("used spell 3");
                animator.SetTrigger("Missile");
                GameObject radishT3 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT3.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                RadishMissile RadishT3stats = radishT3.GetComponent<RadishMissile>();
                RadishT3stats.damage = 15;
                GameObject radishT3clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT3clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                RadishMissile RadishT3statsclone = radishT3clone.GetComponent<RadishMissile>();
                RadishT3statsclone.damage = 15;
                GameObject radishT3clone2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT3clone2.transform.position = transform.position + new Vector3(2, 0, 0);
                RadishMissile RadishT3statsclone2 = radishT3clone2.GetComponent<RadishMissile>();
                RadishT3statsclone2.damage = 15;
                FindObjectOfType<AudioManager>().Play("MagicMissle");

                break;
            case 24:
                // radish missile
                print("used spell 3");
                animator.SetTrigger("Missile");
                GameObject radishT4 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT4.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                RadishMissile RadishT4stats = radishT4.GetComponent<RadishMissile>();
                RadishT4stats.damage = 25;
                GameObject radishT4clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT4clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                RadishMissile RadishT4statsclone = radishT4clone.GetComponent<RadishMissile>();
                RadishT4statsclone.damage = 25;
                GameObject radishT4clone2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                radishT4clone2.transform.position = transform.position + new Vector3(2, 0, 0);
                RadishMissile RadishT4statsclone2 = radishT4clone2.GetComponent<RadishMissile>();
                RadishT4statsclone2.damage = 25;


                break;
            case 31:
                // kick
                print("used spell 4");
                animator.SetTrigger("Kick");
                GameObject kickT1 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                kickT1.transform.position = transform.position;
                kickT1.name = "Kick";
                Kick kickT1Stats = kickT1.GetComponent<Kick>();
                kickT1Stats.reflect = false;
                break;
            case 32:
                // kick
                print("used spell 4");
                animator.SetTrigger("Kick");
                GameObject kickT2 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                kickT2.transform.position = transform.position;
                kickT2.name = "Kick";
                Kick kickT2Stats = kickT2.GetComponent<Kick>();
                kickT2Stats.reflect = false;
                break;
            case 33:
                // kick
                print("used spell 4");
                animator.SetTrigger("Kick");
                GameObject kickT3 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                kickT3.transform.position = transform.position;
                kickT3.name = "Kick";
                Kick kickT3Stats = kickT3.GetComponent<Kick>();
                kickT3Stats.reflect = true;
                break;
            case 34:
                // kick
                print("used spell 4");
                animator.SetTrigger("Kick");

                GameObject kickT4 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                kickT4.transform.position = transform.position;
                kickT4.name = "Kick";
                Kick kickT4Stats = kickT4.GetComponent<Kick>();
                kickT4Stats.reflect = true;
                break;
            case 41:
                print("used spell 5");
                break;

            case 51:
                if (HoldPower == true)
                {
                    //print("lasering");
                    startVFX.SetActive(true);
                    endVFX.SetActive(true);
                    laser.enabled = true;

                    int layerMask = 1 << 9;
                    LaserlayerMask = layerMask;

                    animator.SetBool("Laser", true);
                    endVFX.transform.position = laser.GetPosition(1);
                    startVFX.GetComponent<ParticleSystem>().Play();
                    endVFX.GetComponent<ParticleSystem>().Play();
                    laser.SetPosition(0, StartLaserPos.position);
                    laser.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                    Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                    RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);


                    if (hit.collider != null)
                    {
                        laser.SetPosition(1, hit.point);
                        if (hit.transform.tag == "Enemy")
                        {
                            EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                            target.TakeDamage(1);
                        }
                        //Debug.Log("RayCast: " + hit.collider.gameObject.tag);
                    }

                }
                else if (HoldPower == false)
                {
                    animator.SetBool("Laser", false);
                    laser.enabled = false;
                    startVFX.GetComponent<ParticleSystem>().Stop();
                    endVFX.GetComponent<ParticleSystem>().Stop();

                }

                break;

            case 52:
                if (HoldPower == true)
                {
                    //print("lasering");

                    laser.enabled = true;

                    int layerMask = 1 << 9;
                    LaserlayerMask = layerMask;

                    animator.SetBool("Laser", true);
                    endVFX.transform.position = laser.GetPosition(1);
                    startVFX.GetComponent<ParticleSystem>().Play();
                    endVFX.GetComponent<ParticleSystem>().Play();
                    laser.SetPosition(0, StartLaserPos.position);
                    laser.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                    Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                    RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);


                    if (hit.collider != null)
                    {
                        laser.SetPosition(1, hit.point);
                        if (hit.transform.tag == "Enemy")
                        {
                            EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                            target.TakeDamage(1);
                        }
                        //Debug.Log("RayCast: " + hit.collider.gameObject.tag);
                    }

                }
                else if (HoldPower == false)
                {
                    animator.SetBool("Laser", false);
                    laser.enabled = false;
                    startVFX.GetComponent<ParticleSystem>().Stop();
                    endVFX.GetComponent<ParticleSystem>().Stop();

                }
                break;
            case 53:
                if (HoldPower == true)
                {
                    //print("lasering");
                    startVFX.SetActive(true);
                    endVFX.SetActive(true);
                    laser.enabled = true;

                    int layerMask1 = 1 << 9;
                    int layerMask2 = 1 << 15;

                    int CombiendLayerMask = layerMask1 | layerMask2;
                    LaserlayerMask = CombiendLayerMask;

                    animator.SetBool("Laser", true);
                    endVFX.transform.position = laser.GetPosition(1);
                    startVFX.GetComponent<ParticleSystem>().Play();
                    endVFX.GetComponent<ParticleSystem>().Play();
                    laser.SetPosition(0, StartLaserPos.position);
                    laser.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                    Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                    RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);


                    if (hit.collider != null)
                    {
                        laser.SetPosition(1, hit.point);
                        if (hit.transform.tag == "Enemy")
                        {
                            EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                            target.TakeDamage(1);
                        }

                        if (hit.transform.tag == "Enemy proyectile")
                        {
                            print("destroyed" + hit.transform.gameObject.name);
                            Destroy(hit.transform.gameObject);
                        }
                        //Debug.Log("RayCast: " + hit.collider.gameObject.tag);
                    }

                }
                else if (HoldPower == false)
                {
                    animator.SetBool("Laser", false);
                    laser.enabled = false;
                    startVFX.GetComponent<ParticleSystem>().Stop();
                    endVFX.GetComponent<ParticleSystem>().Stop();

                }
                break;
            case 54:
                if (HoldPower == true)
                {
                    //print("lasering");
                    startVFX.SetActive(true);
                    endVFX.SetActive(true);
                    laser.enabled = true;
                    int layerMask1 = 1 << 9;
                    int layerMask2 = 1 << 15;

                    int CombiendLayerMask = layerMask1 | layerMask2;
                    LaserlayerMask = CombiendLayerMask;

                    animator.SetBool("Laser", true);
                    endVFX.transform.position = laser.GetPosition(1);
                    startVFX.GetComponent<ParticleSystem>().Play();
                    endVFX.GetComponent<ParticleSystem>().Play();
                    laser.SetPosition(0, StartLaserPos.position);
                    laser.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                    Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                    RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);


                    if (hit.collider != null)
                    {
                        laser.SetPosition(1, hit.point);
                        if (hit.transform.tag == "Enemy")
                        {
                            EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                            target.TakeDamage(1);
                        }

                        if (hit.transform.tag == "Enemy proyectile")
                        {
                            Destroy(hit.transform.gameObject);
                        }
                        //Debug.Log("RayCast: " + hit.collider.gameObject.tag);
                    }

                }
                else if (HoldPower == false)
                {
                    animator.SetBool("Laser", false);
                    laser.enabled = false;
                    startVFX.GetComponent<ParticleSystem>().Stop();
                    endVFX.GetComponent<ParticleSystem>().Stop();

                }
                break;


            default:
                print("spell error");
                break;
        }
    }



}


