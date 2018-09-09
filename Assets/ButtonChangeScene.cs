﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour {

	public string sceneName;
	Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (changeScene);
		gameManager.pickCabinet = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeScene() {
		SceneManager.LoadScene (sceneName);
	}
}
