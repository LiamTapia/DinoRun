using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private DinoCharacterController player;
    public bool isPaused = false;
    public GameObject MenuPausa;

    // Start is called before the first frame update
    void Awake()
    {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            } else{
                PauseGame();  
            }
        }
    }

    public void PauseGame(){
        Time.timeScale = 0f;
        player.isRunning = false;
        player.animator.SetBool("isRunning", false);
        isPaused = true;
        MenuPausa.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        isPaused = false;
        MenuPausa.SetActive(false);
    }
}
