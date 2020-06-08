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


    // Start is called before the first frame update
    public void ContinueButton()

    {
        StartCoroutine(LoadAsync());
    }



    // Update is called once per frame
    IEnumerator LoadAsync()
    {

        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene


        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

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
