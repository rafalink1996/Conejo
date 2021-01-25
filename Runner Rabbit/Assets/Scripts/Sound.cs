﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioMixerGroup audioOutputMixer;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f,3)]
    public float pitch;
    [Range(0, 256)]
    public int priority;



    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
