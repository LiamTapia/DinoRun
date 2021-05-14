using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformslayerMask;
    public Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float horizontalInput;
    
    public float jumpVelocity = 10f;
    private bool isRunning = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        rb = transform.GetComponent<Rigidbody2D>(); 
        bc = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isRunning == true){
            horizontalInput = 1;
            //transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) -1);
            rb.MovePosition(new Vector2(rb.transform.position.x + horizontalInput, rb.transform.position.y) * Time.deltaTime);
        }*/
        if(isRunning == false && Input.GetKeyDown(KeyCode.Space)){
            isRunning = true;
            anim.SetBool("isRunning", true);
        } else if(IsGrounded() && isRunning == true && Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("takeOff");
            anim.SetBool("isJumping", true);
            isJumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
        } else if(IsGrounded() && isJumping == true){
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
        if(!IsGrounded()){
            anim.SetBool("isJumping", true);
            isJumping = true;
        }

        HandleMovement();
    }

    private bool IsGrounded(){
        RaycastHit2D raycast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, platformslayerMask);
        Debug.Log(raycast.collider);
        return raycast.collider != null;
    }

    private void HandleMovement(){
        float moveSpeed = 10f;
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else{
            if(Input.GetKey(KeyCode.RightArrow)){
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            } else{
                //No se presiono nada
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}
