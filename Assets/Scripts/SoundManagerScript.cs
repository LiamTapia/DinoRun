using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip dinoHurt, jump, monsterDeath, munch, ambar, skull;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        dinoHurt = Resources.Load<AudioClip> ("dinoHurt");
        jump = Resources.Load<AudioClip> ("jump");
        monsterDeath = Resources.Load<AudioClip> ("monsterDeath");
        munch = Resources.Load<AudioClip> ("munch");
        ambar = Resources.Load<AudioClip> ("pickupAmbar");
        skull = Resources.Load<AudioClip> ("pickupSkull");

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = VolumeVariables.SoundEffetcsVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "dinoHurt":
                audioSource.PlayOneShot(dinoHurt);
                break;
            case "jump":
                audioSource.PlayOneShot(jump);
                break;
            case "monsterDeath":
                audioSource.PlayOneShot(monsterDeath);
                break;
            case "munch":
                audioSource.PlayOneShot(munch);
                break;
            case "ambar":
                audioSource.PlayOneShot(ambar);
                break;
            case "skull":
                audioSource.PlayOneShot(skull);
                break;
        }
    }
}
