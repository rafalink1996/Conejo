using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer video1;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadSlider;
    string MainMenuName = "Main Menu";
    [SerializeField] VideoPlayer myVideoPlayer;

    [SerializeField] TextMeshProUGUI SkipText = null;

    string English_Skip = "Skip";
    string Español_Skip = "Saltar";
    string Frances_Skip = "Sauter";
    // Start is called before the first frame update
    void Start()
    {
        MainMenuName = "Main Menu";
        if (GameStats.stats.LanguageSelect == 0) // english
        {
            SkipText.text = English_Skip;
        }
        if (GameStats.stats.LanguageSelect == 1) // español
        {
            SkipText.text = Español_Skip;
        }
        if (GameStats.stats.LanguageSelect == 2) // frances
        {
            SkipText.text = Frances_Skip;
        }
        video1.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndReached(VideoPlayer vp)
    {
        LoadMenu();
    }
    public void LoadMenu()
    {
        myVideoPlayer.Stop();
       StartCoroutine(loadAsync(MainMenuName));
    }


    IEnumerator loadAsync(string SceneName)

    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSlider.value = progress;
            //Debug.Log(progress);

            yield return null;


        }
    }
}
