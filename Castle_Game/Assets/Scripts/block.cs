using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class block : MonoBehaviour {


	public Transform pos1;
	public Transform pos2;
	public Transform cube;
	Vector3 newPosition;
	public string currentState;
	public float smooth;
	public float resetTime;

	void Start() {
		ChangeTarget();
	}

	void FixedUpdate() {
		cube.position = Vector3.MoveTowards(cube.position, newPosition, smooth);
	}

	void ChangeTarget() {
		if (currentState == "moving to position 2") {
			currentState = "moving to position 1";
			newPosition = pos1.position;
		} else if (currentState == "moving to position 1") {
			currentState = "moving to position 2";
			newPosition = pos2.position;
		} else if (currentState == "") {
			currentState = "moving to position 2";
			newPosition = pos2.position;
		}
		Invoke("ChangeTarget", resetTime);
	}


}
