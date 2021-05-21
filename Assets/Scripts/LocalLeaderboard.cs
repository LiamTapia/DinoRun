using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalLeaderboard : MonoBehaviour
{

    public GameObject columnaPrefab;
    public Transform table;
    public GameObject TextoLocal;
    public PlayFabManager onlineLeaderboard;

    int LeaderboardLenght = 5;


    public void AddScore(int score, string name)
    {
        int oldScore, newScore = score;
        string oldName, newName = name;

        for(int i = 0; i < LeaderboardLenght; i++)
        {
            if(PlayerPrefs.HasKey(i+"score"))
            {
                if( PlayerPrefs.GetInt(i+"score") < newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i+"score");
                    oldName  = PlayerPrefs.GetString(i+"name");
                    PlayerPrefs.SetInt(i+"score",newScore);
                    PlayerPrefs.SetString(i+"name",newName);
                    newScore = oldScore;
                    newName  = oldName;
                }
                
            }
            else
            {
                PlayerPrefs.SetInt(i+"score",newScore);
                PlayerPrefs.SetString(i+"name",newName);
                newScore = 0;
                newName = "";
            }
        TextoLocal.SetActive(false);

        }
    }

    public void PrintTable()
    {
        foreach(Transform item in table)
            Destroy(item.gameObject);

        for(int i = 0; i < LeaderboardLenght; i++)
        {
            GameObject newGo = Instantiate(columnaPrefab, table);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (i + 1).ToString();
            texts[1].text = PlayerPrefs.GetString(i+"name");
            texts[2].text =  PlayerPrefs.GetInt(i+"score").ToString();

        }
    }

    public void CheckIfBelongsInTable(int score)
    {
        for(int i = 0; i < LeaderboardLenght; i++)
        {
            if(PlayerPrefs.HasKey(i+"score"))
            {
                if( PlayerPrefs.GetInt(i+"score") < score)
                {
                    TextoLocal.SetActive(true);
                    break;
                }
                else if(i == (LeaderboardLenght-1))
                    onlineLeaderboard.checkIfEnteredLeaderboard(score);
            }
            else
            {
                onlineLeaderboard.checkIfEnteredLeaderboard(score);
                break;
            }
        }
    }
}
