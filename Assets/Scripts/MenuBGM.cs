using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBGM : MenuHorizontal
{
    public float volumenMusic = 1f;
    public Image[] Slider;

    public void Awake()
    {
        volumenMusic = VolumeVariables.MusicVolume;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        VolumenIndicator();
    }

    public override void ManageVolumen(float change)
    {
        if((change < 0 && VolumeVariables.MusicVolume != 0) || (change > 0 && VolumeVariables.MusicVolume != 1))
        {   
            VolumeVariables.MusicVolume += change;
            volumenMusic += change;
        }    

         playButtonSound();
    }

    public override void VolumenIndicator()
    {
        for(int i = 0; i < Slider.Length; i++)
        {
            if(i <= ((volumenMusic * 10) - 1))
                Slider[i].color = new Color32(31,190,212,255);
            else
                Slider[i].color = new Color32(233,236,32,255);
        }
    }

}
