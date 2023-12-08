using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class SoundButton : MonoBehaviour
{
    private bool isMuted = false;
    //private float VolumeOn = 1.0f; //orginal volym ska vara det som slidsen är satta på. 

    //AudioListener volume;
    [SerializeField] public AudioMixer audioMixer;
    AudioManager audioManager;
    public TextMeshProUGUI volumeStateText; //ska visa om volymen är on/off
  


    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
       
    }

    private void Update()
    {


        UpdateVolumeStateText();
    }

    public void ToggleVolume()
    {
        isMuted = !isMuted;

        if (isMuted)
        {

            //originalVolume = AudioListener.volume;
            //AudioListener.volume = 0f;
            SetAllVolume(-80f); //-80 db är mute på mixer
            UpdateVolumeStateText();
        }
        else
        {
            //AudioListener.volume = originalVolume;
            SetAllVolume(1);
           
            UpdateVolumeStateText();

        }
    }

    private void SetAllVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
        UpdateVolumeStateText();
    }

    private void UpdateVolumeStateText()
    {
        volumeStateText.text = isMuted ? " OFF " : " ON ";
    }





}
