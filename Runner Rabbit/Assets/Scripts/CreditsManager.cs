using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CreditsManager : MonoBehaviour
{
    public VideoPlayer video1;
    //public VideoPlayer video2;

    [SerializeField] CanvasGroup FadeToBlack = null;
    [SerializeField] GameObject Credits_1 = null;
    [SerializeField] GameObject Credits_2 = null;
    [SerializeField] GameObject Credits_3 = null;

    [SerializeField] float Credits1Time = 0;
    [SerializeField] float Credits2Time = 0;
    [SerializeField] float Credits3Time = 0;

    [SerializeField] float transitiontime = 0;

    [SerializeField] AudioMixer mainMixer = null;

    bool IsWatchingOutro;




    // Start is called before the first frame update
    void Start()
    {
        IsWatchingOutro = true;
        
        mainMixer.SetFloat("MusicVolume", 0);
        mainMixer.SetFloat("MainMixer", 0);

        video1.loopPointReached += EndReached1;
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    void EndReached1(VideoPlayer vp)
    {

        IsWatchingOutro = false;
        StartCoroutine(ShowCredits());
        
    }


    void EndReached2(VideoPlayer vp)
    {
        LoadMenu();
    }


    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Skip()
    {
        if (IsWatchingOutro)
        {
            video1.time += video1.length;
        }
        else
        {
            LoadMenu();
        }
    }



    IEnumerator ShowCredits()
    {
        // transition credits 1
        print("start credits");
        LeanTween.alphaCanvas(FadeToBlack, 1, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime);
        print("black 1");
        Destroy(video1.gameObject);
        Credits_1.SetActive(true);
        LeanTween.alphaCanvas(FadeToBlack, 0, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime / 2);
        // end transition credits 1
        // show credits 1
        print("credits 1");
        yield return new WaitForSeconds(Credits1Time);

        // transition credits 2
        LeanTween.alphaCanvas(FadeToBlack, 1, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime);
        print("black 2");
        Credits_1.SetActive(false);
        Credits_2.SetActive(true);
        LeanTween.alphaCanvas(FadeToBlack, 0, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime / 2);
        // end transition credits 2
        // show credits 2
        print("credits 2");
        yield return new WaitForSeconds(Credits2Time);


        // transition credits 3
        LeanTween.alphaCanvas(FadeToBlack, 1, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime);
        print("black 2");
        Credits_2.SetActive(false);
        Credits_3.SetActive(true);
        LeanTween.alphaCanvas(FadeToBlack, 0, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime / 2);
        // end transition credits 3
        // show credits 3
        print("credits 3");
        yield return new WaitForSeconds(Credits3Time);


        // end
        LeanTween.alphaCanvas(FadeToBlack, 1, transitiontime / 2);
        yield return new WaitForSeconds(transitiontime);
        print("black 3");
        Credits_2.SetActive(false);
        Credits_3.SetActive(false);
        print("End");
        LoadMenu();
    }
}
