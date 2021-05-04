using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseStart : MonoBehaviour
{

    public float pausetime1;
    public float pausetime2;
    public bool pause;
    public Image image;

    
    // Start is called before the first frame update
    void Start()
    {
        pause = true;
        image.enabled = true;
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
            StartCoroutine(PauseTilseconds(pausetime1, pausetime2));
        }
        else
        {
            Time.timeScale = 1f;
        }



    }

    IEnumerator PauseTilseconds (float timetilanimation1 , float timetilanimation2)
    {
        Debug.Log("started coroutine");
        
        yield return new WaitForSecondsRealtime(timetilanimation1);
        StartCoroutine(ReduceImageOpasity());
        yield return new WaitForSecondsRealtime(timetilanimation2);
        Debug.Log("time waited");
        
        Time.timeScale = 1f;
        

       
        pause = false;
    }

    IEnumerator ReduceImageOpasity()
    {
        while (image.color.a > 0)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Color color = image.color;
            color.a -= 0.1f;
            image.color = color;


        }

 
    }




}
