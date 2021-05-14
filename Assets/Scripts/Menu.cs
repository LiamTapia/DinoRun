using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Color normalColor = new Color32(31,190,212,255);
    Color selectedColor = new Color32(233,236,32,255);
    public Button[] ButtonList;
    public int activeButton = 0;

    public KeyCode keyNext = KeyCode.DownArrow;
    public KeyCode keyBefore = KeyCode.UpArrow;
    public bool SpecialMenu = false;

    // Update is called once per frame
    public virtual void Update()
    {
        keyboardSelection();

        ButtonList[activeButton].Select();
        ButtonList[activeButton].GetComponentInChildren<Text>().color = selectedColor;
    }

    public void keyboardSelection()
    {
        if (Input.GetKeyDown(keyNext))
        {
            ButtonList[activeButton].GetComponentInChildren<Text>().color = new Color32(31,190,212,255);
            activeButton = (activeButton + 1) % ButtonList.Length;
        }
            
        if (Input.GetKeyDown(keyBefore))
        {
            ButtonList[activeButton].GetComponentInChildren<Text>().color = normalColor;
            if(activeButton == 0)
                activeButton = ButtonList.Length - 1;
            else
                activeButton--;
        }
    }

    //Selects the button that is under the cursor
    public void hoverSelection(int selection)
    {
        activeButton = selection; 
        
        for(int i = 0; i < ButtonList.Length; i++)
            ButtonList[i].GetComponentInChildren<Text>().color = new Color32(31,190,212,255);
        
    }
}
