using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthquakeCol : MonoBehaviour {

	public int choice;
	GameController GC;
	TimerController TC;

	// Use this for initialization
	void Start () {
		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		TC = GameObject.FindGameObjectWithTag ("TimeController").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		print ("choice " + choice);
		if (choice == 1) {
			// correct
			// Add to the GameController score
			print (TC.getCurTime());
			int currentTime =  Mathf.RoundToInt(TC.getCurTime());
			GC.addScore(currentTime);
			print (currentTime);

			// SceneManager.LoadScene(1);
			// Change the random number to something else
			// 2,4,5,6
			// This is scene 3
			int sceneNum = 0;
			do {
				sceneNum = Random.Range (2, 7);
			} while (sceneNum == 3);
			SceneManager.LoadScene (sceneNum);

		} else {
			// fail
			SceneManager.LoadScene ("GameOver");
		}
	}
}
