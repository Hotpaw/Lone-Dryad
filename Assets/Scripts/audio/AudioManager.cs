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
    private float originalVolume;

    bool settingsLoaded = false;

    [SerializeField] public AudioMixer masterMixer;

    private void Awake()
    {
        if (INSTANCE != null)
        {
            Destroy(this.gameObject);
            INSTANCE = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (masterMixer == null)
        {
            Debug.LogError("Audio Mixer is not assigned to AudioManager!");
            return;
        }
    }

    private void Start()
    {
        LoadVolumeSettings();
    }
    public void SetSFXVolume(float volume)
    {
        volume = SFXslider.value;
        masterMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }
    public void SetMusicVolume(float volume)
    {
        volume = musicslider.value;
        masterMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
        PlayerPrefs.Save();
    }
    public void SetMasterVolume(float volume)
    {
        volume = masterSlider.value;
        if (volume <= 0.0001f)
            masterMixer.SetFloat("Master", -80f);
        else
            masterMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("Master", volume);
        PlayerPrefs.Save();
    }
    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("Master");
    }
    public void MuteMasterVolume()
    {
        originalVolume = GetMasterVolume();
        masterSlider.value = 0;
        SetMasterVolume(0);
    }
    public void UnmuteMasterVolume()
    {
        masterSlider.value = originalVolume;
        SetMasterVolume(originalVolume);
    }

    public void PlaySFX(string clip)
    {
        switch(clip)
        {
            case "JUMP":
                SFX.clip = SFXClips[0];
                break;
            case "SCAREDGNOME":
                SFX.clip = SFXClips[1];
                break;
            case "BATSCREECHandFLY":
                SFX.clip = SFXClips[2]; //bat
                break;
            case "PLUCKEVILPLANT":
                SFX.clip = SFXClips[3]; //evil plant
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

    public void SaveVolumeSettings() //ska spara volym inställningar
    {
        PlayerPrefs.SetFloat("SFX", SFXslider.value);
        PlayerPrefs.SetFloat("Music", musicslider.value);
        PlayerPrefs.SetFloat("Master", masterSlider.value);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        
    }

    public void LoadVolumeSettings() //ska ladda volymerna in till näsat scen
    {
       

        SFXslider.value = PlayerPrefs.GetFloat("SFX", 1);
        SetSFXVolume(SFXslider.value);

        musicslider.value = PlayerPrefs.GetFloat("Music", 1);
        SetMusicVolume(musicslider.value);

        masterSlider.value = PlayerPrefs.GetFloat("Master", 1);
        SetMasterVolume(masterSlider.value);

    }
















    //if (!PlayerPrefs.HasKey("Music"))
    //{
    //    SetMusicVolume(1);
    //}
    //if (!PlayerPrefs.HasKey("SFX"))
    //{
    //    SetSFXVolume(1);
    //}
    // if (!PlayerPrefs.HasKey("Master"))
    //{
    //    SetMasterVolume(1);
    //}
    //else
    //{

    //    LoadVolumeSettings();

    //}



    //ChangeVolume();





    //public const string SFXVolumeKey = "SFX";
    //public const string MusicVolumeKey = "Music";
    //public const string MasterVolumeKey = "Master";



    //public void ChangeVolume()
    //{
    //    musicslider.onValueChanged.AddListener(SetMusicVolume);
    //    SFXslider.onValueChanged.AddListener(SetSFXVolume);
    //    masterSlider.onValueChanged.AddListener(SetMasterVolume);

    //}




    //public void InitialVolumesOfSliders() //gör att sliderns startar efter musikens läge. Men bara 1 gång. sparas ej än. 
    //{


    //    if (masterMixer.GetFloat("SFX", out initialSFXVolume))
    //    {
    //        SFXslider.value = Mathf.Pow(10, initialSFXVolume / 20);
    //    }

    //    if (masterMixer.GetFloat("Music", out initialMusicVolume))
    //    {
    //        musicslider.value = Mathf.Pow(10, initialMusicVolume / 20);
    //    }

    //    if (masterMixer.GetFloat("Master", out initialMasterVolume))
    //    {
    //        masterSlider.value = Mathf.Pow(10, initialMasterVolume / 20);
    //    }


    //}





    //private void SlidersCurrentValue()
    //{


    //        //audioManager.SetInitialVolumes(SFXslider.value, musicslider.value, masterSlider.value);
    //        SetMusicVolume(musicslider.value);
    //        SetSFXVolume(SFXslider.value);
    //        SetMasterVolume(masterSlider.value);

    //}


}
