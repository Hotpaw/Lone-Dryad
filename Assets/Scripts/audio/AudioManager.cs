using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager INSTANCE;

    public AudioSource SFX;
    public AudioSource Music;
    public List<AudioClip> SFXClips;
    public List<AudioClip> musicClips;
    public Slider SFXslider;
    public Slider musicslider;
    public Slider masterSlider;

    AudioMixer masterMixer;

   

    private void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
       
    }
    // Add slider in the UI and change On Value Change for each slider to use the functions below for each volume setting
    public void SetSFXVolume(float volume)
    {
        masterMixer.SetFloat("SFX", volume);
    }
    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("Music", volume);
    }
    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("Master", volume);
    }
    public void PlaySFX(string clip)
    {
        switch(clip)
        {
            case "JUMP":
                SFX.clip = SFXClips[0];
                break;
        }
        SFX.Play();
    }
    public void PlayMusic(string clip)
    {
        Music.Stop();
        switch (clip)
        {
            case "SONG1":
                SFX.clip = musicClips[0];
                break;
        }
        Music.Play();
    }
}
