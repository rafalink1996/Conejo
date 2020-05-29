using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Power")]
public class Power : ScriptableObject
{
    new public string name = "new Item";
    public Sprite iconLight = null;
    public Sprite iconDark = null;
    public float mana;
    public string description;
    public int id;
    public int Cost;






    //public bool isDefaultItem = false;



}
