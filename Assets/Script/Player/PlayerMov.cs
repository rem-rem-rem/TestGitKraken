using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private CharacterController playerController;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float run = 5f;
    private bool in_Grounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private PlayerInput inputManager;
    private Animator animator;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("kronii").GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        in_Grounded = playerController.isGrounded;
        //Debug.Log(playerVelocity.y);


        if (in_Grounded && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) )
        {
            audioSource.enabled = true;
        }

        else
        {
            audioSource.enabled = false;
        }
    }

    // Update is called once per frame

    //receive the inputs for our PlayerInput.cs and apply them to our character controller
    public void PlayerMovement(Vector2 input)
    {
       // Debug.Log(input);
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        //Debug.Log("moveDirection = " + moveDirection);
        //Debug.Log("moveDirection_trans = " + transform.TransformDirection(moveDirection));
        if (Input.GetKeyDown(KeyCode.RightShift)) speed += run;
        playerController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (in_Grounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = -2f;
        }
        playerController.Move(playerVelocity * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }


    }

    public void Jump()
    {
        if(in_Grounded)
        {
            playerVelocity.y = Mathf.Sqrt( jumpHeight * -3.0f * gravity);
            Debug.Log(playerVelocity);
        }
    }



}

