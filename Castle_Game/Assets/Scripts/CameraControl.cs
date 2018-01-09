using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject target;
	public float view = 1.0f;

	void FixedUpdate ()
	{
		Vector3 moveCamTo = target.transform.position - target.transform.forward * 5 + Vector3.up * view;
		float bias = 0.96f;
		transform.position = transform.position * bias +
																		 moveCamTo * (1.0f - bias);
		transform.LookAt(target.transform.position);
	}

	void Update () {
		if(Input.GetKeyDown("o") && view == 1.0f) {
			view = 15.0f;
		}
		else if(Input.GetKeyDown("o") && view == 15.0f) {
			view = 1.0f;
		}
	}
}
