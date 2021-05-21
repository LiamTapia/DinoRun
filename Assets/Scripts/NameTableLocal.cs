using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTableLocal : MonoBehaviour
{
    public LocalLeaderboard ManagerLocal;
    private DinoCharacterController player;
    public InputField nombre;
    public PlayFabManager onlineLeaderboard;

    public void SendText()
    {
        Debug.Log(nombre.text);
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
        ManagerLocal.AddScore(player.ambar,nombre.text);
        onlineLeaderboard.checkIfEnteredLeaderboard(player.ambar);
    }
}
