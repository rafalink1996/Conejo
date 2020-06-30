using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Slider healthSlider;
    public bool Hit;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponentInChildren<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        Hit = false;

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
       
    }
}
