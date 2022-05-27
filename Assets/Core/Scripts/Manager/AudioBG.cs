using UnityEngine;

public class AudioBG : Singleton<AudioBG>
{
    [SerializeField]
    private AudioClip _menuAudio;
    [SerializeField]
    private AudioClip _gameAudio;

    private AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        _audio.Stop();
    }

    public void MenuAudio()
    {
        if(_audio.clip != _menuAudio)
        {
            _audio.clip = _menuAudio;
            _audio.Play();
        }
    }

    public void GameAudio()
    {
        _audio.clip = _gameAudio;
        _audio.Play();
    }
}
