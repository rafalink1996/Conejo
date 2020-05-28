using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStart : MonoBehaviour
{

    public float pausetime;
   public bool pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = true;
        pauseStart();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void pauseStart ()
    {

        if (pause == true)
        {
            Time.timeScale = 0f;
            StartCoroutine(PauseTilseconds(pausetime));
        }
        else
        {
            Time.timeScale = 1f;
        }



    }

    IEnumerator PauseTilseconds (float timetilanimation)
    {
        Debug.Log("started coroutine");
        yield return new WaitForSecondsRealtime(timetilanimation);
        Debug.Log("time waited");
        Time.timeScale = 1f;
       
        pause = false;
    }




}
