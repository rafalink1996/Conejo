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
    [SerializeField] RuneSystem myRuneSystem;
    [SerializeField] AchivmentsMenu myAchivmentsMenu;
    [SerializeField] SkinMenuStore mySkinMenuStore;



    [SerializeField] GameObject myPlayfabMenu;

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

        if(GameStats.stats.loginFinalized != true)
        {
            if(myPlayfabMenu != null)
            {
                myPlayfabMenu.SetActive(true);
            }
        }
        else
        {
            if (myPlayfabMenu != null)
            {
                myPlayfabMenu.SetActive(false);
            }
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
        myRuneSystem.DelayedStart();
        myAchivmentsMenu.DelayedStart();
        mySkinMenuStore.DelayedStart();
    }
}
