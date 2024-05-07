using UnityEngine.Audio;
using System;
using UnityEngine;

public class LeoAudioManager : MonoBehaviour
{
    public VolumeControl volumeControl;
    public LeoSound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (LeoSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            volumeControl.audioSource.Add(s.source);
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.initialVolume = s.volume;
        }
    }

    public void Play (string name)
    {
        LeoSound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop (string name)
    {
        LeoSound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
