using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{

    public AudioSource soundEffect;
    public AudioClip playEffect, settingsEffect, creditEffect, quitEffect; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {

        soundEffect.clip = playEffect;
        soundEffect.Play();
        
    }
    public void SettingsButton()
    {

        soundEffect.clip = settingsEffect;
        soundEffect.Play();
        Debug.Log(soundEffect.clip);

    }
    public void CreditButton()
    {

        soundEffect.clip = creditEffect;
        soundEffect.Play();
    }

    public void QuitButton()
    {

        soundEffect.clip = quitEffect;
        soundEffect.Play();

    }

}
