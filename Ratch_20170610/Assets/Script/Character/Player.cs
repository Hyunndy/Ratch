using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController> ();
        viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        
    }
}
