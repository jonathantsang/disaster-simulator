using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	GameController GC;
	Text scoreText;

	// Use this for initialization
	void Start () {
		GC = GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<GameController> (); 
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText").gameObject.GetComponent<Text> ();
		setScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setScoreText() {
		scoreText.text = "Your score is: " + GC.getScore ().ToString ();
	}
}
