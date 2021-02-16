﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public VideoPlayer video1;
    public VideoPlayer video2;
    // Start is called before the first frame update
    void Start()
    {
        video1.loopPointReached += EndReached1;
        video2.loopPointReached += EndReached2;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void EndReached1(VideoPlayer vp)
    {
        Destroy(video1.gameObject);
        video2.gameObject.SetActive(true);
    }
    void EndReached2(VideoPlayer vp)
    {
        LoadMenu();
    }
    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
