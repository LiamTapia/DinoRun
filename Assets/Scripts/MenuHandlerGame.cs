using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandlerGame : MonoBehaviour
{
    public GameObject MenuPausa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            MenuPausa.SetActive(!MenuPausa.activeSelf);
    }
}
