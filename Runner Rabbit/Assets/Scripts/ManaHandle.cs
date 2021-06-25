using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public character Cha;

    public TextMeshProUGUI LightManaQuantityDisplay;
    public TextMeshProUGUI DarkManaQuantityDisplay;




    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();


       

        DarkMana = GameStats.stats.totalDarkMana;
        LightMana = GameStats.stats.totalLightMana;

        DarkManaBar.maxValue = GameStats.stats.totalDarkMana;
        LightManaBar.maxValue = GameStats.stats.totalLightMana;

        CurrentDarkMana = DarkMana;
        CurrentLightMana = LightMana;

        //codigo extra para ver si se arregla lo del mana

        DarkManaUsed = GameStats.stats.powerDark.mana;
        LightManaUsed = GameStats.stats.powerLight.mana;

        LightManaQuantityDisplay.text = Mathf.FloorToInt(CurrentLightMana).ToString();
        DarkManaQuantityDisplay.text = Mathf.FloorToInt(CurrentDarkMana).ToString();
    }

    // Update is called once per frame
    void Update()
    {

       

        DarkManaBar.value = CurrentDarkMana;
        LightManaBar.value = CurrentLightMana;

        if (CurrentDarkMana < DarkMana && Cha.top == true && Cha.holdPowerLight == false)
        {
            if (GameStats.stats.Rune1 == GameStats.Rune.ManaRune || GameStats.stats.Rune2 == GameStats.Rune.ManaRune)
            {
                CurrentDarkMana = Mathf.MoveTowards(DarkManaBar.value, DarkManaBar.maxValue, Time.deltaTime * (DarkManaRegen * 2));
            }
            else
            {
                CurrentDarkMana = Mathf.MoveTowards(DarkManaBar.value, DarkManaBar.maxValue, Time.deltaTime * DarkManaRegen);
            }
                
            // CurrentDarkMana = Mathf.MoveTowards(CurrentDarkMana / DarkMana, 1f, Time.deltaTime * 0.1f) * DarkMana;
        }

        if (CurrentDarkMana < 0)
        {
            CurrentDarkMana = 0;
        }

        if (CurrentLightMana < LightMana && Cha.top == false && Cha.holdPowerDark == false)
        {
            if (GameStats.stats.Rune1 == GameStats.Rune.ManaRune || GameStats.stats.Rune2 == GameStats.Rune.ManaRune)
            {
                CurrentLightMana = Mathf.MoveTowards(LightManaBar.value, LightManaBar.maxValue, Time.deltaTime * (LightManaRegen * 2));
            }
            else
            {
                CurrentLightMana = Mathf.MoveTowards(LightManaBar.value, LightManaBar.maxValue, Time.deltaTime * LightManaRegen);
            }  
            // CurrentDarkMana = Mathf.MoveTowards(CurrentDarkMana / DarkMana, 1f, Time.deltaTime * 0.1f) * DarkMana;
        }

        if (CurrentLightMana < 0)
        {
            CurrentLightMana = 0;
        }

        LightManaQuantityDisplay.text = Mathf.FloorToInt(CurrentLightMana).ToString();
        DarkManaQuantityDisplay.text = Mathf.FloorToInt(CurrentDarkMana).ToString();
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
        if (GameStats.stats.Rune1 == GameStats.Rune.SpellRune || GameStats.stats.Rune2 == GameStats.Rune.SpellRune)
        {
            CurrentDarkMana -= (DarkManaUsed * (1 / 4));
            DarkManaBar.value -= (DarkManaUsed * (1 / 4));
        }
        else
        {
            CurrentDarkMana -= DarkManaUsed;
            DarkManaBar.value -= DarkManaUsed;
        }
        
     


    }

    public void ReduceDarkManaHold()
    {
        if (GameStats.stats.Rune1 == GameStats.Rune.SpellRune || GameStats.stats.Rune2 == GameStats.Rune.SpellRune)
        {
            CurrentDarkMana -= (DarkManaUsed * (1 / 4)) * Time.deltaTime;
            DarkManaBar.value -= (DarkManaUsed * (1 / 4))* Time.deltaTime;
        }
        else
        {
            CurrentDarkMana -= DarkManaUsed * Time.deltaTime;
            DarkManaBar.value -= DarkManaUsed * Time.deltaTime;
        }
    }

    public void ReduceLightMana()

    {
        if (GameStats.stats.Rune1 == GameStats.Rune.SpellRune || GameStats.stats.Rune2 == GameStats.Rune.SpellRune)
        {
            CurrentLightMana -= (LightManaUsed * (1 / 4));
            LightManaBar.value -= (LightManaUsed * (1 / 4));
        }
        else
        {
            CurrentLightMana -= LightManaUsed;
            LightManaBar.value -= LightManaUsed;
        }
       
        

    }

    public void ReduceLightManaHold()
    {

        if (GameStats.stats.Rune1 == GameStats.Rune.SpellRune || GameStats.stats.Rune2 == GameStats.Rune.SpellRune)
        {
            CurrentLightMana -= (LightManaUsed * (1 / 4)) * Time.deltaTime;
            LightManaBar.value -= (LightManaUsed * (1 / 4)) * Time.deltaTime;
        }
        else
        {
            CurrentLightMana -= LightManaUsed * Time.deltaTime;
            LightManaBar.value -= LightManaUsed * Time.deltaTime;
        }
    }
}
