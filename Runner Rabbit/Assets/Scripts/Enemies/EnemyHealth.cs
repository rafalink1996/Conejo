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
    public float hitTime = 6f;
    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
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

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if (Hit)
        {
            hitTime -= Time.deltaTime;
        }
        if (hitTime <= 0 && Hit)
        {
            Hit = false;
            hitTime = 6f;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }
}
