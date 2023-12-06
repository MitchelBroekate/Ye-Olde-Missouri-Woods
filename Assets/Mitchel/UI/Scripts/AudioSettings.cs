using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadMaster();
        }
        else
        {
            SetMasterVolume();
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusic();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFX();
        }
        else
        {
            SetSFXVolume();
        }

    }

    public void SetMasterVolume()
    {
        float volumeMaster = masterSlider.value;

        audioMixer.SetFloat("MasterP", Mathf.Log10(volumeMaster) * 20);

        PlayerPrefs.SetFloat("MasterVolume", volumeMaster);
    }

    public void SetMusicVolume()
    {
        float volumeMusic = musicSlider.value;

        audioMixer.SetFloat("MusicP", Mathf.Log10(volumeMusic) * 20);

        PlayerPrefs.SetFloat("MusicVolume", volumeMusic);
    }

    public void SetSFXVolume() 
    {
        float volumeSfx = sfxSlider.value;

        audioMixer.SetFloat("SfxP", Mathf.Log10(volumeSfx) * 20);

        PlayerPrefs.SetFloat("SFXVolume", volumeSfx);
    }

    private void LoadMaster()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        SetMasterVolume();
    }

    private void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void LoadSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
