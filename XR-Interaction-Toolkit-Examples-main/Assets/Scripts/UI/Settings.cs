using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Toggle comfortMode;
    [SerializeField] private Toggle snapRot;

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadVolume();
        }
        if (PlayerPrefs.HasKey("comfortMode"))
        {
            LoadSettings();
        }
        else 
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
            SetComfortMode();
            SetSnapRot();
        }
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetComfortMode()
    {
        bool checkCase = comfortMode.isOn;
        PlayerPrefs.SetInt("comfortMode", checkCase ? 1 : 0);
    }

    public void SetSnapRot()
    {
        bool checkCase = snapRot.isOn;
        PlayerPrefs.SetInt("snapRot", checkCase ? 1 : 0);

    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMasterVolume();
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.GetInt("snapRot") == 1)
        {
            snapRot.isOn = true;
        }
        else
        {
            snapRot.isOn = false;
        }
        if (PlayerPrefs.GetInt("comfortMode") == 1)
        {
            comfortMode.isOn = true;
        }
        else
        {
            comfortMode.isOn = false;
        }

        SetSnapRot();
        SetComfortMode();
    }
}
