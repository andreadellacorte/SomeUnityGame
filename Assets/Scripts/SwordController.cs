using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

	public float speed;

	private Rigidbody sword;

	bool isShiftDown;
	bool isSpaceDown;

	// Use this for initialization
	void Start () {
		sword = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		isShiftDown = Input.GetKey(KeyCode.LeftShift);
		isSpaceDown = Input.GetKey(KeyCode.Space);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.transform.localScale = new Vector3(0, 0, 0);
		}
		Debug.Log("Collision");
	}

	// Update is called
	void FixedUpdate() {

		if(!isShiftDown) {
			return;
		}

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveUp = 0.0f;

		if(isSpaceDown) {
			moveUp = 0.4f;
		}

		Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

		sword.AddForce(movement * speed);
	}
}
