using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : Interactable
{
    private DinoCharacterController player;
    private bool damaged = false;
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
        if(player.health > 0 && damaged == false && player.isInvinsible == false){
            damaged = true;
            player.health -= 1;
            player.animator.SetTrigger("isHurt");
            SoundManagerScript.PlaySound("dinoHurt");
        }
    }
}
