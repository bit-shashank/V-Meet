using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=4;
    public float gravity=10.0f;
    Vector3 moveDir=Vector3.zero;
    CharacterController controller;
	public float jumpSpeed=20.0f;

    void Start(){
        controller=GetComponent<CharacterController>();
    }

    void Update(){
        if(controller.isGrounded){	
            float x=Input.GetAxis("Horizontal");
            float z=Input.GetAxis("Vertical");
            moveDir=transform.right*x +transform.forward*z;
            moveDir=moveDir*speed;
            if(Input.GetButtonDown("Jump")){
					moveDir.y=jumpSpeed;
			}
        }
		moveDir.y-=gravity*Time.deltaTime;
		controller.Move(moveDir*Time.deltaTime); 
    }

}