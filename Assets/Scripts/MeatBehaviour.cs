using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBehaviour : Interactable
{
    private DinoCharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        if(player.health < player.maxHealth){
            player.health += 1;
        }
        SoundManagerScript.PlaySound("munch");
        Destroy(gameObject);
    }
}
