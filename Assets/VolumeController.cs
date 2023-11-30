using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
  
    private bool isMuted = false;
    private float originalVolume;

    AudioListener volume;

    public Text volumeStateText; //ska visa om volymen �r on/off

    public void ToggleVolume()
    {
        isMuted = !isMuted;

        if (isMuted) 
        {

            originalVolume = AudioListener.volume;
            AudioListener.volume = 0f;
            volumeStateText.text = "Volume: OFF";
         
        }
        else
        {
            AudioListener.volume = originalVolume;
            volumeStateText.text = "Volume: ON";

        }


    }












}
