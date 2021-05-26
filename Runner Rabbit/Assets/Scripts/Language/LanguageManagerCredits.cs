using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerCredits : MonoBehaviour
{
    

    [SerializeField] TextMeshProUGUI TeamText, MusicText, SFXText, SpecialThanksText = null;
    [SerializeField] TextMeshProUGUI Rafa, Medri, Andres = null;
    [SerializeField] TextMeshProUGUI AditionalEfectsText = null;




    string[] Language_Team =
    {
        "Team", // 0: ingles
        "Equipo", // 1: español
        "Team"  // 2: frances TODO
    };
    string[] Language_Music =
    {
        "Music", // 0: ingles
        "Música", // 1: español
        "Team"  // 2: frances TODO
    };
    string[] Language_SFX =
    {
        "SFX", // 0: ingles
        "SFX", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_SpecialThanks =
    {
        "Special Thanks", // 0: ingles
        "Agradecimientos", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_Design =
    {
        "Design", // 0: ingles
        "Diseño", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_Programing =
    {
        "Programing", // 0: ingles
        "Programación", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_Animation =
    {
        "Animation", // 0: ingles
        "Animación", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_Art =
    {
        "Art", // 0: ingles
        "Arte", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_Production =
    {
        "Production", // 0: ingles
        "Porducción", // 1: español
        "SFX"  // 2: frances TODO
    };
    string[] Language_and =
    {
        "and", // 0: ingles
        "y", // 1: español
        "SFX"  // 2: frances TODO
    };

    string[] Language_AditionalEffects =
    {
        "Aditional Effects from ", // 0: ingles
        "Efectos adicionales de ", // 1: español
        "SFX"  // 2: frances TODO
    };



    void Start()
    {
        TeamText.text = Language_Team[GameStats.stats.LanguageSelect];
        MusicText.text = Language_Music[GameStats.stats.LanguageSelect];
        SFXText.text = Language_SFX[GameStats.stats.LanguageSelect];
        SpecialThanksText.text = Language_SpecialThanks[GameStats.stats.LanguageSelect];

        Rafa.text = Language_Programing[GameStats.stats.LanguageSelect] + " " + Language_and[GameStats.stats.LanguageSelect] + " " + Language_Design[GameStats.stats.LanguageSelect];
        Medri.text = Language_Art[GameStats.stats.LanguageSelect]+ ", " + Language_Animation[GameStats.stats.LanguageSelect] + ", "+ Language_Programing[GameStats.stats.LanguageSelect] + " " + Language_and[GameStats.stats.LanguageSelect] + " " + Language_Design[GameStats.stats.LanguageSelect];
        Andres.text = Language_Production[GameStats.stats.LanguageSelect];

        AditionalEfectsText.text = Language_AditionalEffects + "zapsplat";

    }

   
}
