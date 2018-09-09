using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	Text timerText;
	GameController GC;
	float timerAmt;

	// Use this for initialization
	void Start () {
		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		timerText = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text> ();
		timerAmt = GC.getTime ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timerText == null) {
			timerText = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text> ();
		} else {
			timerText.text = timerAmt.ToString();
			timerAmt -= Time.deltaTime;
			if (timerAmt < 0) {
				print ("failed");
				SceneManager.LoadScene ("GameOver");
			}
		}
	}

	public float getCurTime(){
		return timerAmt;
	}
}
