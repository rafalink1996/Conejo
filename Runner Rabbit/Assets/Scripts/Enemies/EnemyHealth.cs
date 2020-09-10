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
    public float hitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        Hit = false;
        healthSlider = transform.Find("Canvas/Slider").GetComponent<Slider>();
        health = maxHealth;
        healthSlider.maxValue = maxHealth;

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
            hitTime = 1f;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
       
    }
}
