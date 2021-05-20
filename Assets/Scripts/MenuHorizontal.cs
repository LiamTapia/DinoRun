using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuHorizontal : Menu
{
    public KeyCode specialKey1 = KeyCode.DownArrow;
    public KeyCode specialKey2 = KeyCode.UpArrow;

    // Update is called once per frame
    public override void  Update()
    {
        base.Update();
    }

    public override void keyboardSelection()
    {
        
        if (Input.GetKeyDown(keyNext) && activeButton != (ButtonList.Length - 1))
        {
            if(ButtonList[activeButton].GetComponentInChildren<Text>())
                ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            
            activeButton = (activeButton + 1) % (ButtonList.Length - 1);
            playButtonSound();
        }
        else if (Input.GetKeyDown(keyBefore) && activeButton != (ButtonList.Length - 1))
        {
            if(ButtonList[activeButton].GetComponentInChildren<Text>())
                ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            
            if(activeButton == 0)
                activeButton = ButtonList.Length - 2;
            else
                activeButton--;

            playButtonSound();
        }
        else if (Input.GetKeyDown(specialKey1) || Input.GetKeyDown(specialKey2))
        {
            if(ButtonList[activeButton].GetComponentInChildren<Text>())
                ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            
            if(activeButton != (ButtonList.Length - 1))
                activeButton = ButtonList.Length - 1;
            else 
                activeButton = 0;

             playButtonSound();
        }
    }

    public virtual void ManageVolumen(float change)
    {}

    public virtual void VolumenIndicator()
    {}
}
