using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

	private Vector3 defaultPos;
	private Vector3 defaultScale;
	private float timeLeft;
  public float roundTime;

	// Use this for initialization
	void Start () {
		defaultPos = transform.position;
		defaultScale = transform.localScale;
		timeLeft = roundTime;
	}

	// Update is called once per frame
	void FixedUpdate () {
		timeLeft -= Time.deltaTime;

		if(timeLeft < 0) {
				gameObject.GetComponent<Collider>().enabled = true;
				gameObject.transform.localScale = defaultScale;
				gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				transform.position = defaultPos;
				timeLeft = roundTime;
		}
	}
}
