using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
	Vector3 pos1;
	Vector3 pos2;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 60 * Time.deltaTime, 0);
	}
}
