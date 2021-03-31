using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider LoadingSlider;
    public GameObject EndLevelAnimation;
    public Animator transition;

    public GameObject EnemySpawner1;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawner3;
    public GameObject EnemySpawner4;
    public GameObject EnemySpawnerHand;

    public GameObject Background;

    public HouseSpawner EndlessHosue;
    public character cha;
    public GameObject character;
    //public BossWyrm bossWyrm;

    public float transitiontime;
    public float levelTime;
    public float levelcountdown;

   

    public Slider TimerSlider;
    bool timeOver = false;

    public backgroundLoop backgroundLoopScript;

    // Start is called before the first frame update
    void Start()
    {

        Resources.UnloadUnusedAssets();

        GameStats.stats.isInStore = false;

        if (GameStats.stats.LevelCount == 1)
        {
            levelTime = 50 + (10* (GameStats.stats.LevelIndicator));

        }

        if (GameStats.stats.LevelCount > 1)
        {
            levelTime = 100 + (10 * (GameStats.stats.LevelIndicator));
        }

        if (GameStats.stats.LevelCount == 3)
        {
            TimerSlider.gameObject.SetActive(false);
        }

       
        StartCoroutine(loadloader());


        if (GameStats.stats.RunInProgress == true)
        {
            levelcountdown = GameStats.stats.SavedLevelPercentage;
            cha.SetSavedStats();
        }

        if (GameStats.stats.RunInProgressPortalBoost == false)
        {
            if (GameStats.stats.PortalBoost == false)
            {
                levelcountdown = 0;
            }
            if (GameStats.stats.PortalBoost == true)
            {
                levelcountdown = levelTime / 3;

            }

        }
        else
        {
            GameStats.stats.RunInProgressPortalBoost = false;
        }

        TimerSlider.maxValue = levelTime;
        GameStats.stats.spawnHouse = false;

        


    }

    // Update is called once per frame
    void Update()
    {
        if (cha.Health > 0)
        {
            levelcountdown += 1 * Time.deltaTime;
            TimerSlider.value = levelcountdown;
        }

        if (levelcountdown >= levelTime - 7f)
        {
            EnemySpawner1.SetActive(false);
            EnemySpawner2.SetActive(false);
            EnemySpawner3.SetActive(false);
            EnemySpawner4.SetActive(false);
            EnemySpawnerHand.SetActive(false);
            cha.endlevel = true;
            
        }
        int levelPercentage = Mathf.FloorToInt((levelcountdown / levelTime) * 100);
        if (levelPercentage == 25 || levelPercentage == 50 || levelPercentage == 75)
        {
            GameStats.stats.SavedLevelPercentage = levelcountdown;
            GameStats.stats.SaveCurrentHearts = cha.Health;
            GameStats.stats.SaveStats();
        }

        
  
    }

    IEnumerator loadloader()
    {
        while (true)
        {

            if (GameStats.stats.LevelCount == 3)
            {

                if (GameStats.stats.bossDead == true)
                {
                    yield return new WaitForSecondsRealtime(5);
                    EndlessHosue.spawnhouse();
                    GameStats.stats.PortalBoost = false;
                    if (cha.Health == cha.NumOfHearts)
                    {
                        GameStats.stats.AchivementConditions[14] = true;
                        
                    }
                    
                    
                    StartCoroutine(loadAsyncGame("Store"));
                }

            }
            else
            {

                if (TimerSlider.value >= levelTime && !timeOver)
                {
                    timeOver = true;
                    yield return new WaitForSecondsRealtime(1);
                    EndlessHosue.spawnhouse();
                    levelTime = 0;
                    GameStats.stats.PortalBoost = false;
                    
                    
                    
                    StartCoroutine(loadAsyncGame("Store"));
                    
                }

            }
            yield return null;
        }

    }



    IEnumerator loadAsyncGame(string SceneName)

    {



        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(1);
        FindObjectOfType<AudioManager>().Play("EndOfLevelSound");
        yield return new WaitForSecondsRealtime(1);
        // play animation
        EndLevelAnimation.SetActive(true);


        //wait
        yield return new WaitForSecondsRealtime(transitiontime);
        backgroundLoopScript.enabled = false;
        Destroy(Background);
        Resources.UnloadUnusedAssets();
        //loadScene


        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }


    // if player dies back to main menú button

    public void backToMainMenu()

    {

        GameStats.stats.ResetStats();
        GameStats.stats.RunInProgress = false;
        GameStats.stats.SaveStats();
        loadingScreen.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(loadAsyncMainMenu());
        
        GameStats.stats.CoinTicket = false;

    }

    public void backtoMainMenuPauseButton()
    {
        GameStats.stats.SaveStats();
        loadingScreen.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(loadAsyncMainMenu());
        
        // save level indicator and count for resume;


    }



    IEnumerator loadAsyncMainMenu()

    {

        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(1);
        // play animation
        transition.SetTrigger("Start");





        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene
        backgroundLoopScript.enabled = false;
        Destroy(backgroundLoopScript);
        Destroy(Background);
        Destroy(character);
        Resources.UnloadUnusedAssets();

        AsyncOperation operation = SceneManager.LoadSceneAsync("Main Menu");

        loadingScreen.SetActive(true);
        Time.timeScale = 1;


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }
}
