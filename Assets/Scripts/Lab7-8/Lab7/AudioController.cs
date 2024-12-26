using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioController : MonoBehaviour
{
    public static AudioController aCtrl;
    public GameObject[] bgMusic;
    public AudioSource sfxSrc;
    private AudioSource[] levelMusic;
    private int currentBgMusic;
    public void Awake()
    {
        if (aCtrl == null)
        {
            levelMusic = new AudioSource[bgMusic.Length];
            levelMusic[0] = bgMusic[0].GetComponent<AudioSource>();
            levelMusic[1] = bgMusic[1].GetComponent<AudioSource>();

            levelMusic[0].loop = true;
            aCtrl = this;
            currentBgMusic = 0;
        }
    }
    public void PlaySFX()
    {
        //aCtrl.sfxSrc.Play() //this does the same thing
        sfxSrc.Play();
    }
    public void StopMusic()
    {
        levelMusic[currentBgMusic].Stop();
    }
    public void PauseMusic()
    {
        levelMusic[currentBgMusic].Pause();
    }
    public void PlayMusic()
    {
        levelMusic[currentBgMusic].Play();
    }

    public void ChangeMusicTrack()
    {
        if (currentBgMusic == 0)
        {
            StopMusic();
            currentBgMusic = 1;
            PlayMusic();
        }
        else if (currentBgMusic == 1)
        {
            StopMusic();
            currentBgMusic = 0;
            PlayMusic();
        }
    }

    //more functions to dynamically add new sounds
}