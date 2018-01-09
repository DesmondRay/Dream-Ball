using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
public Quaternion rotation = Quaternion.identity;
public float speed;
private Rigidbody rb;
private int count;
public float rotate;
public Text  countText;
public Text winText;

void Start()
{
	rb = GetComponent<Rigidbody>();
	winText.text = "";
}

void Update ()
{
	// Rotate the direction the player is facing
	if(Input.GetKeyDown("k")) {
		rotate = rotate + 90;
	}
	if(Input.GetKeyDown("l")) {
		rotate = rotate - 90;
	}
}

void FixedUpdate()
	{
		// Movement Axis
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// The direction the player is facing
		rotation.eulerAngles = new Vector3(0, rotate, 0);
		transform.rotation = rotation;

		// Player movement
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddRelativeForce(movement * speed);

		// Count how many coins are left
		count = GameObject.FindGameObjectsWithTag("Coin").Length;
		countText.text = "Coins Left: " + count.ToString();
		if (count <= 0) {
			winText.text = "Level Cleared!";
		}

	}

	void OnCollisionEnter (Collision collision) {
		rb.drag = 1;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coin")) {
				Destroy(other.gameObject);
				countText.text = "Coins Left: " + count.ToString();
		}
	}

}
