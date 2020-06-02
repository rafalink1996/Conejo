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
    public GameObject playbuttontransition;
    public HouseSpawner EndlessHosue;
    public character cha;
  



    private void Start()
    {
        StartCoroutine(loadloader());
       

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

    IEnumerator loadAsyncGame(int SceneIndex)

    {

        Debug.Log("gameChangeInitiated");
        yield return new WaitForSeconds(1);
        // play animation
        transition.SetTrigger("Start");
      




        //wait
        yield return new WaitForSeconds(transitiontime);

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

       

        yield return new WaitForSeconds(levelTime);

        EndlessHosue.spawnhouse();
        cha.EndLevel = true;

        

        


    }


    public void changelevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(loadAsyncGame(SceneManager.GetActiveScene().buildIndex + 1));
    }

   
       


}
