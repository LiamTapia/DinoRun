using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator anim;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool isTakingOff = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isRunning == false){
            isRunning = true;
            anim.SetBool("isRunning", true);
        } else if(Input.GetKeyDown(KeyCode.Space) && isRunning == true && isTakingOff == false){
            isJumping = true;
            isTakingOff = true;
            anim.SetTrigger("takeOff");
            anim.SetBool("isJumping", true);
        } else if(Input.GetKeyDown(KeyCode.Space) && isJumping == true && isTakingOff == true){
            isJumping = false;
            isTakingOff = false;
            anim.SetBool("isJumping", false);
        } else if(Input.GetKeyDown(KeyCode.X)){
            anim.SetTrigger("isHurt");
        } else if(Input.GetKeyDown(KeyCode.DownArrow) && isJumping == false && isTakingOff == false){
            anim.SetBool("isCrouching", true);
        } else if(Input.GetKeyUp(KeyCode.DownArrow) && isJumping == false && isTakingOff == false){
            anim.SetBool("isCrouching", false);
        }
    }
}
