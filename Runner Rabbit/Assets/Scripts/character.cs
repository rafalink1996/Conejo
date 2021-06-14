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

    float Alpha;


    //[SerializeField] SpriteRenderer mySpriteRenderer;

    [SerializeField] LayerMask InvulnerableMask;



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
    public bool shielded;
    public bool DarkSilecend;
    public bool LightSilenced;
    public bool ShieldHealthAbsorb;

    public GameObject DamageEffect;
    public GameObject BlockEffect;
    public GameObject riftEffect;
    public GameObject HealEffect;
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

    public LineRenderer LaserLight;
    public LineRenderer LaserDark;
    public bool isUsinglaserLight;

    public Transform StartLaserPos;

    public GameObject StartVFXLight;
    public GameObject EndVFXLight;

    public GameObject StartVFXDark;
    public GameObject EndVFXDark;






    public bool HoldPower = false;



    public int LaserlayerMask = 1 << 15;


    // FenixFeather Used

    public GameObject FenixFeatherAnim;




    // Runes - Passives

    private bool RuneShielded;
    public GameObject RuneShield;



    //debug hold power
    public bool HoldPowerIsOn;


    [Header("Caches")]
    [SerializeField] GameObject ButtonDark;
    [SerializeField] GameObject ButtonLight;
    Button DarkButtonComponent;
    Button LightButtonComponent;


    // Invulnerabilities

    bool invulnerableRiftActive = false;
    bool InvulnerableHitActive = false;
    bool InvulnerableEndLevelActive = false;


    //posion

    public bool isPoisoned = false;
    float poisonTime = 0;
    //[SerializeField] GameObject poisonImageUI;
    [SerializeField] GameObject isPoisonedEffect;
    [SerializeField] GameObject PoisonDamageeffect;
    [SerializeField] Color PosionDamageColor;

    //kickObject
    [SerializeField] GameObject kickObject;
    float KickObjectTime = 1;
    float maxKickObjectTime = 1;


    ObjectPooler myObjectPooler;

    string radishMissleTag = "RadishMissle";
    string carrotMissleTag = "CarrotMissle";
    string kickReflectTag = "KickReflect";




    //Check

    float LaserTimeCall;

    // debug images

    // public GameObject LightDebugImage;
    // public GameObject DarkDebugImage;

    [SerializeField] UIManager MyUIManager;
    [SerializeField] AudioSource shieldBreakAudio;
    [SerializeField] AudioSource LaserSFX;
    bool LaserSFXPlaying;


    [SerializeField] bool IsInmortal;

    
    // Start is called before the first frame update
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        radishMissleTag = "RadishMissle";
        GameObject ButtonDark = GameObject.FindObjectOfType<Darkpower>().gameObject;
        ButtonDark.SetActive(true);
        GameObject ButtonLight = GameObject.FindObjectOfType<Lightpower>().gameObject;
        ButtonLight.SetActive(true);

        Button DarkButtonComponent = ButtonDark.GetComponent<Button>();
        Button LightButtonComponent = ButtonLight.GetComponent<Button>();

        MyUIManager = FindObjectOfType<UIManager>();
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

        if (GameStats.stats.Rune1 == GameStats.Rune.AlternateWorldsRune || GameStats.stats.Rune2 == GameStats.Rune.AlternateWorldsRune)
        {
            bool[] PowerUps = new bool[] { GameStats.stats.CoinTicket, GameStats.stats.fenixFeather, GameStats.stats.ManaJar, GameStats.stats.ExtraHearts, GameStats.stats.PortalBoost };
            for (int i = 0; i < PowerUps.Length; i++)
            {
                List<int> PowerUpsNotActive = new List<int> { };
                if (PowerUps[i] == false)
                {
                    PowerUpsNotActive.Add(i);
                }
                int RandomPowerUp = Random.Range(0, PowerUpsNotActive.Count);
                int SelectedPowerup = PowerUpsNotActive[RandomPowerUp];
                PowerUps[SelectedPowerup] = true;
                if (SelectedPowerup == 0)
                {
                    GameStats.stats.CoinTicket = true;
                }
                else if (SelectedPowerup == 1)
                {
                    GameStats.stats.fenixFeather = true;
                }
                else if (SelectedPowerup == 2)
                {
                    GameStats.stats.ManaJar = true;
                }
                else if (SelectedPowerup == 3)
                {
                    GameStats.stats.ExtraHearts = true;
                }
                else if (SelectedPowerup == 4)
                {
                    GameStats.stats.PortalBoost = true;
                }
            }
        }


        // Set Rune Shield
        if (GameStats.stats.Rune1 == GameStats.Rune.ShieldRune || GameStats.stats.Rune2 == GameStats.Rune.ShieldRune)
        {
            RuneShielded = true;
            RuneShield.SetActive(true);
        }

        /*
                if (GameStats.stats.ExtraHearts == true)
                {

                    GameStats.stats.numOfHearts += 4;
                    GameStats.stats.HealToFull();
                    GameStats.stats.ExtraHearts = false;
                    GameStats.stats.SaveStats();
                }
        */


        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;
        endlevel = false;

        //LightLaser
        StartVFXLight.GetComponent<ParticleSystem>().Stop();
        EndVFXLight.GetComponent<ParticleSystem>().Stop();


        StartVFXLight.SetActive(false);
        EndVFXLight.SetActive(false);
        LaserLight.enabled = false;

        //DarkLAser
        StartVFXDark.GetComponent<ParticleSystem>().Stop();
        EndVFXDark.GetComponent<ParticleSystem>().Stop();

        StartVFXDark.SetActive(false);
        EndVFXDark.SetActive(false);
        LaserDark.enabled = false;



        // DarkDebugImage.SetActive(false);
        // LightDebugImage.SetActive(false);



    }

    // Update is called once per frame
    void Update()

    {

        if (top)
        {
            LightSilenced = true;
            DarkSilecend = false;
        }
        else if (!top)
        {

            LightSilenced = false;
            DarkSilecend = true;
        }



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

        if (Health <= 0 && GameStats.stats.fenixFeather == false && !IsInmortal)
        {

            if (GameStats.stats.diedTimes < 50)
            {
                GameStats.stats.diedTimes++;
            }
            mySpriteRenderer.color = Color.white;
            StartCoroutine(Death());
        }

        if (Health <= 0 && GameStats.stats.fenixFeather == true)
        {
            Health = NumOfHearts;
            GameStats.stats.fenixFeather = false;
            Animator FeatherAnimator = FenixFeatherAnim.GetComponent<Animator>();
            FeatherAnimator.SetTrigger("FenixFeatherUsed");


        }

        if (isPoisoned)
        {

            if (poisonTime > 0)
            {
                poisonTime -= Time.deltaTime;
            }
            else
            {
                isPoisoned = false;
            }

        }
        else
        {

            isPoisonedEffect.SetActive(false);
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



        if (kickObject.activeSelf == true && KickObjectTime < 0)
        {
            kickObject.SetActive(false);
        }
        else
        {
            KickObjectTime -= Time.deltaTime;
        }



    }

    public void SetSavedStats()
    {
        Health = GameStats.stats.SaveCurrentHearts;
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

            // GameObject ButtonDark = GameObject.Find("UI/HUD/Power/Power Dark");
            // ButtonDark.SetActive(false);
            // GameObject ButtonLight = GameObject.Find("UI/HUD/Power/Power Light");
            // ButtonLight.SetActive(false);

            //DarkPowerHoldStop();
            //LightPowerHoldStop();

            Button DarkButtonComponent = ButtonDark.GetComponent<Button>();
            Button LightButtonComponent = ButtonLight.GetComponent<Button>();
            if (DarkButtonComponent != null)
            {
                DarkButtonComponent.interactable = false;
            }
            if (LightButtonComponent != null)
            {
                LightButtonComponent.interactable = false;
            }



            StartCoroutine(ResetHoldPower());

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
            {
                coins += 2;
                CoinCounter.text = coins.ToString();
            }
        }

        if (collision.tag == "Crystal")
        {
            crystal++;
            CrystalCounter.text = crystal.ToString();
        }

        if (collision.tag == "Heart")
        {
            GameObject HealParticle = Instantiate(HealEffect, transform.position, Quaternion.identity);
            HealParticle.transform.parent = this.transform;
            HealParticle.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Health += 1;
        }



        // colission with enemy proyectile

        if (collision.tag == "Enemy proyectile" || collision.tag == "Enemy")
        {

            if (!shielded)
            {
                if (RuneShielded)
                {
                    RuneShielded = false;
                    Animator RuneShieldAnimator = RuneShield.GetComponent<Animator>();
                    RuneShieldAnimator.SetTrigger("Break");
                    LoseHealth(0, 0.3f, 0.7f, 1, 1, false);
                    shieldBreakAudio.Play();
                }
                else
                {
                    int damage;
                    Proyectile proyectile = collision.GetComponent<Proyectile>();

                    if (proyectile != null)
                    {
                        if (proyectile.Poison == true)
                        {
                            poisonTime = proyectile.PoisonTime;
                            isPoisonedEffect.SetActive(true);
                            isPoisoned = true;

                        }
                        damage = proyectile.Damage;
                    }
                    else
                    {
                        Debug.Log("No Poroyectile found");
                        damage = 1;
                    }

                    LoseHealth(damage);
                }

            }
            else
            {
                Instantiate(BlockEffect, collision.transform.position, Quaternion.identity);
                if (ShieldHealthAbsorb == true)
                {

                    GameObject HealParticle = Instantiate(HealEffect, transform.position, Quaternion.identity);
                    HealParticle.transform.parent = this.transform;
                    HealParticle.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    Health += 1;
                    ShieldHealthAbsorb = false;
                }
            }





        }
        if (collision.name == "jumpHeight")
        {
            hasPassedThroughRift = false;
        }
        if (collision.name == "Silence")
        {
            silenced = true;
            //MyUIManager.ToggleSilencedUI(true);
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
            MyUIManager.ChangeManaInUse();

            //silenced = false;
            //MyUIManager.ToggleSilencedUI(false);




            if (DarkButtonComponent != null)
            {
                DarkButtonComponent.interactable = true;
            }
            if (LightButtonComponent != null)
            {
                LightButtonComponent.interactable = true;
            }




        }
        if (collision.name == "Silence")
        {
            silenced = false;
            //MyUIManager.ToggleSilencedUI(false);

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
        //mana.RequiredDarkMana(GameStats.stats.powerLight.mana);
        if (mana.CurrentDarkMana >= mana.DarkManaUsed && !isUsingPower && !silenced)
        {
            isUsingPower = true;
            animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerLight.id, GameStats.stats.powerLight.Damage);
            mana.ReduceDarkMana();

        }
        if (isPoisoned)
        {
            if (ShieldHealthAbsorb)
            {
                isPoisoned = false;
            }
            else
            {
                LoseHealth(1, PosionDamageColor.r, PosionDamageColor.g, PosionDamageColor.b, PosionDamageColor.a);
                isPoisoned = false;
                //Instantiate(PoisonDamageeffect, transform.position, Quaternion.identity);
            }

        }
    }

    public void LightPowerHold()
    {
        //mana.RequiredDarkMana(GameStats.stats.powerLight.mana) ;

        if (mana.CurrentDarkMana >= 1 /*mana.DarkManaUsed*/ && !silenced && !LightSilenced)
        {

            animator.SetBool("Laser", true);

            //animator.SetBool("isUsingPower", true);
            isUsinglaserLight = true;
            HoldPower = true;

            UsedPower(GameStats.stats.powerLight.id, GameStats.stats.powerLight.Damage);
            mana.ReduceDarkManaHold();






            LaserLight.enabled = true;
            StartVFXLight.SetActive(true);
            EndVFXLight.SetActive(true);



        }
        else
        {
            LightPowerHoldStop();

        }

        if (isPoisoned)
        {
            LoseHealth(1, PosionDamageColor.r, PosionDamageColor.g, PosionDamageColor.b, PosionDamageColor.a);
            isPoisoned = false;
            Instantiate(PoisonDamageeffect, transform.position, Quaternion.identity);
        }


    }

    public void LightPowerHoldStop()
    {
        animator.SetBool("isUsingPower", false);
        // UsedPower(GameStats.stats.powerLight.id);

        LaserLight.enabled = false;
        HoldPower = false;

        isUsinglaserLight = false;


        animator.SetBool("Laser", false);

        StartVFXLight.GetComponent<ParticleSystem>().Stop();
        EndVFXLight.GetComponent<ParticleSystem>().Stop();




        GameObject ButtonLight = GameObject.Find("UI/HUD/PowersHud/Power/Power Light");
        HoldButton HoldButtonLight = ButtonLight.GetComponent<HoldButton>();
        HoldButtonLight.Reset();
        LaserSFX.Stop();
        LaserSFXPlaying = false;


    }

    public void DarkPowerHold()
    {
        //mana.RequiredLightMana(GameStats.stats.powerDark.mana);

        if (mana.CurrentLightMana >= 1 /*mana.LightManaUsed*/  && !silenced && !DarkSilecend)
        {
            LaserDark.enabled = true;
            isUsinglaserLight = false;
            HoldPower = true;

            animator.SetBool("Laser", true);
            //animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerDark.id, GameStats.stats.powerDark.Damage);
            mana.ReduceLightManaHold();




            StartVFXDark.SetActive(true);
            EndVFXDark.SetActive(true);


        }
        else
        {
            DarkPowerHoldStop();

        }

        if (isPoisoned)
        {
            LoseHealth(1, PosionDamageColor.r, PosionDamageColor.g, PosionDamageColor.b, PosionDamageColor.a);
            isPoisoned = false;
            Instantiate(PoisonDamageeffect, transform.position, Quaternion.identity);
        }

    }

    public void DarkPowerHoldStop()
    {
        animator.SetBool("isUsingPower", false);
        //UsedPower(GameStats.stats.powerDark.id);

        isUsinglaserLight = false;

        animator.SetBool("Laser", false);
        LaserDark.enabled = false;
        StartVFXDark.GetComponent<ParticleSystem>().Stop();
        EndVFXDark.GetComponent<ParticleSystem>().Stop();
        HoldPower = false;

        GameObject ButtonDark = GameObject.Find("UI/HUD/PowersHud/Power/Power Dark");
        HoldButton HoldButtonDark = ButtonDark.GetComponent<HoldButton>();
        HoldButtonDark.Reset();
        LaserSFX.Stop();
        LaserSFXPlaying = false;


    }


    public void DarkPower()
    {


        //mana.RequiredLightMana(GameStats.stats.powerDark.mana);
        if (mana.CurrentLightMana >= mana.LightManaUsed && !isUsingPower && !silenced)
        {
            isUsingPower = true;
            animator.SetBool("isUsingPower", true);
            UsedPower(GameStats.stats.powerDark.id, GameStats.stats.powerDark.Damage);
            mana.ReduceLightMana();

        }

        if (isPoisoned)
        {
            LoseHealth(1, PosionDamageColor.r, PosionDamageColor.g, PosionDamageColor.b, PosionDamageColor.a);
            isPoisoned = false;
            Instantiate(PoisonDamageeffect, transform.position, Quaternion.identity);
        }






    }

    public void Float()
    {

        if (hasPassedThroughRift)
        {
            rb.velocity = Vector3.zero;
            hasPassedThroughRift = false;
        }


        if (GameStats.stats.Rune1 == GameStats.Rune.FloatRune || GameStats.stats.Rune2 == GameStats.Rune.FloatRune)
        {

            rb.AddForce(new Vector2(0, upspeed * Time.deltaTime));
            rb.gravityScale = 0;

            ForceFloat = true;
        }
        else
        {

            rb.AddForce(new Vector2(0, upspeed * Time.deltaTime));
            if (!top)
            {
                rb.gravityScale = 2;
            }
            else
            {
                rb.gravityScale = -2;
            }



            ForceFloat = true;
        }

    }

    public void Fall()
    {
        if (!GameStats.stats.spawnHouse)
        {

            if (!top)
            {
                if (GameStats.stats.Rune1 == GameStats.Rune.FallRune || GameStats.stats.Rune2 == GameStats.Rune.FallRune)
                {
                    ForceFloat = false;
                    rb.gravityScale = 4;
                }
                else
                {
                    ForceFloat = false;
                    rb.gravityScale = 2;

                }

            }
            else
            {
                if (GameStats.stats.Rune1 == GameStats.Rune.FallRune || GameStats.stats.Rune2 == GameStats.Rune.FallRune)
                {
                    rb.gravityScale = -4;
                }
                else
                {

                    rb.gravityScale = -2;
                }

            }

        }
        else
        {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
        }
    }
    public void LoseHealth(int damage = 1, float colorR = 1, float colorG = 1, float colorB = 1, float colorA = 1, bool hit = true, float minSize = 1, float maxSize = 3)
    {
        if (hit)
        {
            Health -= damage;
            animator.SetTrigger("GotHit");
            // StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(0.8f, 0.5f, 0.5f, 1f), 1f, 2f));
            StartCoroutine(GetInvulnerable());
            StartCoroutine(Flashing());
            gameObject.GetComponent<DamageTime>().TimeDamageStop(0.05f, 10, 0.4f);
            FindObjectOfType<AudioManager>().Play("BunnyHit");
        }
        

       
        GameObject myDamageEffect = Instantiate(DamageEffect, transform.position, Quaternion.identity);
        ParticleSystem DamageParticle = myDamageEffect.GetComponent<ParticleSystem>();
        
        var main = DamageParticle.main;

        main.startColor = new Color(colorR, colorG, colorB, colorA);
        



       

    }

    IEnumerator Flashing()
    {
        while (true)
        {
            if (InvulnerableHitActive)
            {
                mySpriteRenderer.color = new Color(0.8f, 0.5f, 0.5f, 0);
                yield return new WaitForSeconds(.1f);
                mySpriteRenderer.color = new Color(0.8f, 0.5f, 0.5f, 1);
                yield return new WaitForSeconds(.1f);
            }
            else
            {
                mySpriteRenderer.color = Color.white;
                break;
            }
        }
    }
    IEnumerator DamageEffectSequence(SpriteRenderer mySpriteRenderer, Color dmgColor, float duration, float delay)
    {
        // save origin color
        // Color originColor = mySpriteRenderer.color;

        // tint the sprite with damage color
        mySpriteRenderer.color = dmgColor;

        // you can delay the animation
        yield return new WaitForSeconds(delay);

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            mySpriteRenderer.color = Color.Lerp(dmgColor, Color.white, t);
        }

        // restore origin color
        //mySpriteRenderer.color = Color.white;
    }


    IEnumerator GetInvulnerable()
    {
        if (!InvulnerableHitActive)
        {
            InvulnerableHitActive = true;
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 15, true);

            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 15, false);
            InvulnerableHitActive = false;
        }



    }

    IEnumerator GetInvulnerableRift()
    {
        if (!invulnerableRiftActive)
        {
            invulnerableRiftActive = true;
            //StartCoroutine(DamageEffectSequence(mySpriteRenderer, new Color(1f, 1f, 1f, 0.5f), 3f, 0.2f));
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 15, true);
            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 15, false);
            yield return new WaitForSeconds(2f);
            invulnerableRiftActive = false;
        }
    }

    IEnumerator GetInvulnerableEndLevel()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 15, true);
        yield return new WaitForSeconds(20f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 15, false);
    }


    IEnumerator GetInvulnerablePower()
    {
        shielded = true;
        yield return new WaitForSeconds(1f);
        ShieldHealthAbsorb = false;
        shielded = false;


    }

    IEnumerator ResetHoldPower()
    {
        yield return new WaitForSeconds(0.5f);



    }
    IEnumerator Death()
    {
        GameObject.Find("UI/Pause Interface/Pause Button").SetActive(false);
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = 0;
        animator.SetTrigger("Dead");
        animator.SetBool("Death", true);
        GameStats.stats.RunInProgress = false;
        GameStats.stats.SaveStats();


        yield return new WaitForSecondsRealtime(1f);



        DeathScreen.SetActive(true);

    }






    public void ResetUsingPower()
    {
        isUsingPower = false;
        animator.SetBool("isUsingPower", false);

    }


    public void UsedPower(int id, float damage)
    {
        switch (id)
        {
            case 1:

                // carrot missle

                animator.SetTrigger("Missile");
                //GameObject carrotT1 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                //carrotT1.transform.position = transform.position + new Vector3(1, 0, 0);
                //CarrotMissile CarrotT1Stats = carrotT1.GetComponent<CarrotMissile>();
                //CarrotT1Stats.Piercing = false;
                //CarrotT1Stats.damage = damage;
                GameObject carrotT1 = myObjectPooler.SpawnFromPool(carrotMissleTag, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                CarrotMissile CarrotT1Stats = carrotT1.GetComponent<CarrotMissile>();
                CarrotT1Stats.Piercing = false;
                CarrotT1Stats.damage = damage;

                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 2:

                // carrot missle

                animator.SetTrigger("Missile");
                //GameObject carrotT2 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                //carrotT2.transform.position = transform.position + new Vector3(1, 0, 0);
                GameObject carrotT2 = myObjectPooler.SpawnFromPool(carrotMissleTag, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                CarrotMissile CarrotT2Stats = carrotT2.GetComponent<CarrotMissile>();
                CarrotT2Stats.Piercing = false;
                CarrotT2Stats.damage = damage;
                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 3:

                // carrot missle

                animator.SetTrigger("Missile");
                //GameObject carrotT3 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                //carrotT3.transform.position = transform.position + new Vector3(1, 0, 0);
                GameObject carrotT3 = myObjectPooler.SpawnFromPool(carrotMissleTag, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                CarrotMissile CarrotT3Stats = carrotT3.GetComponent<CarrotMissile>();
                CarrotT3Stats.Piercing = true;
                CarrotT3Stats.damage = damage;


                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;

            case 4:

                // carrot missle

                animator.SetTrigger("Missile");
                for (int i = 0; i < 2; i++)
                {
                    Vector3 Offset;
                    if (i == 0)
                    {
                        Offset = new Vector3(1, 0.5f, 0);
                    }
                    else
                    {
                        Offset = new Vector3(1, -0.5f, 0);
                    }
                    GameObject carrotT4 = myObjectPooler.SpawnFromPool(carrotMissleTag, transform.position + Offset, Quaternion.identity);
                    CarrotMissile CarrotT4Stats = carrotT4.GetComponent<CarrotMissile>();
                    CarrotT4Stats.Piercing = true;
                    CarrotT4Stats.damage = damage;
                }
                //GameObject carrotT4 = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                //carrotT4.transform.position = transform.position + new Vector3(1, 0.5f, 0);
                //GameObject carrotT4Clone = GameObject.Instantiate(Resources.Load("Prefabs/Carrot Missile") as GameObject);
                //CarrotMissile CarrotT4Stats = carrotT4.GetComponent<CarrotMissile>();
                //CarrotT4Stats.Piercing = true;
                //CarrotT4Stats.damage = damage;
                //CarrotMissile CarrotT4CloneStats = carrotT4Clone.GetComponent<CarrotMissile>();
                //CarrotT4CloneStats.Piercing = true;
                //CarrotT4CloneStats.damage = damage;
                //carrotT4Clone.transform.position = transform.position + new Vector3(1, -0.5f, 0);


                FindObjectOfType<AudioManager>().Play("MagicMissle");
                break;





            case 11:
                // eardefence

                animator.SetTrigger("Defence");
                //GameObject shieldT1 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                //shieldT1.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 12:
                // eardefence

                animator.SetTrigger("Defence");
                //GameObject shieldT2 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                //shieldT2.transform.position = transform.position;
                StartCoroutine(GetInvulnerablePower());
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 13:
                // eardefence

                animator.SetTrigger("Defence");
                // GameObject shieldT3 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                //shieldT3.transform.position = transform.position;
                // Shield ShieldT3stats = shieldT3.GetComponent<Shield>();
                // ShieldT3stats.HealthAbsorb = true;
                ShieldHealthAbsorb = true;
                StartCoroutine(GetInvulnerablePower());
                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;

            case 14:
                // eardefence

                animator.SetTrigger("Defence");
                //GameObject shieldT4 = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
                //shieldT4.transform.position = transform.position;
                //Shield ShieldT4stats = shieldT4.GetComponent<Shield>();
                //ShieldT4stats.HealthAbsorb = true;
                ShieldHealthAbsorb = true;
                StartCoroutine(GetInvulnerablePower());

                FindObjectOfType<AudioManager>().Play("MagicDefence");
                break;




            case 21:
                // radish missile

                animator.SetTrigger("Missile");
                //GameObject radishT1 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT1.transform.position = transform.position + new Vector3(1, 0, 0);
                //RadishMissile RadishT1stats = radishT1.GetComponent<RadishMissile>();
                //RadishT1stats.damage = damage;

                GameObject radishT1 = myObjectPooler.SpawnFromPool(radishMissleTag, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                RadishMissile RadishT1stats = radishT1.GetComponent<RadishMissile>();
                RadishT1stats.damage = damage;
                FindObjectOfType<AudioManager>().Play("RadishMissle");

                break;
            case 22:
                // radish missile

                animator.SetTrigger("Missile");
                //GameObject radishT2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT2.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                //RadishMissile RadishT2stats = radishT2.GetComponent<RadishMissile>();
                //RadishT2stats.damage = damage;
                //GameObject radishT2clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT2clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                //RadishMissile RadishT2statsclone = radishT2clone.GetComponent<RadishMissile>();
                //RadishT2statsclone.damage = damage;

                for (int i = 0; i < 2; i++)
                {
                    Vector3 offset;
                    if (i == 0)
                    {
                        offset = new Vector3(1, 0.3f, 0);
                    }
                    else if (i == 1)
                    {
                        offset = new Vector3(1, -0.3f, 0);
                    }
                    else
                    {
                        offset = Vector3.zero;
                    }
                    GameObject radishT2 = myObjectPooler.SpawnFromPool(radishMissleTag, transform.position + offset, Quaternion.identity);
                    RadishMissile RadishT2stats = radishT2.GetComponent<RadishMissile>();
                    RadishT2stats.damage = damage;
                }
                FindObjectOfType<AudioManager>().Play("RadishMissle");

                break;
            case 23:
                // radish missile

                animator.SetTrigger("Missile");
                //GameObject radishT3 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT3.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                //RadishMissile RadishT3stats = radishT3.GetComponent<RadishMissile>();
                //RadishT3stats.damage = damage;
                //GameObject radishT3clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT3clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                //RadishMissile RadishT3statsclone = radishT3clone.GetComponent<RadishMissile>();
                //RadishT3statsclone.damage = damage;
                //GameObject radishT3clone2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT3clone2.transform.position = transform.position + new Vector3(2, 0, 0);
                //RadishMissile RadishT3statsclone2 = radishT3clone2.GetComponent<RadishMissile>();
                //RadishT3statsclone2.damage = damage;
                for (int i = 0; i < 3; i++)
                {
                    Vector3 offset;
                    if (i == 0)
                    {
                        offset = new Vector3(1, 0.3f, 0);
                    }
                    else if (i == 1)
                    {
                        offset = new Vector3(1, -0.3f, 0);
                    }
                    else if (i == 2)
                    {
                        offset = new Vector3(2, 0, 0);
                    }
                    else
                    {
                        offset = Vector3.zero;
                    }
                    GameObject radishT3 = myObjectPooler.SpawnFromPool(radishMissleTag, transform.position + offset, Quaternion.identity);
                    RadishMissile RadishT3stats = radishT3.GetComponent<RadishMissile>();
                    RadishT3stats.damage = damage;
                }
                FindObjectOfType<AudioManager>().Play("RadishMissle");

                break;
            case 24:
                // radish missile

                animator.SetTrigger("Missile");
                //GameObject radishT4 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT4.transform.position = transform.position + new Vector3(1, 0.3f, 0);
                //RadishMissile RadishT4stats = radishT4.GetComponent<RadishMissile>();
                //RadishT4stats.damage = damage;
                //GameObject radishT4clone = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT4clone.transform.position = transform.position + new Vector3(1, -0.3f, 0);
                //RadishMissile RadishT4statsclone = radishT4clone.GetComponent<RadishMissile>();
                //RadishT4statsclone.damage = damage;
                //GameObject radishT4clone2 = GameObject.Instantiate(Resources.Load("Prefabs/Radish Missile") as GameObject);
                //radishT4clone2.transform.position = transform.position + new Vector3(2, 0, 0);
                //RadishMissile RadishT4statsclone2 = radishT4clone2.GetComponent<RadishMissile>();
                //RadishT4statsclone2.damage = damage;
                for (int i = 0; i < 3; i++)
                {
                    Vector3 offset;
                    if (i == 0)
                    {
                        offset = new Vector3(1, 0.3f, 0);
                    }
                    else if (i == 1)
                    {
                        offset = new Vector3(1, -0.3f, 0);
                    }
                    else if (i == 2)
                    {
                        offset = new Vector3(2, 0, 0);
                    }
                    else
                    {
                        offset = Vector3.zero;
                    }
                    GameObject radishT4 = myObjectPooler.SpawnFromPool(radishMissleTag, transform.position + offset, Quaternion.identity);
                    RadishMissile RadishT4stats = radishT4.GetComponent<RadishMissile>();
                    RadishT4stats.damage = damage;
                }
                FindObjectOfType<AudioManager>().Play("RadishMissle");


                break;
            case 31:
                // kick


                KickObjectTime = maxKickObjectTime;
                animator.SetTrigger("Kick");
                //kickObject.SetActive(true);
                //kickObject.GetComponent<Kick>().reflect = false;

                GameObject kick = myObjectPooler.SpawnFromPool(kickReflectTag, transform.position, Quaternion.identity);
                Kick kickCs = kick.GetComponent<Kick>();
                if(kickCs != null)
                {
                    kickCs.reflect = false;
                    kickCs.deactivateTime = kickCs.deactivateMaxTime;
                }

                //GameObject kickT1 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                //kickT1.transform.position = transform.position;
                //kickT1.name = "Kick";
                //Kick kickT1Stats = kickT1.GetComponent<Kick>();
                //kickT1Stats.reflect = false;
                break;
            case 32:
                // kick

                KickObjectTime = maxKickObjectTime;
                animator.SetTrigger("Kick");
                //kickObject.SetActive(true);
                //kickObject.GetComponent<Kick>().reflect = false;
                GameObject kickT2 = myObjectPooler.SpawnFromPool(kickReflectTag, transform.position, Quaternion.identity);
                Kick kickCsT2 = kickT2.GetComponent<Kick>();
                if (kickCsT2 != null)
                {

                    kickCsT2.reflect = false;
                    kickCsT2.deactivateTime = kickCsT2.deactivateMaxTime;
                }
                //GameObject kickT2 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                //kickT2.transform.position = transform.position;
                //kickT2.name = "Kick";
                //Kick kickT2Stats = kickT2.GetComponent<Kick>();
                //kickT2Stats.reflect = false;
                break;
            case 33:
                // kick

                KickObjectTime = maxKickObjectTime;
                animator.SetTrigger("Kick");
                //kickObject.SetActive(true);
                //kickObject.GetComponent<Kick>().reflect = true;
                GameObject kickT3 = myObjectPooler.SpawnFromPool(kickReflectTag, transform.position, Quaternion.identity);
                Kick kickCsT3 = kickT3.GetComponent<Kick>();
                if (kickCsT3 != null)
                {
                    kickCsT3.reflect = true;
                    kickCsT3.deactivateTime = kickCsT3.deactivateMaxTime;
                }
                //GameObject kickT3 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                //kickT3.transform.position = transform.position;
                //kickT3.name = "Kick";
                //Kick kickT3Stats = kickT3.GetComponent<Kick>();
                //kickT3Stats.reflect = true;
                break;
            case 34:
                // kick
                KickObjectTime = maxKickObjectTime;
                animator.SetTrigger("Kick");
                //kickObject.SetActive(true);
                //kickObject.GetComponent<Kick>().reflect = true;
                GameObject kickT4 = myObjectPooler.SpawnFromPool(kickReflectTag, transform.position, Quaternion.identity);
                Kick kickCsT4 = kickT4.GetComponent<Kick>();
                if (kickCsT4 != null)
                {
                    kickCsT4.reflect = true;
                    kickCsT4.deactivateTime = kickCsT4.deactivateMaxTime;
                }
                //GameObject kickT4 = GameObject.Instantiate(Resources.Load("Prefabs/Kick") as GameObject);
                // kickT4.transform.position = transform.position;
                // kickT4.name = "Kick";
                // Kick kickT4Stats = kickT4.GetComponent<Kick>();
                // kickT4Stats.reflect = true;
                break;

            case 41:

                break;

            case 51:

                if (HoldPower == true)
                {
                    if (!LaserSFXPlaying)
                    {
                        LaserSFX.Play();
                        LaserSFXPlaying = true;
                    }
                    
                    int layerMask = 1 << 9;
                    LaserlayerMask = layerMask;

                    //animator.SetBool("Laser", true);

                    if (isUsinglaserLight == true)
                    {

                        LaserLight.SetPosition(0, StartLaserPos.position);
                        LaserLight.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXLight.transform.position = LaserLight.GetPosition(1);

                        // Debug.Log("using  hold power light");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXLight.GetComponent<ParticleSystem>().Play();
                        EndVFXLight.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {

                            LaserLight.SetPosition(1, hit.point);
                            EndVFXLight.transform.position = LaserLight.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(GameStats.stats.powerLight.Damage);
                                }
                            }
                        }



                    }
                    else
                    {

                        LaserDark.SetPosition(0, StartLaserPos.position);
                        LaserDark.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXDark.transform.position = LaserDark.GetPosition(1);

                        
                        // Debug.Log("using  hold power dark");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXDark.GetComponent<ParticleSystem>().Play();
                        EndVFXDark.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserDark.SetPosition(1, hit.point);
                            EndVFXDark.transform.position = LaserDark.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(GameStats.stats.powerDark.Damage);
                                }
                            }
                        }
                    }
                }
                
                /*else if (HoldPower == false)
                {
                    animator.SetBool("Laser", false);
                    
                        LaserLight.enabled = false;

                    startVFX.GetComponent<ParticleSystem>().Stop();
                    endVFX.GetComponent<ParticleSystem>().Stop();

                }
                */

                break;


            case 52:

                if (HoldPower == true)
                {
                    if (!LaserSFXPlaying)
                    {
                        LaserSFX.Play();
                        LaserSFXPlaying = true;
                    }
                    int layerMask = 1 << 9;
                    LaserlayerMask = layerMask;

                    animator.SetBool("Laser", true);

                    if (isUsinglaserLight == true)
                    {

                        LaserLight.SetPosition(0, StartLaserPos.position);
                        LaserLight.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXLight.transform.position = LaserLight.GetPosition(1);

                        // Debug.Log("using  hold power light");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXLight.GetComponent<ParticleSystem>().Play();
                        EndVFXLight.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserLight.SetPosition(1, hit.point);
                            EndVFXLight.transform.position = LaserLight.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(GameStats.stats.powerLight.Damage);
                                }
                            }
                        }



                    }
                    else
                    {

                        LaserDark.SetPosition(0, StartLaserPos.position);
                        LaserDark.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXDark.transform.position = LaserDark.GetPosition(1);

                        //Debug.Log("using  hold power dark");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXDark.GetComponent<ParticleSystem>().Play();
                        EndVFXDark.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserDark.SetPosition(1, hit.point);
                            EndVFXDark.transform.position = LaserDark.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(GameStats.stats.powerDark.Damage);
                                }
                            }
                        }
                    }
                }
                break;

            case 53:


                if (HoldPower == true)
                {
                    if (!LaserSFXPlaying)
                    {
                        LaserSFX.Play();
                        LaserSFXPlaying = true;
                    }
                    int layerMask1 = 1 << 9;
                    // int layerMask2 = 1 << 15;

                    int CombiendLayerMask = layerMask1; //| layerMask2;
                    LaserlayerMask = CombiendLayerMask;

                    animator.SetBool("Laser", true);

                    if (isUsinglaserLight == true)
                    {

                        LaserLight.SetPosition(0, StartLaserPos.position);
                        LaserLight.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXLight.transform.position = LaserLight.GetPosition(1);

                        Debug.Log("using  hold power light");

                        StartVFXLight.GetComponent<ParticleSystem>().Play();
                        EndVFXLight.GetComponent<ParticleSystem>().Play();


                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);


                        if (hit.collider != null)
                        {
                            if (hit.transform.tag != "EnemyProyectile")
                            {
                                LaserLight.SetPosition(1, hit.point);
                                EndVFXLight.transform.position = LaserLight.GetPosition(1);
                            }

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(GameStats.stats.powerLight.Damage);
                                }
                                LaserTimeCall = Time.time;
                            }
                        }
                    }

                    else
                    {

                        LaserDark.SetPosition(0, StartLaserPos.position);
                        LaserDark.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXDark.transform.position = LaserDark.GetPosition(1);

                        Debug.Log("using  hold power dark");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXDark.GetComponent<ParticleSystem>().Play();
                        EndVFXDark.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserDark.SetPosition(1, hit.point);
                            EndVFXDark.transform.position = LaserDark.GetPosition(1);


                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(Mathf.FloorToInt(GameStats.stats.powerDark.Damage));
                                }
                            }

                        }
                    }
                }


                break;
            case 54:

                if (HoldPower == true)
                {
                    if (!LaserSFXPlaying)
                    {
                        LaserSFX.Play();
                        LaserSFXPlaying = true;
                    }
                    int layerMask1 = 1 << 9;
                    //int layerMask2 = 1 << 15;

                    int CombiendLayerMask = layerMask1; //| layerMask2;
                    LaserlayerMask = CombiendLayerMask;

                    animator.SetBool("Laser", true);

                    if (isUsinglaserLight == true)
                    {

                        LaserLight.SetPosition(0, StartLaserPos.position);
                        LaserLight.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXLight.transform.position = LaserLight.GetPosition(1);

                        Debug.Log("using  hold power light");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXLight.GetComponent<ParticleSystem>().Play();
                        EndVFXLight.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserLight.SetPosition(1, hit.point);
                            EndVFXLight.transform.position = LaserLight.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(Mathf.FloorToInt(GameStats.stats.powerLight.Damage));
                                }
                            }
                        }
                    }
                    else
                    {

                        LaserDark.SetPosition(0, StartLaserPos.position);
                        LaserDark.SetPosition(1, StartLaserPos.position + new Vector3(15, 0, 0));
                        EndVFXDark.transform.position = LaserDark.GetPosition(1);

                        Debug.Log("using  hold power dark");

                        Vector2 direction = StartLaserPos.position + new Vector3(15, 0, 0) - StartLaserPos.position;
                        RaycastHit2D hit = Physics2D.Raycast((Vector2)StartLaserPos.position, direction.normalized, direction.magnitude, LaserlayerMask);

                        StartVFXDark.GetComponent<ParticleSystem>().Play();
                        EndVFXDark.GetComponent<ParticleSystem>().Play();

                        if (hit.collider != null)
                        {
                            LaserDark.SetPosition(1, hit.point);
                            EndVFXDark.transform.position = LaserDark.GetPosition(1);

                            if (Time.time - LaserTimeCall >= 0.1)
                            {
                                if (hit.transform.tag == "Enemy")
                                {
                                    EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
                                    target.TakeDamage(Mathf.FloorToInt(GameStats.stats.powerDark.Damage));
                                }
                            }

                        }
                    }
                }

                break;


            default:
                print("spell error");
                break;
        }
    }



}


