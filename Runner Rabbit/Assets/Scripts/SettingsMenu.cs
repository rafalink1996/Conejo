using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume (float Musicvolume)
    {
        
        audioMixer.SetFloat("MusicVolume", Musicvolume);
    }

    public void SetSoundVolume(float Audiovolume)
    {
        audioMixer.SetFloat("SoundVolume", Audiovolume);
    }
}
