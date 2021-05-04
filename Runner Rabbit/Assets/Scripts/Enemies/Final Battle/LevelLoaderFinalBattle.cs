using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderFinalBattle : MonoBehaviour
{


    public GameObject loadingScreen;
    public Slider slider;
    public GameObject EndLevelAnimation;
    public Animator transition;

    public float transitiontime;

    public GameObject MageBoss;

    character cha;

    // Start is called before the first frame update
    void Start()
    {
        cha = GameObject.FindWithTag("Player").GetComponent<character>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator loadAsyncGame(int SceneIndex)

    {



        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(2);
        // play animation
        EndLevelAnimation.SetActive(true);





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
}
