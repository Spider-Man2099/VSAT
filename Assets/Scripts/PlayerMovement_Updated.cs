using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement_Updated : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;
    public float swingSpeed; 
    public float groundDrag;

    public MovementState state;

    public enum MovementState
    {
        swinging
    }

    public bool swinging; 

    //Variables for mechanic 
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    public Transform orientation;

    float horizontalInput; 
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true; 
    }

   
    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); 

        MyInput();
        SpeedControl(); 

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0; 
        }
    }

    //Used to call physics calculations, runs every 0.02 seconds (50 times/s
    private void FixedUpdate()
    {
        MoverPlayer(); 
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        // when to jump 
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown); 
        }
    }

    private void MoverPlayer()
    {

        //calculate movement direction i.e. always walk in the direction the player is looking 
     //   moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);
        move = Camera.main.transform.TransformDirection(move);
        move = Vector3.ProjectOnPlane(move, Vector3.up);

        Vector3 camDir = Camera.main.transform.forward;
        camDir = Vector3.ProjectOnPlane(camDir, Vector3.up);

        // moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // only apply when on ground
        if (grounded)
        {
            //used to say moveDirection instead of move 
            rb.AddForce(move.normalized * moveSpeed * 10f, ForceMode.Force); //so player doesn't fall through ground 

            // only apply when jumping
        }
        else if (!grounded)
        {
            rb.AddForce(move.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
      
    }

    private void SpeedControl()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if it gets too high
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; 
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); 

    }

    private void ResetJump()
    {
        readyToJump = true; 
    }
}
