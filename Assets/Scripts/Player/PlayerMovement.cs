using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public CharacterController2D controller;

    public float runSpeed = 40f;
    public float mouseSpeed = 10f;
    public GameObject crossHair;

    private PlayerMovement player;

    float horizontalMove = 0f;
    bool Jump = false;
    Rigidbody2D rigid;
	
	bool flying = false;

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
			flying = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }


    }

    private void FixedUpdate()
    {
        //Move our Character and move the same amount regardless of the amount of times called
		if(!flying)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;
    }

    void MouseFollow()
    {
        rigid.bodyType = RigidbodyType2D.Static;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //USELESS//		Vector3 direction = mousePos - transform.position;		//USELESS//
        //USELESS//		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;		//USELESS//
        //USELESS//		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);		//USELESS//
        transform.position = Vector2.MoveTowards(transform.position, mousePos, mouseSpeed * Time.deltaTime);

    }


}
