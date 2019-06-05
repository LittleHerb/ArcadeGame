using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public CharacterController2D controller;

    #region GroundedCheck
    // For overlap circle to check if player is grounded
    /*public var top_left = Transform; // Overlap uses positions to make a rectangle, needs two points to make
	public var bottom_right = Transform;// part of positions for overlap rectangle
	public var ground_layers = LayerMask; // to check for object layers*/
    public Transform topLeft;
    public Transform bottomRight;
    public LayerMask groundLayers;

    //var grounded = bool;
    public bool grounded = false;
    #endregion

    public float runSpeed = 40f;
    public float mouseSpeed = 10f;
    public float groundDistance;
    public float groundedTime = 0.2f;

    public bool canPhase = true;

    private PlayerMovement player;

    float horizontalMove = 0f;
    bool Jump = false;
    Rigidbody2D rigid;

    bool flying = false;
    public float timer, maxTime;

    public float phaseTimeAllowedNotGrounded = .2f;
    public float elapsedTimeNotGrounded = 0; // Count up when you are not grounded

    // Perform the phase action
    public void Phase(bool canPhase)
    {
        // If setting to true
        if (canPhase)
        {
            // Do this
            rigid.bodyType = RigidbodyType2D.Kinematic;
            rigid.velocity = Vector2.zero;
        }
        // If setting to false
        else
        {
            // Do that
            flying = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    #endregion
    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsGrounded();

        if (grounded)
        {
            elapsedTimeNotGrounded = 0;
        }
        else
        {
            elapsedTimeNotGrounded += Time.deltaTime;
            
        }


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }

        if (Input.GetButton("Fire1"))
        {
            flying = true;
            MouseFollow();
        }

        else
        {
            timer = 0;
            flying = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void FixedUpdate()
    {

        //Move our Character and move the same amount regardless of the amount of times called
        if (!flying)
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;
    }

    void MouseFollow()
    {
        // Is the Player able to Phase
        if (canPhase)
        {
            timer += Time.deltaTime;
            if (timer <= maxTime && elapsedTimeNotGrounded < phaseTimeAllowedNotGrounded)
            {
                Phase(true);

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //USELESS//		Vector3 direction = mousePos - transform.position;		//USELESS//
                //USELESS//		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;		//USELESS//
                //USELESS//		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);		//USELESS//
                transform.position = Vector2.MoveTowards(transform.position, mousePos, mouseSpeed * Time.deltaTime);
            }
            else
            {
                Phase(false);
            }
        }

    }

    public void IsGrounded()
    {
        //Uses overlap variables in variables region to create a overlap around the player to check if grounded
        grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);

    }


}
