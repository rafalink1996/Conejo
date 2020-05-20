using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats stats;
    public string lightPowerName;
    public Sprite lightPowerSprite;
    public string darkPowerName;
    public Sprite darkPowerSprite;
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
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
