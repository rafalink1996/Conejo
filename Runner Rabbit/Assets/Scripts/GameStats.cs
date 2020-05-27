using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public Power powerdark;
    public Power powerLight;

    public static GameStats stats;
    public string lightPowerName;
    public Sprite lightPowerSprite;
    public int lightpowerID;
    public string darkPowerName;
    public Sprite darkPowerSprite;
    public int DarkpowerID;
    public float coins;
    public int numOfHearts;
    //public Power lightPower;
    //public Power darkPower;
    // Start is called before the first frame update
    void Awake()
    {
        if (stats == null)
        {
            DontDestroyOnLoad(gameObject);
            stats = this;
        }
        else if (stats != this)
        {
            Destroy(gameObject);
        }
    }
        void Start()
    {
        lightPowerName = powerLight.name;
        lightPowerSprite = powerLight.iconLight;
        lightpowerID = powerLight.id;

        darkPowerName = powerdark.name;
        darkPowerSprite = powerdark.iconDark;
        DarkpowerID = powerdark.id;



    }

   
}
