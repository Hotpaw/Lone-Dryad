using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    //AudioListener volume;
    [SerializeField] public AudioMixer audioMixer;
    AudioManager audioManager;

    public Slider SFXslider;
    public Slider musicslider;
    public Slider masterSlider;

   

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

       //SlidersCurrentValue();

    }

    private void Update()
    {


       
    }

    //private void SlidersCurrentValue()
    //{
    //    if (audioManager != null)
    //    {
    //        //audioManager.SetInitialVolumes(SFXslider.value, musicslider.value, masterSlider.value);
    //        audioManager.SetMusicVolume(musicslider.value);
    //        audioManager.SetSFXVolume(SFXslider.value);
    //        audioManager.SetMasterVolume(masterSlider.value);
    //    }
    //}

   




    //private void SaveVolumes()
    //{
    //    if (audioManager != null)
    //    {
    //        audioManager.SaveVolumeSettings();
    //    }
    //}

    //private void LoadSavedVolumes()
    //{
    //    if (audioManager != null)
    //    {
    //        audioManager.LoadVolumeSettings();
    //    }
    //}







    //public void SaveVolumeSettings() //Sparar volym settings
    //{
    //    PlayerPrefs.SetFloat(SFXVolumeKey, SFXslider.value);
    //    PlayerPrefs.SetFloat(MusicVolumeKey, musicslider.value);
    //    PlayerPrefs.SetFloat(MasterVolumeKey, masterSlider.value);
    //    PlayerPrefs.Save(); 
    //}

}
