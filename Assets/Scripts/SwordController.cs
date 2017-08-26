using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour {

	public float speed;
	public Text countText;

	private Rigidbody sword;

	bool isShiftDown;
	bool isSpaceDown;

	private int count;

	// Use this for initialization
	void Start () {
		sword = GetComponent<Rigidbody>();
		count = 0;
		countText.text = "Count: " + count.ToString();
	}

	// Update is called once per frame
	void Update () {
		isShiftDown = Input.GetKey(KeyCode.LeftShift);
		isSpaceDown = Input.GetKey(KeyCode.Space);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.transform.localScale = new Vector3(0, 0, 0);
			other.gameObject.gameObject.GetComponent<Collider>().enabled = false;

			count = count + 1;
			countText.text = "Count: " + count.ToString();
		}
	}

	// Update is called
	void FixedUpdate() {

		if(!isShiftDown) {
			return;
		}

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float moveUp = 0.0f;

		bool isPlayerGrounded = transform.parent.GetComponent<PlayerController>().grounded;

		if(isSpaceDown && isPlayerGrounded) {
			moveUp = 0.4f;
		}

		Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

		sword.AddForce(movement * speed);
	}
}
