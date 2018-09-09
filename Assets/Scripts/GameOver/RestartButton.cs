using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	Button btn;
	GameController GC;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (goBackToMainMenu);

		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void goBackToMainMenu(){
		GC.setLevel (0);
		GC.setScore (0);

		// Random from scenes that are facts
		// 7, 8, 9, 10
		int sceneNum = Random.Range(7,11);
		SceneManager.LoadScene (sceneNum);
	}
}
