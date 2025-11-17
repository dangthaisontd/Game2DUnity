using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    public Slider musicSlide;
    public Slider sfxSlide;
    private void Start()
    {
        float musicVolume = DataManager.DataMusic;
        float sfxVolume = DataManager.DataSfx;
        musicSlide.value = musicVolume;
        sfxSlide.value = sfxVolume;
    }
    public void SetMusic(float volume)
   {
       AudioManager.Instance.SetMusicVolume(volume);
       DataManager.DataMusic = volume;
    }
    public void SetSfx(float volume)
    {        
        AudioManager.Instance.SetSfxVolume(volume);
        DataManager.DataSfx = volume;
    }
}
