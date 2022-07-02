using UnityEngine;

public class AudioActtions : Singleton<AudioActtions>
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public AudioClip PlayAudioClip { set { _audio.PlayOneShot(value); } }
}
