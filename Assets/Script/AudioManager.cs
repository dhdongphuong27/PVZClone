using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public void PlayAudio(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                if (s.name.Contains("hit"))
                {
                    s.source.Play();
                }
                if (!s.source.isPlaying)
                {
                    s.source.Play();
                }
            }
        }
    }
    public void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
    }
}
