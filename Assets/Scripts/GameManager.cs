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
    public AudioSource ButtonSound;
    public GameObject GameOverScreen;

    private void Awake() {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();

        backGrounds[GameVariables.stageSelection - 1].SetActive(true);

        dinos[GameVariables.dinoSelection - 1].SetActive(true);

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

        ButtonSound.volume = VolumeVariables.SoundEffetcsVolume;

    }

    public void EndGame(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            //Restart();
            GameOverScreen.SetActive(true);
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
    
