using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuVolumenManager : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource MenuSFX;

    // Update is called once per frame
    void Update()
    {
        MenuMusic.volume = VolumeVariables.MusicVolume;
        MenuSFX.volume = VolumeVariables.SoundEffetcsVolume;
    }
}
