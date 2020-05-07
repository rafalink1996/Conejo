using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaHandle : MonoBehaviour
{

    public Slider DarkManaBar;
    public Slider LightManaBar;

    public float DarkMana;
    public float LightMana;

    public float DarkManaUsed;
    public float LightManaUsed;

    public float DarkManaRegen;
    public float LightManaRegen;

    public float CurrentDarkMana;
    public float CurrentLightMana;

    private character Cha;




    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();


        CurrentDarkMana = DarkMana;
        CurrentLightMana = LightMana;
    }

    // Update is called once per frame
    void Update()
    {
        DarkManaBar.value = CurrentDarkMana;
        LightManaBar.value = CurrentLightMana;
        if (CurrentDarkMana < DarkMana && Cha.top == true)
        {
            CurrentDarkMana = Mathf.MoveTowards(DarkManaBar.value, DarkManaBar.maxValue, Time.deltaTime * DarkManaRegen);
            // CurrentDarkMana = Mathf.MoveTowards(CurrentDarkMana / DarkMana, 1f, Time.deltaTime * 0.1f) * DarkMana;
        }

        if (CurrentDarkMana < 0)
        {
            CurrentDarkMana = 0;
        }

        if (CurrentLightMana < LightMana && Cha.top == false)
        {
            CurrentLightMana = Mathf.MoveTowards(LightManaBar.value, LightManaBar.maxValue, Time.deltaTime * LightManaRegen);
            // CurrentDarkMana = Mathf.MoveTowards(CurrentDarkMana / DarkMana, 1f, Time.deltaTime * 0.1f) * DarkMana;
        }

        if (CurrentLightMana < 0)
        {
            CurrentLightMana = 0;
        }
    }
    public void RequiredDarkMana (float DarkManaRequired)
    {
        DarkManaUsed = DarkManaRequired;
    }
    public void RequiredLightMana(float LightManaRequired)
    {
        LightManaUsed = LightManaRequired;
    }
    public void ReduceDarkMana()

    {
        
        CurrentDarkMana -= DarkManaUsed;
        DarkManaBar.value -= DarkManaUsed;


    }

    public void ReduceLightMana()

    {
        
        CurrentLightMana -= LightManaUsed;
        LightManaBar.value -= LightManaUsed;

    }
}
