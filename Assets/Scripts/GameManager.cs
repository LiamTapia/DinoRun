using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public List<GameObject> backGrounds;
    public List<GameObject> dinos;
    private DinoCharacterController player;
    public List<AudioSource> music;

    private void Awake() {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();

        backGrounds[GameVariables.stageSelection - 1].SetActive(true);
        /*switch(GameVariables.stageSelection){
            case 1: backGrounds[0].SetActive(true);
                break;
            case 2: backGrounds[1].SetActive(true);
                break;
            case 3: backGrounds[2].SetActive(true);
                break;
        }*/

        dinos[GameVariables.dinoSelection - 1].SetActive(true);
        /*switch(GameVariables.dinoSelection){
            case 1: dinos[0].SetActive(true);
                break;
            case 2: dinos[1].SetActive(true);
                break;
            case 3: dinos[2].SetActive(true);
                break;
            case 4: dinos[3].SetActive(true);
                break;
            case 5: dinos[4].SetActive(true);
                break;
            case 6: dinos[5].SetActive(true);
                break;
            case 7: dinos[6].SetActive(true);
                break;
            case 8: dinos[7].SetActive(true);
                break;
            case 9: dinos[8].SetActive(true);
                break;
        }*/

        switch(GameVariables.difficultySelection){
            case 1: player.runSpeed = 8;
                break;
            case 2: player.runSpeed = 10;
                break;
            case 3: player.runSpeed = 12;
                break;
        }

        music[GameVariables.musicSelection - 1].Play();
        music[GameVariables.musicSelection - 1].volume = VolumeVariables.MusicVolume;
        /*switch(GameVariables.musicSelection){
            case 1: music[0].Play();
                    music[0].volume = VolumeVariables.MusicVolume;
                break;
            case 2: music[1].Play();
                break;
            case 3: music[2].Play();
                break;
        }*/
    }

    public void EndGame(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            Restart();
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
    
