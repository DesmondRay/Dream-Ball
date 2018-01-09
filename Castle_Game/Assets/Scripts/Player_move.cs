using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour {
	private CharacterController controller;
	private float verticalVelocity;
	private float gravity= 20.0f;
	private float jumpForce = 5.0f;
	public float speed = 2.0f;
	private float rotate;
	private float view = 1.0f;
	private bool gameState = true;


	public Quaternion rotation = Quaternion.identity;
	private void Start() {
		controller = GetComponent<CharacterController>();
		Debug.Log(GameObject.FindGameObjectsWithTag("Coin").Length);

	}
	Vector3 moveVector = Vector3.zero;
	private void Update() {
		rotation.eulerAngles = new Vector3(0, rotate, 0);
		// transform.rotation = Quaternion.Euler(0, rotate, 0);
		transform.rotation = rotation;

		if(Input.GetKeyDown("k")) {
			rotate = rotate + 90;
		}
		if(Input.GetKeyDown("l")) {
			rotate = rotate - 90;
		}
		if(Input.GetKeyDown("o") && view == 1.0f) {
			view = 15.0f;
		}
		else if(Input.GetKeyDown("o") && view == 15.0f) {
			view = 1.0f;
		}

		Vector3 moveCamTo = transform.position - transform.forward * 5 + Vector3.up * view;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias +
																		 moveCamTo * (1.0f - bias);
		Camera.main.transform.LookAt(transform.position);

		if(controller.isGrounded) {
			bias = 0.96f;
			verticalVelocity = -gravity * Time.deltaTime;
		//	if(Input.GetKeyDown(KeyCode.Space)) {
				//verticalVelocity = jumpForce;
			//}
		}
		else {
			verticalVelocity -= gravity * Time.deltaTime;
			bias = 100f;
		}

		moveVector = new Vector3(Input.GetAxis("Horizontal"), verticalVelocity, Input.GetAxis("Vertical"));
		moveVector = transform.TransformDirection(moveVector);
		moveVector *= speed;
		controller.Move(moveVector * Time.deltaTime);

		if (GameObject.FindGameObjectsWithTag("Coin").Length <= 0) {
			gameState = false;
		}

		if (gameState == false) {
			//Time.timeScale = 0.0f;
		}
	}

}
