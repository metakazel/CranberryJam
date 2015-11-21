﻿using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {
	static public Rope S;
	public Vector3 objective;
	
	public int num_ropes = 1;
	public bool arrived = false;
	private float temp;
	private float trans;
	public float radius;
	public bool roping;

	void Awake()
	{
		S = this;
	}

	// Use this for initialization
	void Start () {
		//radius = 0.45f;//GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire3")) {
			Crosshair.S.aiming = true;
		}



		else if (roping) {
			if (arrived) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;
			} else {
				if (trans > 0.9f) {
					trans = 0f;
					arrived = true;
					roping = false;
					Crosshair.S.aiming = false;
					gameObject.GetComponent<Rigidbody2D> ().gravityScale = temp;

				} else {
					trans += 0.1f;
					transform.position = Vector3.Lerp (transform.position, new Vector3 (objective.x, objective.y, 0f), trans);
				}
			}
		}
	}

	public void moveToRope()
	{
		roping = true;
		arrived = false;
		temp = gameObject.GetComponent<Rigidbody2D>().gravityScale;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		trans = 0.0f;
		//transform.position = Vector3.Lerp(transform.position, target.position, );
	
	}
}
