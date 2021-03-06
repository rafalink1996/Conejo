﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerGame : MonoBehaviour
{

    //Setings
    public TextMeshProUGUI SettingsTitle, ResumeButton, MainMenúButton, MusicSubtitle, SoundSubtitle;
    public TextMeshProUGUI YouAreDeadtitle, DeadMainMenuButton;
    public TextMeshProUGUI loadingAdText;


     // English
    string English_SettingsTitle = "Settings";
    string English_ResumeButton = "Resume";
    string English_MainMenuButton = "Main Menu";
    string English_MusicSubtitle = "Music";
    string English_SoundSubtitle = "Sound";
    string English_YouAreDeadTitel = "You are dead";

    string English_LoadingAd = "Loading Ad ...";

    // Español
    string Español_SettingsTitle = "Opciones";
    string Español_ResumeButton = "Resumir";
    string Español_MainMenuButton = "Menú Principal";
    string Español_MusicSubtitle = "Música";
    string Español_SoundSubtitle = "Sonido";
    string Español_YouAreDeadTitel = "Estás Muerto";

    string Español_LoadingAd = "Cargando Ad ...";

    //Frances
    string Frances_SettingsTitle = "Opciones";
    string Frances_ResumeButton = "Resumir";
    string Frances_MainMenuButton = "Menú Principal";
    string Frances_MusicSubtitle = "Música";
    string Frances_SoundSubtitle = "Sonido";
    string Frances_YouAreDeadTitel = "Estás Muerto";

    string Frances_LoadingAd = "Loading Ad ...";

    void Start()
    {
        SetLanguage(GameStats.stats.LanguageSelect);
    }

    public void SetLanguage(int Language)
    {
        switch (Language)
        {
            case 0:// English
                SettingsTitle.text = English_SettingsTitle;
                ResumeButton.text = English_ResumeButton;
                MainMenúButton.text = English_MainMenuButton; MainMenúButton.fontSize = 21;
                MusicSubtitle.text = English_MusicSubtitle;
                SoundSubtitle.text = English_SoundSubtitle;
                YouAreDeadtitle.text = English_YouAreDeadTitel;
                DeadMainMenuButton.text = English_MainMenuButton;
                loadingAdText.text = English_LoadingAd;
                break;
            case 1: //Español
                SettingsTitle.text = Español_SettingsTitle;
                ResumeButton.text = Español_ResumeButton;
                MainMenúButton.text = Español_MainMenuButton; MainMenúButton.fontSize = 18;
                MusicSubtitle.text = Español_MusicSubtitle;
                SoundSubtitle.text = Español_SoundSubtitle;
                YouAreDeadtitle.text = Español_YouAreDeadTitel;
                DeadMainMenuButton.text = Español_MainMenuButton;
                loadingAdText.text = Español_LoadingAd;
                break;
            case 2: //Frances
                SettingsTitle.text = Frances_SettingsTitle;
                ResumeButton.text = Frances_ResumeButton;
                MainMenúButton.text = Frances_MainMenuButton; MainMenúButton.fontSize = 18;
                MusicSubtitle.text = Frances_MusicSubtitle;
                SoundSubtitle.text = Frances_SoundSubtitle;
                YouAreDeadtitle.text = Frances_YouAreDeadTitel;
                DeadMainMenuButton.text = Frances_MainMenuButton;
                loadingAdText.text = Frances_LoadingAd;
                break;
        }
    }

}



