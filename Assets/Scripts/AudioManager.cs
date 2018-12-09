using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sounds[] soundsArray;

    private void Awake()
    {
        foreach(Sounds s in soundsArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(soundsArray, sounds => sounds.name == name);
        s.source.Play();
    }
}
