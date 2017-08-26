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
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft < 0) {
				gameObject.transform.localScale = defaultScale;
				transform.position = defaultPos;
				timeLeft = roundTime;
		}
	}
}
