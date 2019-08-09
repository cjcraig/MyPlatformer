using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    //speed of the ship
    public Vector2 moveSpeed = new Vector2(0.5f, 0.5f);
    public float fallspeed = 0.1f;

    //where the player starts
    public Vector2 startPosition ;

    //these store the mvmnt and rigidbody and collider
    private Vector2 movement;
    private Rigidbody2D body;
    private BoxCollider2D thisCollider;

    //see if player is dead
    private bool isded;

    //location at which player will spawn
    public Vector2 spawnLoc;
    //keep track of how long the jump button has been held
    public float jumpTime;

    //keep track of whether the player is touching ground (i.e., can jump)
    private bool canJump;

    //see if the player has already started jumping
    public bool isJumping;

    //this will be how fast the player moves up when jumping
    //TODO currently part of the "speed" param
    //public int jumpSpeed = 5;

    float distToGround;

    //used for the max distance for grounded-ness
    private const float maxDister = 0.1f;

    public LayerMask groundLayer;


    bool isGrounded()
    {

        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + maxDister, groundLayer);

    }

    public void respawn()
    {
        isded = true;
        movement = new Vector2(0, 0);
        body.transform.position = spawnLoc;
    }

    // Start is called before the first frame update
    void Start()
    {
        //get component, store reference
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }

        if(thisCollider == null)
        {
            thisCollider = GetComponent<BoxCollider2D>();
        }

        if(startPosition == null)
        {
            startPosition = new Vector2(0, 0);
        }

        if (spawnLoc == null)
        {
            spawnLoc = new Vector2(-10, 0);

        }

        distToGround = thisCollider.bounds.extents.y;

        body.transform.position = startPosition;

        movement = startPosition;

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

        //check if player is touching ground; if so, they can jump and are not jumping
        if (isGrounded())
        {
            isJumping = false;
            jumpTime = 0;
            canJump = true;
        }

        //player can only jump for so long, then they can't continue moving upwards by jumping
        if(jumpTime > 10)
        {
            canJump = false;
        }

        //if the player is able to jump higher and is pressing the right key, they are jumping.
        //otherwise, they are not jumping (i.e., moving upwards)
        if (canJump && tryingJump)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        //if they're jumping, add to the timer. If they're not jumping, they're not moving upwards
        if (isJumping)
        {
            jumpTime++;
        }
        else
        {
            
            inputY = 0;
        }



        //movement per direction (multiply direction by speed)
        movement += new Vector2(moveSpeed.x * inputX, moveSpeed.y * inputY);

        //if not in the air, they should fall
        if (!isGrounded())
        {
            movement -= new Vector2(0, fallspeed);
        } 
        
        
        
    }

    //this is called on a fixed framerate, ie for physics
    void FixedUpdate()
    {
        if (isded)
        {
            Debug.Log("I got here");
            movement = new Vector2(0, 0);
        }
       //move it move it
        body.transform.position = movement;
    }


}
