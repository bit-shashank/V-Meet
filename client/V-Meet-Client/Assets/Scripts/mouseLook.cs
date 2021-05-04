using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {

	public float  mouseSensitivity=200.0f;

	public Transform playerBody;

	float xRotation=0.0f;

	// Use this for initialization
	void Start () {
		Cursor.lockState=CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
		float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

		xRotation-=mouseY;
		xRotation=Mathf.Clamp(xRotation,20.0f,30.0f);
		transform.localRotation= Quaternion.Euler(xRotation,0.0f,0.0f);
		playerBody.Rotate(Vector3.up*mouseX);
	}
}
