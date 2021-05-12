using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Power")]
public class Power : ScriptableObject
{
    new public string name = "new Item";
    public string Español_Name;

    public Sprite iconLight = null;
    public Sprite iconDark = null;
    public float mana;
    public int Damage;
    public string description;
    public string Español_Description;
    public int id;
    public int Cost;

    public bool Piercing;
    public bool HealthAbsorb;
    public bool DoubleCast;

    public Sprite RarityDisplay;
    public int Rarity;
    public Color rarityColor;
    






    //public bool isDefaultItem = false;



}
