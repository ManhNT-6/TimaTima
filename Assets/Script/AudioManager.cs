using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button musicMuteButton;
    [SerializeField] private Button sfxMuteButton;
    [SerializeField] private Sprite stateOn;
    [SerializeField] private Sprite stateOff;

    private void Awake()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) sfxSource.Play();
    }
    
    void Init()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        musicSource.volume = musicSlider.value;
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        sfxSource.volume = sfxSlider.value;
        musicSource.mute = PlayerPrefs.GetInt("MusicMute") == 1;
        sfxSource.mute = PlayerPrefs.GetInt("SfxMute") == 1;
    }
    public void UpdateValueVolume()
    {
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
        
        musicMuteButton.image.sprite = musicSlider.value > 0 ? stateOn : stateOff;
        sfxMuteButton.image.sprite = sfxSlider.value > 0 ? stateOn : stateOff;
        Save();
    }

    public void MuteMusic()
    {
        musicSource.mute = !musicSource.mute;
        musicMuteButton.image.sprite = !musicSource.mute ? stateOn : stateOff;
    }

    public void MuteSfx()
    {
        sfxSource.mute = !sfxSource.mute;
        sfxMuteButton.image.sprite = !sfxSource.mute ? stateOn : stateOff;
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("SfxVolume", sfxSource.volume);
        PlayerPrefs.Save();
    }
}


