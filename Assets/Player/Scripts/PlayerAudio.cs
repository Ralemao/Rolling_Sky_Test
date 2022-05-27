using UnityEngine;

public class PlayerAudio : Singleton<PlayerAudio>
{
    [SerializeField]
    private AudioClip _deathAudio;

    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void DeathAudio()
    {
        PlayerAnimation.Instance.DeathAnim();
        _audio.PlayOneShot(_deathAudio);
    }
}
