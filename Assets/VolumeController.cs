using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    
  
    private bool isMuted = false;
    private float originalVolume;

    AudioListener volume;

    public TextMeshProUGUI volumeStateText; //ska visa om volymen �r on/off

    public void ToggleVolume()
    {
        isMuted = !isMuted;

        if (isMuted) 
        {

            originalVolume = AudioListener.volume;
            AudioListener.volume = 0f;
            volumeStateText.text = " OFF ";
         
        }
        else
        {
            AudioListener.volume = originalVolume;
            volumeStateText.text = " ON ";


        }


    }












}
