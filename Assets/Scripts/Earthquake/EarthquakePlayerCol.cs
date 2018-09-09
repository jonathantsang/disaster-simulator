using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakePlayerCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		print (coll);
		if (coll.gameObject.tag == "EarthquakeObstacle")
		{
			
		}
	}
}
