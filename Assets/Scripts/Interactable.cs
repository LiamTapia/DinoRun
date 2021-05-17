using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(isInsideZone){
            Interact();
        }
    }

    public virtual void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player")){
            return;
        }
        isInsideZone = true;
    }

    virtual public void OnTriggerExit(Collider other) {
        if(!other.CompareTag("Player")){
            return;
        }
        isInsideZone = false;
    }

    public virtual void Interact(){

    }
}
