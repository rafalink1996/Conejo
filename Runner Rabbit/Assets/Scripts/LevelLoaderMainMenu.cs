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
    public GameObject ContinueRunGameObject;

    private void Start()
    {
        GameStats.stats.SaveStats();
        

    }

    public void LoadLevel()

    {

        if (GameStats.stats.LevelBought == true)
        {

            //StartCoroutine(loadAsync(GameStats.stats.leveBoughtID));
            GameStats.stats.LevelIndicator = GameStats.stats.leveBoughtID;
            string LeveleToLoadName = GameStats.stats.CheckLevel();
            StartCoroutine(loadAsync(LeveleToLoadName));

        }
        else
        {
            
            StartCoroutine(loadAsync("Level 1 (Library)"));
        }
        
    }

    public void LoadSavedLevel()
    {

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
