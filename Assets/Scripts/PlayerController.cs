using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public bool grounded;
	private Vector3 defaultPos;

	private Rigidbody rb;

	bool isShiftDown;
	bool isSpaceDown;

	// Use this for initialization
	void Start () {
		Application.CaptureScreenshot("Screenshot.png", 4);
		defaultPos = gameObject.transform.position;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		isShiftDown = Input.GetKey(KeyCode.LeftShift);
		isSpaceDown = Input.GetKeyDown(KeyCode.Space);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			//gameObject.transform.position = new Vector3(0, 3, 0) + defaultPos;
		}
	}

	// Update is called
	void FixedUpdate() {

		float moveHorizontal = 0.0f;
		float moveVertical = 0.0f;
		float moveUp = 0.0f;

		grounded = Physics.Raycast(transform.position, -Vector3.up, 1);

		if(isShiftDown) {
			if(grounded) {
				rb.velocity = rb.velocity * 0.9f;
			}
			return;
		}

		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");

		if (isSpaceDown && grounded) {
         moveUp = jumpPower;
    }

		Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

		rb.AddForce(movement * speed);
	}
}
