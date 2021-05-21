using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeOnline : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayFabManager onlineLeaderboard;
    void Start()
    {
        onlineLeaderboard.Login();
    }

}
