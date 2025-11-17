using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static  AudioManager instance;
    public static AudioManager Instance
    {
        get => instance;
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource playerSource;
    public AudioSource enemySource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;

    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
    private void Start()
    {
        PlayBackgroundMusic();
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayEnemysfxmusic(AudioClip clip)
    {
        playerSource.PlayOneShot(clip);
    }
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
        playerSource.volume = volume;
        enemySource.volume = volume;
    }
}
