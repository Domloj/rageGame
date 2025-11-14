using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    void Start()
    {
        instance = this;
        soundSource = GetComponent<AudioSource>();
        // gra między lvlami
        if (instance)
            DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }

    public void ChangeSoundVolume(float _change)
    {
        float currentVolume = 100;
        currentVolume += _change;
        soundSource.volume = currentVolume;
    }

    public void ChangeMusicVolume(float _change)
    {
        float currentVolume = 100;
        currentVolume += _change;
        musicSource.volume = currentVolume;
    }
}
