using UnityEngine;

public class AudioActtions : Singleton<AudioActtions>
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip value)
    {
        _audio.PlayOneShot(value);
    }
}
