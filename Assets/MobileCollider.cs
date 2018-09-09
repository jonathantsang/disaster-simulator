using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCollider : MonoBehaviour {

	public int dir;
	int speed = 40;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		float moveInput = dir;
		player.transform.Translate(Vector3.right * moveInput * Time.deltaTime * speed);
	}
}
