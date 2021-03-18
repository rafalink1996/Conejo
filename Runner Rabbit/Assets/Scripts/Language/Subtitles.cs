using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{
    public TextMeshProUGUI SubtitleTextMesh;

    public float initialTime;
    public float[] SubtitleTimers;
    public string[] Español_Subtitles;
    
    
    void Start()
    {
        SubtitleTextMesh.text = " ";
      
       if (Application.systemLanguage == SystemLanguage.English)
        {
            return;
        } else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            StartCoroutine(DisplaySubtitles(Español_Subtitles, SubtitleTimers));
        }
      

        //StartCoroutine(DisplaySubtitles(Español_Subtitles, SubtitleTimers));
    }

    
   IEnumerator DisplaySubtitles (string[] SubtitleTexts, float[] SubtitleTimes)
    {

        yield return new WaitForSecondsRealtime(initialTime);
        for (int i = 0; i < SubtitleTimes.Length; i++)
        {
            SubtitleTextMesh.text = SubtitleTexts[i];
            yield return new WaitForSecondsRealtime(SubtitleTimes[i]);
            
        }


    }
}
