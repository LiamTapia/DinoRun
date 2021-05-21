using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTableOnline : MonoBehaviour
{
    public PlayFabManager Manager;
    private DinoCharacterController player;
    public InputField nombre;
    public GameObject GameOverScreen;

    public void SendText()
    {
        Debug.Log(nombre.text);
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
        Manager.SendLeaderboard(player.ambar,nombre.text);
        GameOverScreen.SetActive(true);
    }
}
