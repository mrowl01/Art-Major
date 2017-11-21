using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour {
	Rigidbody2D rigidBody;
	[SerializeField] float jump = 0.10f;
	[SerializeField] float speed= 0.50f; 

	private bool isJumping = false; 
	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		HoriMovement();

	}
	void FixedUpdate()
	{
		Jumping ();
	}

	void HoriMovement()
	{
		Vector3 movement; 

		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		movement.x = x;
		movement.y = 0;
		movement.z = 0; 
		transform.Translate (movement* speed); 
	}
	void Jumping()
	{
		if (CrossPlatformInputManager.GetButton("Jump") && isJumping == false)
			{
			isJumping = true; 
				rigidBody.AddForce(transform.up * jump);

			}
		isJumping = false;
	
	}
}
	