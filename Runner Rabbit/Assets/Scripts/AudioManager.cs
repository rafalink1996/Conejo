using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.priority = s.priority;
            s.source.outputAudioMixerGroup = s.audioOutputMixer;


        }
    }

    private void Start()
    {
        //Play("music");
        Play("musica alternativa XD");
        Play("WindSFX");
    }

    public void Play (string name)
    {
        Sound s= Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound" + name + "not found");
            return;
        }
       
        s.source.Play();
    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound" + name + "not found");
            return;
        }

        s.source.Stop();
    }
}
