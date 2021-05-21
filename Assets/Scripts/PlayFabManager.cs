using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    public GameObject columnaPrefab;
    public Transform table;
    public GameObject OnlineLeaderboardTable;
    int scoreCheck;
    public GameObject GameOverScreen;

    public void Login()
    {
        int  auxID =  Random.Range(0,1000);
        var request = new LoginWithCustomIDRequest{
            CustomId = auxID.ToString(),
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Se hizo Login a PlayFab");
    }
    
    void OnError(PlayFabError error)
    {
        Debug.Log("Error en Login a PlayFab");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score, string nombre)
    {
    
        var changeDisplayName = new UpdateUserTitleDisplayNameRequest{
            DisplayName = nombre
        };

        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "AmberScore",
                    Value = score,
                }
            }
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(changeDisplayName,OnChangeNameUpdate,OnError);
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    
        OnlineLeaderboardTable.SetActive(false);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Succesfull leaderboard sent");
    }

    void OnChangeNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Name changed");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest{
            StatisticName = "AmberScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in table)
            Destroy(item.gameObject);

        foreach(var item in result.Leaderboard){
            GameObject newGo = Instantiate(columnaPrefab, table);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

        }
    }

    public void checkIfEnteredLeaderboard(int score)
    {
        scoreCheck = score;

        var request = new GetLeaderboardRequest{
            StatisticName = "AmberScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGetCheck, OnError);
    
    }
    void OnLeaderboardGetCheck(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard){
            if(scoreCheck > item.StatValue)
            {
                GameOverScreen.SetActive(false);
                OnlineLeaderboardTable.SetActive(true);
                break;
            }
            else
                GameOverScreen.SetActive(true);
        }
                
    }

}
