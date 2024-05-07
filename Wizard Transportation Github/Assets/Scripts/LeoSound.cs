using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class LeoSound
{
    public string name;

    public AudioClip clip;

    public bool loop;

    public float initialVolume;
    [Range(0f, 3f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
