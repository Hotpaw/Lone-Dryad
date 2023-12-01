using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeText : MonoBehaviour
{
    
  
    private bool isMuted = false;
    private float originalVolume = 1.0f;

    //AudioListener volume;
    [SerializeField] public AudioMixer audioMixer;

    public TextMeshProUGUI volumeStateText; //ska visa om volymen är on/off


    void Start()
    {


      audioMixer.GetFloat("Master", out originalVolume);

        UpdateVolumeStateText();

    }

    public void ToggleVolume()
    {
        isMuted = !isMuted;

        if (isMuted) 
        {

            //originalVolume = AudioListener.volume;
            //AudioListener.volume = 0f;
            SetMasterVolume(0f);
            volumeStateText.text = " OFF ";
         
        }
        else
        {
            //AudioListener.volume = originalVolume;
            SetMasterVolume(originalVolume);
            volumeStateText.text = " ON ";


        }


    }

    private void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);
        UpdateVolumeStateText();
    }

    private void UpdateVolumeStateText()
    {
        volumeStateText.text = isMuted ? " OFF " : " ON ";
    }


}
