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
    public GameObject playbuttontransition;

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
        yield return new WaitForSeconds(transitiontime);

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
