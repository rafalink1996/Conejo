using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer video1;

    [SerializeField] TextMeshProUGUI SkipText = null;

    string English_Skip = "Skip";
    string Español_Skip = "Saltar";
    string Frances_Skip = "Sauter";
    // Start is called before the first frame update
    void Start()
    {
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
        SceneManager.LoadSceneAsync(1);
    }
}
