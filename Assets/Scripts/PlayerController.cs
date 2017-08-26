using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpPower;
	private Vector3 defaultPos;
	private bool grounded;

	private Rigidbody player;

	bool isShiftDown;
	bool isSpaceDown;

	// Use this for initialization
	void Start () {
		grounded = true;
		defaultPos = gameObject.transform.position;

		player = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		isShiftDown = Input.GetKey(KeyCode.LeftShift);
		isSpaceDown = Input.GetKeyDown(KeyCode.Space);

		if(!grounded && player.velocity.y == 0) {
         grounded = true;
    }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			gameObject.transform.position = new Vector3(0, 3, 0) + defaultPos;
		}
	}

	// Update is called
	void FixedUpdate() {

		if(isShiftDown) {
			return;
		}

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveUp = 0.0f;

		if (isSpaceDown && grounded == true) {
         moveUp = jumpPower;
         grounded = false;
				 Debug.Log("Jump!");
    }

		Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

		player.AddForce(movement * speed);
	}
}
