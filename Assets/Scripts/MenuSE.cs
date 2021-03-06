using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSE : MenuHorizontal
{
    public float volumenSFX = 1f;
    public Image[] Slider;

    public void Awake()
    {
        volumenSFX = VolumeVariables.SoundEffetcsVolume;
    }
    public override void Update()
    {
        base.Update();
        VolumenIndicator();
    }

    public override void ManageVolumen(float change)
    {
        if((change < 0 && VolumeVariables.SoundEffetcsVolume != 0) || (change > 0 && VolumeVariables.SoundEffetcsVolume != 1))
        {   
            VolumeVariables.SoundEffetcsVolume += change;
            volumenSFX += change;
        }    

         playButtonSound();
    }

    public override void VolumenIndicator()
    {
        for(int i = 0; i < Slider.Length; i++)
        {
            if(i <= ((volumenSFX * 10) - 1))
                Slider[i].color = new Color32(31,190,212,255);
            else
                Slider[i].color = new Color32(233,236,32,255);
        }
    }
}
