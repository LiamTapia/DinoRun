using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask platformLayers;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;
    public float runSpeed = 8f;
    private bool jumpPressed;
    private float jumpTimer;
    private float jumpGracePeriod = 0.2f;
    public float gravity = -50f;
    public Animator animator;
    private CharacterController character;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;
    public float jumpHeight = 2f;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning == false && Input.GetButtonDown("Jump")){
            isRunning = true;
            animator.SetBool("isRunning", true);
        }else if(isRunning == true){
            horizontalInput = 1;
            //transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
            //Revisar si esta tocando el piso
            isGrounded = false;
            
            foreach(var groundCheck in groundChecks){
                if(Physics.CheckSphere(groundCheck.position, 0.1f, platformLayers, QueryTriggerInteraction.Ignore)){
                    isGrounded = true;
                    break;
                }
            }

            if(isGrounded && velocity.y < 0){
                velocity.y = 0;
                animator.SetBool("isJumping", false);
            } else{
                //Agregar gravedad
                velocity.y += gravity * Time.deltaTime;
            }

            //Verifica que no se atore en paredes
            var blocked = false;
            foreach(var wallCheck in wallChecks){
                if(Physics.CheckSphere(wallCheck.position, 0.01f, platformLayers, QueryTriggerInteraction.Ignore)){
                    blocked = true;
                    break;
                }
            }

            //Si no esta bloqueado en una pared sigue avanzando
            if(!blocked){
                character.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
            }

            //Salto
            jumpPressed = Input.GetButtonDown("Jump");

            if(jumpPressed){
                jumpTimer = Time.time;
            }

            if(isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod))){
                velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
                jumpTimer = -1;
                animator.SetTrigger("takeOff");
                animator.SetBool("isJumping", true);
            }

            //Si esta en el aire le dice al animator que esta saltando
            if(!isGrounded){
                animator.SetBool("isJumping", true);
            }

            //Velocidad vertical
            character.Move(velocity * Time.deltaTime);
        }
    }
}
