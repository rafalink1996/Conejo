using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGameManager : MonoBehaviour
{

    public TextMeshProUGUI Crystalcounter;
    public float Crystals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Crystals = GameStats.stats.crystals;
        Crystalcounter.text = Crystals.ToString(); 
    }
}
