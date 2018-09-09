using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	int score = 0;
	float level = 0f;
	float time = 8f;

	public static GameController instance;

	public Sprite correct;
	public Sprite incorrect;
	GameObject resultIcon;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CompleteLevel(){
		score++;
	}

	public void FailLevel() {
		// Go to the game over
	}

	public float getTime() {
		return Mathf.Max(time - level, 3f);
	}

	public int getScore() {
		return score;
	}

	public void addScore(int amt){
		score += amt;
		level++;
	}

	public float getLevel(){
		return level;
	}

	public void setLevel(int lvl){
		level = lvl;
	}

	public void setScore(int scr){
		score = scr;
	}
}
