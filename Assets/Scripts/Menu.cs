using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    protected Color normalColor = new Color32(31,190,212,255);
    protected Color selectedColor = new Color32(233,236,32,255);
    public Button[] ButtonList;
    public int activeButton = 0;

    public KeyCode keyNext = KeyCode.DownArrow;
    public KeyCode keyBefore = KeyCode.UpArrow;
    public bool SpecialMenu = false;
    public AudioSource ButtonSound;

    // Update is called once per frame
    public virtual void Update()
    {
        keyboardSelection();

        ButtonList[activeButton].Select();
        if(ButtonList[activeButton].GetComponentInChildren<Text>())
            ButtonList[activeButton].GetComponentInChildren<Text>().color = selectedColor;
    }

    public virtual void keyboardSelection()
    {
        if (Input.GetKeyDown(keyNext))
        {
            if(ButtonList[activeButton].GetComponentInChildren<Text>())
                ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            
            activeButton = (activeButton + 1) % ButtonList.Length;
            playButtonSound();
        }
            
        if (Input.GetKeyDown(keyBefore))
        {
            if(ButtonList[activeButton].GetComponentInChildren<Text>())
                ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            
            if(activeButton == 0)
                activeButton = ButtonList.Length - 1;
            else
                activeButton--;
            
            playButtonSound();
        }
    }


    //Selects the button that is under the cursor
    public void hoverSelection(int selection)
    {
        activeButton = selection; 
        
        for(int i = 0; i < ButtonList.Length; i++)
            if(ButtonList[i].GetComponentInChildren<Text>())
                ButtonList[i].GetComponentInChildren<Text>().color = new Color32(31,190,212,255);
        
         playButtonSound();
    }

    public void playButtonSound()
    {
        ButtonSound.Play();
    }
}
