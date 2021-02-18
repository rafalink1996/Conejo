using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderMainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Animator transition;
    public float transitiontime;
    public GameObject playbuttontransition;

    public GameObject StartButton;
    public GameObject StartButtonDisplay;

    public GameObject NewRunButton;
    public GameObject ContinueRunButton;

    private void Start()
    {

        if (GameStats.stats.RunInProgress == true)
        {
            StartButton.SetActive(false);
            StartButtonDisplay.SetActive(false);
            NewRunButton.SetActive(true);
            ContinueRunButton.SetActive(true);
        }
        GameStats.stats.SaveStats();

        

    }

    public void LoadLevel()

    {

        if (GameStats.stats.LevelBought == true)
        {

            
            GameStats.stats.LevelIndicator = GameStats.stats.leveBoughtID;
            GameStats.stats.RunInProgress = true;
            GameStats.stats.ResetStats();
            GameStats.stats.SavedLevelIndicator = GameStats.stats.LevelIndicator;
            GameStats.stats.SavedLevelCount = GameStats.stats.LevelCount;
            
           
            string LeveleToLoadName = GameStats.stats.CheckLevel();
            StartCoroutine(loadAsync(LeveleToLoadName));

        }
        else
        {
            GameStats.stats.SavedLevelPercentage = 0;
            GameStats.stats.ResetStats();
            GameStats.stats.SavedLevelIndicator = GameStats.stats.LevelIndicator;
            GameStats.stats.SavedLevelCount = GameStats.stats.LevelCount;
            
            GameStats.stats.RunInProgress = true;
            
            StartCoroutine(loadAsync("Level 1 (Library)"));
        }
        
    }

    public void LoadSavedLevel()
    {
        if (GameStats.stats.isInStore == true)
        {
            GameStats.stats.LevelIndicator = GameStats.stats.SavedLevelIndicator;
            GameStats.stats.LevelCount = GameStats.stats.SavedLevelCount;
            GameStats.stats.CheckLevelIndicator();
            StartCoroutine(loadAsync("Store"));
        }
        else
        {
            GameStats.stats.LevelIndicator = GameStats.stats.SavedLevelIndicator;
            GameStats.stats.LevelCount = GameStats.stats.SavedLevelCount;
            GameStats.stats.CheckLevelIndicator();
            string LevelToLoad = GameStats.stats.CheckLevel();
            StartCoroutine(loadAsync(LevelToLoad));
        }

        
    }
    
        
    
    


    IEnumerator loadAsync(string  SceneName)

    {
        // play animation
        transition.SetTrigger("Start");
        FindObjectOfType<AudioManager>().Play("TransitionSound");


        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene
        playbuttontransition.SetActive(false);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            //Debug.Log(progress);

            yield return null;


        }
    }
}
