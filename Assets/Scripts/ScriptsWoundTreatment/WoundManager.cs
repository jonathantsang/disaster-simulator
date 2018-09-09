using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WoundManager : MonoBehaviour {
    public GameObject stopBleed;
    public GameObject cleanWound;
    public GameObject coverWound;
    public GameObject done;
    public Text textWound;

	GameController GC;
	TimerController TC;

    List<GameObject> orderOfGame;
	// Use this for initialization
	void Start () {
        Instantiate(stopBleed, this.transform);
        orderOfGame = new List<GameObject>();

		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		TC = GameObject.FindGameObjectWithTag ("TimeController").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (orderOfGame.Count != 3)
        {
            orderOfGame.Add(GameObject.FindGameObjectWithTag("Pressure"));
            orderOfGame.Add(GameObject.FindGameObjectWithTag("Water"));
            orderOfGame.Add(GameObject.FindGameObjectWithTag("Bandage"));
        }

        GameObject[] tempArray = orderOfGame.ToArray();

        bool pressure = tempArray[0].GetComponent<ToolManagingWound>().hasBeenUsed;
        bool water = tempArray[1].GetComponent<ToolManagingWound>().hasBeenUsed;
        bool bandage = tempArray[2].GetComponent<ToolManagingWound>().hasBeenUsed;

        if (!pressure && !water && !bandage)
        {
            textWound.text = "Stop the bleeding";
        }
        else if (pressure && !water && !bandage)
        {
            textWound.text = "Clean the wound!";
            Instantiate(cleanWound, this.transform);
        }
        else if (pressure && water && !bandage)
        {
            textWound.text = "Cover the wound!";
            Instantiate(coverWound, this.transform);
        }
        else if (pressure && water && bandage)
        {
            textWound.text = "You did it!";
            Instantiate(done, this.transform);

			// Add to the GameController score
			print (TC.getCurTime());
			int currentTime =  Mathf.RoundToInt(TC.getCurTime());
			GC.addScore(currentTime);
			print (currentTime);

			// SceneManager.LoadScene(1);
			// Change the random number to something else
			// 2,3,4,5
			// This is scene 6
			int sceneNum = 0;
			do {
				sceneNum = Random.Range (2, 7);
			} while(sceneNum == 6);

			SceneManager.LoadScene (sceneNum);
        }
        else
        {
            print("You lost!");
			SceneManager.LoadScene ("GameOver");
        }
    }
}
