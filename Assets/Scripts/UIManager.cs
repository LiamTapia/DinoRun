using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private DinoCharacterController player;
    public List<Image> health;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Awake()
    {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(player.health){
            case 3: health[2].enabled = true;
                break;
            case 2: health[2].enabled = false;
                    health[1].enabled = true;
                break;
            case 1: health[1].enabled = false;
                break;
            case 0: health[0].enabled = false;
                break;
        }

        score.SetText(player.ambar.ToString());
    }
}
