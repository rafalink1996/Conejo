using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Text.RegularExpressions;

public class PlayFabData : MonoBehaviour
{
    public static PlayFabData PFD;

    [Space(10)]
    [Header ("initialization Scripts")]
    [SerializeField] MenuGameManager myMenuGameManager;

    [Space (10)]
    [Header ("Data to save")]
    public int levelReached;
    public int crystals;
    public bool noAdsBought;
    public bool[] skinsConditions;
    public bool[] achievmentsUnlocked;
    public bool[] unlockedRunes;

    [Space(5)]
    public int carrotMissleLevel;
    public int earDefenceLevel;
    public int kickReflectLevel;
    public int radishMissleLevel;
    public int magicLaserLevel;
    

    public string myPlayfabID;
    public bool HasSavedData;
    public bool CantAccessData;

    [Space(10)]
    [Header("Data to save")]
    public bool errorRetrievingData;
    private int getUserDataRetry;


    private void Awake()
    {
        if (PlayFabData.PFD == null)
        {
            PlayFabData.PFD = this;
        }
        else
        {
            if (PlayFabData.PFD != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveStats()
    {
        CheckStats();
        DebugStats();
        SendStats();
    }

    public void LoadStats()
    {
        PlayfabGetUserData();
        
    }




    private void CheckStats()
    {
        levelReached = GameStats.stats.LevelReached;
        crystals = Mathf.FloorToInt(GameStats.stats.crystals);
        noAdsBought = GameStats.stats.NoAdsBought;
        skinsConditions = GameStats.stats.skinConditions;
        achievmentsUnlocked = GameStats.stats.AchivementConditions;

        carrotMissleLevel = GameStats.stats.CarrotMissleLevel;
        earDefenceLevel = GameStats.stats.EarDefenceLevel;
        kickReflectLevel = GameStats.stats.KickReflectLevel;
        radishMissleLevel = GameStats.stats.RadishMissleLevel;
        magicLaserLevel = GameStats.stats.MagicLaserLevel;

        unlockedRunes = GameStats.stats.UnlockedRunes;
    }

    private void AsignLoadedStats()
    {
        
        GameStats.stats.crystals = crystals;
        GameStats.stats.LevelReached = levelReached;
        GameStats.stats.NoAdsBought = noAdsBought;
        GameStats.stats.skinConditions = skinsConditions;
        GameStats.stats.AchivementConditions = achievmentsUnlocked;
        GameStats.stats.UnlockedRunes = unlockedRunes;

        GameStats.stats.CarrotMissleLevel = carrotMissleLevel;
        GameStats.stats.EarDefenceLevel = earDefenceLevel;
        GameStats.stats.KickReflectLevel = kickReflectLevel;
        GameStats.stats.RadishMissleLevel = radishMissleLevel;
        GameStats.stats.MagicLaserLevel = magicLaserLevel;

        Debug.Log("Data asigned To game stats");
        GameStats.stats.myGamestatsSaveManager.DataLoaded = true;
        StartDataDependentScripts();
    }



    private void DebugStats()
    {

        Debug.Log("saved stats:");
        Debug.Log("Crystals: " + IntDataToString(crystals));
        Debug.Log("LevelReached: " + IntDataToString(levelReached));
        Debug.Log("No Ads Bought: " + BoolDataToString(noAdsBought));
        Debug.Log("skinConditions: " + BoolArrayDataToString(skinsConditions));
        Debug.Log("Achievments Unlocked: " + BoolArrayDataToString(achievmentsUnlocked));
        Debug.Log("Power levels: " + PowerLevelDataToString());
        Debug.Log("Runes unlocked: " + BoolArrayDataToString(unlockedRunes));
    }

    #region Send Data to Playfab
    private void SendStats()
    {
        var UpdateDataRequest = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "crystals", IntDataToString(crystals) },
                { "Level Reached", IntDataToString(levelReached) },
                { "No ads bought", BoolDataToString(noAdsBought) },
                { "Skin Conditions", BoolArrayDataToString(skinsConditions) },
                { "Achievments Unlocked", BoolArrayDataToString(achievmentsUnlocked) },
                { "Power Levels", PowerLevelDataToString()},
                { "Runes Unlocked", BoolArrayDataToString(unlockedRunes) },
            }
        };
        PlayFabClientAPI.UpdateUserData(UpdateDataRequest, OnDataSend, OnDataSendError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("succsesfully user data send!");
    }
    void OnDataSendError(PlayFabError error)
    {
        Debug.Log("Failed user Data send");
        Debug.Log("Error: " + error.GenerateErrorReport());
    }
   

    

    #endregion Send Data to Playfab
    #region Recieve data from Playfab

    private void PlayfabGetUserData()
    {
        
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
           
            PlayFabId = myPlayfabID,
            Keys = null

        }, OnDataRetrieved, OnDataRecieveError);
    }

    void OnDataRetrieved(GetUserDataResult result)
    {
        Debug.Log("succsesfully user data retrieved!");
        if (result.Data != null)
        {
            HasSavedData = true;
            if (!result.Data.ContainsKey("crystals"))
            {
                Debug.Log("no Crystals Cloud save Set");
            }
            else
            {
                crystals = IntDataFromString(result.Data["crystals"].Value);
            }

            if (!result.Data.ContainsKey("Level Reached"))
            {
                Debug.Log("no Level Reached Cloud save Set");
            }
            else
            {
                levelReached = IntDataFromString(result.Data["Level Reached"].Value);
            }

            if (!result.Data.ContainsKey("No ads bought"))
            {
                Debug.Log("no No ads bought Cloud save Set");
            }
            else
            {
                noAdsBought = BoolDataFromString(result.Data["No ads bought"].Value);
            }

            if (!result.Data.ContainsKey("Skin Conditions"))
            {
                Debug.Log("no Skin Conditions Cloud save Set");
            }
            else
            {
                skinsConditions = BoolArrayFromString(result.Data["Skin Conditions"].Value);
            }

            if (!result.Data.ContainsKey("Achievments Unlocked"))
            {
                Debug.Log("no Achievments Unlocked Cloud save Set");
            }
            else
            {
                achievmentsUnlocked = BoolArrayFromString(result.Data["Achievments Unlocked"].Value);
            }

            if (!result.Data.ContainsKey("Power Levels"))
            {
                Debug.Log("no Power Levels Cloud save Set");
            }
            else
            {
              PowerLevelDataFromString(result.Data["Power Levels"].Value);
            }

            if (!result.Data.ContainsKey("Runes Unlocked"))
            {
                Debug.Log("no Runes Unlocked Cloud save Set");
            }
            else
            {
               unlockedRunes = BoolArrayFromString(result.Data["Runes Unlocked"].Value);
            }

            if (GameStats.stats.myGamestatsSaveManager.NoLocalSaveDetected)
            {
                AsignLoadedStats();
            }
        }
        else
        {
            Debug.Log("user data is null");
        }   
       
    }

    void OnDataRecieveError(PlayFabError error)
    {
        Debug.Log("Failed user Data send");
        Debug.Log("Error: " + error.GenerateErrorReport());

        switch (error.Error)
        {
            case PlayFabErrorCode.ConnectionError:
                // Tell player there is a conecction issue
                break;
        }

        if(getUserDataRetry < 3)
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest()
            {

                PlayFabId = myPlayfabID,
                Keys = null

            }, OnDataRetrieved, OnDataRecieveError);
        }
        errorRetrievingData = true;
    }


    #endregion Recieve data from Playfab


    #region Set values to string
    private string IntDataToString(int Data)
    {
        string toString = Data.ToString();
        return toString;
    }
    private string BoolDataToString(bool Data)
    {
        string toString = "";
        if (Data == true)
        {
            toString = "1";
        }
        else
        {
            toString = "0";
        }
        return toString;
    }

    private string BoolArrayDataToString(bool[] Data)
    {
        string toString = "";

        for (int i = 0; i < Data.Length; i++)
        {
            if (Data[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }

        return toString;
    }

    private string PowerLevelDataToString()
    {
        string toString = "";

        toString += "Carrot Missle: " + carrotMissleLevel.ToString() + ", ";
        toString += "Ear Defence: " + earDefenceLevel.ToString() + ", ";
        toString += "Kick Reflect: " + kickReflectLevel.ToString() + ", ";
        toString += "Radish Missle: " + radishMissleLevel.ToString() + ", ";
        toString += "Magic Laser: " + magicLaserLevel.ToString();




        return toString;
    }

    #endregion Set values to string
    #region Set Values From String


    private void PowerLevelDataFromString(string data)
    {
        string[] Digits = Regex.Split(data, @"\D+");
        int assignedPower = 0;
        foreach (string value in Digits)
        {
            int Number;
            if (int.TryParse(value, out Number))
            {
                if (assignedPower == 0)
                {
                    carrotMissleLevel = int.Parse(value);
                    //Debug.Log("Carrot level is: " + value);
                }
                if (assignedPower == 1)
                {
                    earDefenceLevel = int.Parse(value);
                    //Debug.Log("Shield level is: " + value);
                }
                if (assignedPower == 2)
                {
                    kickReflectLevel = int.Parse(value);
                    //Debug.Log("Kick level is: " + value);
                }
                if (assignedPower == 3)
                {
                    radishMissleLevel = int.Parse(value);
                    //Debug.Log("Radish level is: " + value);
                }
                if (assignedPower == 4)
                {
                    magicLaserLevel = int.Parse(value);
                    //Debug.Log("Laser level is: " + value);
                }
                assignedPower++;
            }
        }

    }
    private int IntDataFromString(string data)
    {
        int ReturnData = int.Parse(data);
        return ReturnData;
    }
    private bool BoolDataFromString(string data)
    {
        bool ReturnData;
        if (data == "1")
        {
            ReturnData = true;
        }
        else
        {
            ReturnData = false;
        }
        return ReturnData;
    }

    private bool[] BoolArrayFromString(string data)
    {
        bool[] returnData = new bool[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            if (int.Parse(data[i].ToString()) > 0)
            {
                returnData[i] = true;
            }
            else
            {
                returnData[i] = false;
            }
        }
        return returnData;
    }


    #endregion Set Values From String


    void StartDataDependentScripts()
    {
        myMenuGameManager.StartDataRelatedScripts();
    }
}
