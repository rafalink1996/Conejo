using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Animator transition;
    public float transitiontime;
    public float levelTime;
    public float levelcountdown;

    public GameObject playbuttontransition;
    public HouseSpawner EndlessHosue;
    public character cha;
    public BossWyrm bossWyrm;

    public GameObject EnemySpawner1;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawnerHand;

    public Slider TimerSlider;





    private void Start()
    {
        StartCoroutine(loadloader());
        levelcountdown = 0;


    }

    private void Update()
    {
        levelcountdown += 1*Time.deltaTime;
        TimerSlider.value = levelcountdown;

        if (levelcountdown >= 90)
        {
            EnemySpawner1.SetActive(false);
            EnemySpawner2.SetActive(false);
            EnemySpawnerHand.SetActive(false);
        }
    }


    public void LoadLevel( int SceneIndex)

    {
        StartCoroutine(loadAsync(SceneIndex));
    }



    IEnumerator loadAsync (int SceneIndex)

    {
        // play animation
        transition.SetTrigger("Start");
        FindObjectOfType<AudioManager>().Play("TransitionSound");


        //wait
        yield return new WaitForSecondsRealtime (transitiontime);

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


    // load next level

    IEnumerator loadAsyncGame(int SceneIndex)

    {

        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(1);
        // play animation
        transition.SetTrigger("Start");
      




        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene
       

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

    IEnumerator loadloader()
    {
        while (true)
        {

            if (GameStats.stats.LevelCount == 3)
            {

                if (bossWyrm.BossDead == true)
                {
                    yield return new WaitForSecondsRealtime(3);
                    EndlessHosue.spawnhouse();
                    cha.EndLevel = true;
                }

            }
            else
            {

                if (TimerSlider.value == levelTime)
                {
                    yield return new WaitForSecondsRealtime(1);
                    EndlessHosue.spawnhouse();
                    cha.EndLevel = true;
                }

            }
            yield return null;
        }

    }



    public void changelevel()
    {
        //SceneManager.GetActiveScene().buildIndex + 1
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(loadAsyncGame(1));
    }

    //load main menu

    public void backToMainMenu ()

    {
        loadingScreen.SetActive(true);
        StartCoroutine(loadAsyncMainMenu());
        Time.timeScale = 1;
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


        AsyncOperation operation = SceneManager.LoadSceneAsync(0);

        loadingScreen.SetActive(true);
        Time.timeScale = 1;
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }
}
