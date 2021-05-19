using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbarBehaviour : Interactable
{
    private DinoCharacterController player;
    private GameObject ambar;
    // Start is called before the first frame update
    void Start()
    {
        player = DinoCharacterController.FindObjectOfType<DinoCharacterController>();
        ambar = GetComponent<GameObject>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEnter(Collider other)
    {
        player.ambar += 1;
        SoundManagerScript.PlaySound("ambar");
        //base.OnTriggerEnter(other);
        Destroy(gameObject);
    }

}
