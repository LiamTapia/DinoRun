using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBehaviour : Interactable
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
    public override void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Pickup(other));
    }

    IEnumerator Pickup(Collider other){
        player.isInvinsible = true;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5);
        player.isInvinsible = false;
        Destroy(gameObject);
    }
}
