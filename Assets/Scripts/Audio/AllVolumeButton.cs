using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class AllVolumeButton : MonoBehaviour
{
    private bool isMuted = false;

    //AudioListener volume;
    [SerializeField] public AudioMixer audioMixer;
    AudioManager audioManager;
    public TextMeshProUGUI volumeStateText; //ska visa om volymen är on/off
   


    void Start()
    {
       audioManager= FindAnyObjectByType<AudioManager>();
       LoadMutedState();
    }

    private void Update()
    {
        audioManager.masterMixer.GetFloat("Master", out float tmp);
        //Debug.Log(tmp);
    }

    public void ToggleVolume()
    {
        if (isMuted)
            Unmute();
        else
            Mute();

        // Save the muted state to PlayerPrefs
        SaveMutedState();
    }

    public void Mute()
    {
        isMuted = true;
        audioManager.MuteMasterVolume();
        UpdateVolumeStateText();
    }

    public void Unmute()
    {
        isMuted = false;
        audioManager.UnmuteMasterVolume();
        UpdateVolumeStateText();
    }

    private void UpdateVolumeStateText()
    {
        volumeStateText.text = isMuted ? " OFF " : " ON ";
    }
   
    private void SaveMutedState() //spara muted state till playersPrefs.
    {   
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadMutedState() //ladda de sparade muted state från playersPrefs. 
    {
        if (PlayerPrefs.HasKey("Master")) 
        {
            float mutedState = PlayerPrefs.GetFloat("Master");
            isMuted = mutedState == 0.0001;
        }
    }
}
