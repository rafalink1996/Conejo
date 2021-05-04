using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManagerStore : MonoBehaviour
{


    public Slider MusicSlider;
    public Slider SoundSlider;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(GameStats.stats.MusicVolume) * 20);
        MusicSlider.value = GameStats.stats.MusicVolume;

        audioMixer.SetFloat("SoundVolume", Mathf.Log10(GameStats.stats.AudioVolume) * 20);
        SoundSlider.value = GameStats.stats.AudioVolume;
    }

    public void SetMusicVolume(float Musicvolume)
    {

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Musicvolume) * 20);
        GameStats.stats.MusicVolume = Musicvolume;
        GameStats.stats.SaveStats();
    }

    public void SetSoundVolume(float Audiovolume)
    {
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(Audiovolume) * 20);
        GameStats.stats.AudioVolume = Audiovolume;
        GameStats.stats.SaveStats();
    }
}
