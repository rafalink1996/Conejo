﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerGame : MonoBehaviour
{

    //Setings
    public TextMeshProUGUI SettingsTitle, ResumeButton, MainMenúButton, MusicSubtitle, SoundSubtitle;


     // English
    string English_SettingsTitle = "Settings";
    string English_ResumeButton = "Resume";
    string English_MainMenuButton = "Main Menu";
    string English_MusicSubtitle = "Music";
    string English_SoundSubtitle = "Sound";

    // Español
    string Español_SettingsTitle = "Opciones";
    string Español_ResumeButton = "Resumir";
    string Español_MainMenuButton = "Menú Principal";
    string Español_MusicSubtitle = "Música";
    string Español_SoundSubtitle = "Sonido";

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
                break;
            case 1: //Español
                SettingsTitle.text = Español_SettingsTitle;
                ResumeButton.text = Español_ResumeButton;
                MainMenúButton.text = Español_MainMenuButton; MainMenúButton.fontSize = 18;
                MusicSubtitle.text = Español_MusicSubtitle;
                SoundSubtitle.text = Español_SoundSubtitle;
                break;
        }
    }

}



