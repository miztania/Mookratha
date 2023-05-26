using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //Main
    AudioSource mainSource;


    //SFX
    AudioSource SFXSource;


    void Start()
    {
        mainSource = this.transform.Find("Main").GetComponent<AudioSource>();
        SFXSource = this.transform.Find("SFX").GetComponent<AudioSource>();
    }

    public void PlaySoundMain(AudioClip audioClip)
    {
        mainSource.PlayOneShot(audioClip);
    }

    public void PlaySoundSFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }
}
