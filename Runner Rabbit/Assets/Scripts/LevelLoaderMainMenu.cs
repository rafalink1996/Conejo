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

    private void Start()
    {
        GameStats.stats.SaveStats();
        

    }

    public void LoadLevel()

    {
        if (GameStats.stats.LevelBought == true)
        {
            StartCoroutine(loadAsync(GameStats.stats.leveBoughtID));
            GameStats.stats.LevelIndicator = GameStats.stats.leveBoughtID;
        }
        else
        {
            StartCoroutine(loadAsync(2));
        }
        
    }



    IEnumerator loadAsync(int SceneIndex)

    {
        // play animation
        transition.SetTrigger("Start");
        FindObjectOfType<AudioManager>().Play("TransitionSound");


        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene
        playbuttontransition.SetActive(false);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }
}
