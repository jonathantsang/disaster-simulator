using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTouchMovement : MonoBehaviour {

	float speed = 0.01f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
	}
}
