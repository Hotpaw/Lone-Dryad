using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager INSTANCE;

    public AudioSource SFX;
    public AudioSource Music;
    public List<AudioClip> SFXClips;
    public List<AudioClip> musicClips;

    private void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
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
