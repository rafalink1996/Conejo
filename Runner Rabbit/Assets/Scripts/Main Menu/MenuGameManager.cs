using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGameManager : MonoBehaviour
{

    public TextMeshProUGUI Crystalcounter;
    public TextMeshProUGUI CrystalcounterRune;
    public float Crystals;
    
    public GameObject InitialSelectLanguage;

    [SerializeField] LanguageManager myLanguageManager;
    [SerializeField] PowerMEnu myPowerMenuStore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (GameStats.stats.languageselected)
        {
            InitialSelectLanguage.SetActive(false);
        } else
        {
            InitialSelectLanguage.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Crystals = GameStats.stats.crystals;
        Crystalcounter.text = Crystals.ToString();
        CrystalcounterRune.text = Crystals.ToString();
    }

    public void closelanguageSelect()
    {
        InitialSelectLanguage.SetActive(false);
    }

    public void StartDataRelatedScripts()
    {
        Debug.Log("this should be triggering");
        if (GameStats.stats.languageselected)
        {
            InitialSelectLanguage.SetActive(false);
        }
        else
        {
            InitialSelectLanguage.SetActive(true);
        }
        myLanguageManager.DelayedStart();
        myPowerMenuStore.DelayedStart();
    }
}
