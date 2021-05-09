using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject[] Menus;

    public void changeMenu(int option)
    {
        moveMenuOut();
        Menus[option].transform.localPosition = new Vector3(-350,0,0);
        /*switch(option)
        {
            //Pone menu principa;
            case 0:
                moveMenuOut();
                Menus[]
                break;
        }*/
    }

    public void moveMenuOut()
    {
        for(int i = 0; i < Menus.Length; i++)
        {
            Menus[i].transform.localPosition = new Vector3(5,0,0);
        }
    }
}
