using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer video1;
    // Start is called before the first frame update
    void Start()
    {
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
