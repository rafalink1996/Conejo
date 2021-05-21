using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Slider healthSlider;
    public bool Hit;
    public bool CanSpawnHeal;
    float hitTime;
    [SerializeField] float MaxHitTime = 6;
    public bool isBoss = false;

    public bool MoneyBag = false;
    [SerializeField] GameObject EnemyMoneyPrefab = null;

    
    void Start()
    {
        //print("start");
        hitTime = MaxHitTime;
        Hit = false;
        healthSlider = transform.Find("Canvas/Slider").GetComponent<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        if(GameStats.stats.Rune1 == GameStats.Rune.DestructionRune || GameStats.stats.Rune2 == GameStats.Rune.DestructionRune)
        {
           if (!isBoss)
            {
                health = maxHealth * 0.75f;
            }
        }

    }

    
    void Update()
    {
        if (Hit)
        {
            if (MoneyBag)
            {
                SpawnCoins();
            }
           
            CanSpawnHeal = true;
            Hit = false;
            hitTime = MaxHitTime;

        }
        healthSlider.value = health;

        if (CanSpawnHeal)
        {
            hitTime -= Time.deltaTime;
        }
        if (hitTime <= 0 && Hit)
        {
            CanSpawnHeal = false;
            hitTime = MaxHitTime;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

    }

    void SpawnCoins()
    {
        if(EnemyMoneyPrefab != null)
        {
            Instantiate(EnemyMoneyPrefab, transform.position, Quaternion.identity);
        }
    }
}
