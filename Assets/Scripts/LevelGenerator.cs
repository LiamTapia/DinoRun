using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_PART = 20f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartListSpace;
    [SerializeField] private List<Transform> levelPartListRocket;
    [SerializeField] private List<Transform> levelPartListAlienShip;
    [SerializeField] private DinoCharacterController player;

    private Vector3 lastEndPosition;
    private void Awake() {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawningLevelParts = 3;
        for(int i = 0; i<startingSpawningLevelParts; i++){
            SpawnLevelPart();
        }
    }

    private void Update() {
        if(Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_PART){
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart(){
        //Transform chosenLevelPart = levelPartListSpace[Random.Range(0, levelPartListSpace.Count)];
        //Transform chosenLevelPart = levelPartListRocket[Random.Range(0, levelPartListRocket.Count)];
        Transform chosenLevelPart = levelPartListAlienShip[Random.Range(0, levelPartListAlienShip.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition){
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
