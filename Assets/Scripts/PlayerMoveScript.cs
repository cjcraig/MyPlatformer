using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    //speed of the ship
    public Vector2 moveSpeed = new Vector2(5, 5);

    //these store the mvmnt and rigidbody
    private Vector2 movement;
    private Rigidbody2D body;


    //keep track of how long the jump button has been held
    private float jumpTime;

    //keep track of whether the player is touching ground (i.e., can jump)
    private bool canJump;

    //see if the player has already started jumping
    private bool isJumping;

    //this will be how fast the player moves up when jumping
    //TODO currently part of the "speed" param
    //public int jumpSpeed = 5;



    // Start is called before the first frame update
    void Start()
    {
        //get component, store reference
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }


        jumpTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //get axis info (0=idle, -1=left, +1=right)
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Jump");
        //TODO check if grounded to set canJump appropriately
        bool tryingJump = Input.GetButton("Jump");

        if (canJump && tryingJump)
        {
            isJumping = true;
        }

        if (isJumping)
        {
            jumpTime++;
        }
        else
        {
            inputY = 0;
        }



        //movement per direction (multiply direction by speed)
        movement = new Vector2(moveSpeed.x * inputX, moveSpeed.y * inputY);
    }

    //this is called on a fixed framerate
    void FixedUpdate()
    {
        

        //move it move it
        body.velocity = movement;

    }


}
