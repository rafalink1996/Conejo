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
    public string[] English_Subtitles;
    public string[] Frances_Subtitles;




    void Start()
    {
        SubtitleTextMesh.text = " ";

        if (!GameStats.stats.languageselected)
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                StartCoroutine(DisplaySubtitles(English_Subtitles, SubtitleTimers));
                return;
            }
            else if (Application.systemLanguage == SystemLanguage.Spanish)
            {
                StartCoroutine(DisplaySubtitles(Español_Subtitles, SubtitleTimers));
            }
            else if (Application.systemLanguage == SystemLanguage.French)
            {
                StartCoroutine(DisplaySubtitles(Frances_Subtitles, SubtitleTimers));
            }
        }
        else
        {
            if(GameStats.stats.LanguageSelect == 0) // English
            {
                StartCoroutine(DisplaySubtitles(English_Subtitles, SubtitleTimers));
                return;
            } else if (GameStats.stats.LanguageSelect == 1) // Español
            {
                StartCoroutine(DisplaySubtitles(Español_Subtitles, SubtitleTimers));
            }
            else if (GameStats.stats.LanguageSelect == 2) // frances
            {
                StartCoroutine(DisplaySubtitles(Frances_Subtitles, SubtitleTimers));
            }
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
