using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FactButton : MonoBehaviour {

	Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (randomFact);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void randomFact() {
		// 7, 8, 9, 10
		// facts
		int sceneNum = Random.Range(7, 11);
		SceneManager.LoadScene (sceneNum);
	}
}
