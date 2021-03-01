using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoaderStore : MonoBehaviour
{

    public float transitiontime;
    public GameObject loadingScreen;
    public Slider slider;
    public int SceneIndex;

    private void Start()
    {
        GameStats.stats.isInStore = true;
        GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
        GameStats.stats.SaveStats();
        

    }


    // Start is called before the first frame update
    public void ContinueButton()

    {
        GameStats.stats.isInStore = false;
        GameStats.stats.LevelCount += 1;
        GameStats.stats.CheckLevelIndicator();
        GameStats.stats.SaveLevelBackUp();
        GameStats.stats.SavedLevelPercentage = 0;
        
        GameStats.stats.SaveStats();
        string LevelToLoad = GameStats.stats.CheckLevel();

        if (GameStats.stats.LevelIndicator > GameStats.stats.LevelReached)
        {
            GameStats.stats.LevelReached = GameStats.stats.LevelIndicator;
        }

        
        
        //Debug.Log(LevelToLoad);
        StartCoroutine(LoadAsync(LevelToLoad));
        
       
    }



    // Update is called once per frame
    IEnumerator LoadAsync(string SceneName)
    {

        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene


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
