using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGriffin : MonoBehaviour
{
    public GameObject rayAttack;
    public GameObject silenceTop;
    public GameObject silenceBot;
    public bool bossTop;
    public bool silence;
    EnemyHealth health;
    public GameObject[] healthBar;
    public bool BossDead;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.maxHealth = 100;
        BossDead = false;
        GameStats.stats.bossDead = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            bossTop = false;
        }
        else
        {
            bossTop = true;
        }
        if (health.health <= 0 && !BossDead)
        {
            anim.SetTrigger("Despawn");
            BossDead = true;
            GameStats.stats.bossDead = true;
        }
    }
    void RayAttack()
    {
        FindObjectOfType<AudioManager>().Play("ClockworkGrififnLaser");
        rayAttack.SetActive(true);
        
        health.TakeDamage(1);
    }
    void ShootOne()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-1.87f, -0.55f, 0);
        //energyBall.transform.SetParent(null);
        energyBall.transform.rotation = Quaternion.AngleAxis(12.46f, Vector3.forward);
        
        health.TakeDamage(1);
    }
    void ShootTwo()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-2.16f, 0.06f, 0);
        //energyBall.transform.SetParent(null);
        //energyBall.transform.GetChild(0).rotation = Quaternion.AngleAxis(12.46f, Vector3.forward);
        health.TakeDamage(1);

    }
    void ShootThree()
    {
        GameObject energyBall = Instantiate(Resources.Load("Prefabs/EnergyBall") as GameObject);
        //energyBall.transform.SetParent(transform);
        energyBall.transform.position = transform.position + new Vector3(-2.21f, 1.2f, 0);
        //energyBall.transform.SetParent(null);
        energyBall.transform.rotation = Quaternion.AngleAxis(-13.678f, Vector3.forward);
        health.TakeDamage(1);
    }
    void Silence()
    {
        if (!bossTop)
        {
            silenceTop.SetActive(true);
        }
        else
        {
            silenceBot.SetActive(true);
        }
        FindObjectOfType<AudioManager>().Play("ClockworkGrififnSilence");
        silence = true;
        health.TakeDamage(1);
        Invoke("DeactivateSilence", 10f);
    }
    void DeactivateSilence()
    {
        FindObjectOfType<AudioManager>().Play("ClockworkGrififnSilenceOff");
        silenceTop.SetActive(false);
        silenceBot.SetActive(false);
        silence = false;
    }
    void DeactivateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        healthBar[0].SetActive(false);
        healthBar[1].SetActive(false);
        healthBar[2].SetActive(false);
    }
    void ActivateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        healthBar[0].SetActive(true);
        healthBar[1].SetActive(true);
        healthBar[2].SetActive(true);
    }
    public void Death()
    {
        if (BossDead)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
