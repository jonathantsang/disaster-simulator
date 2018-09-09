using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TsunamiBuilding : MonoBehaviour {
    private int atBuilding = 0;
    private int buildingType = 0;

	GameController GC;

	// Use this for initialization
	void Start () {
		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
        if ((atBuilding == 1) && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            print("here");
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if (touchDeltaPosition.y > 1)
            {
                if (buildingType == 4)
                {
                    print("You win!!");

					// Next one
					GC.addScore(4);
					print (4);

					// SceneManager.LoadScene(1);
					// Change the random number to something else
					// 2,3,4,6
					// This is scene 5
					int sceneNum;
					do {
						sceneNum = Random.Range (2, 7);
					} while(sceneNum == 5);

					SceneManager.LoadScene (sceneNum);
                }
                else
                {
                    print("You lose :( ");
					SceneManager.LoadScene ("GameOver");
                }
            }
        };

        if (atBuilding == 1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
			if (buildingType == 4)
			{
				print("You win!!");

				// Next one
				GC.addScore(4);
				print (4);

				// SceneManager.LoadScene(1);
				// Change the random number to something else
				// 2,3,4,6
				// This is scene 5
				int sceneNum;
				do {
					sceneNum = Random.Range (2, 7);
				} while(sceneNum == 5);

				SceneManager.LoadScene (sceneNum);
			}
            else
            {
                print("You lose :( ");
				SceneManager.LoadScene ("GameOver");
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atBuilding = 1;
        string buildingTag = gameObject.tag;
        switch (buildingTag)
        {
            case "B1":
                buildingType = 1;
                break;
            case "B2":
                buildingType = 2;
                break;
            case "B3":
                buildingType = 3;
                break;
            case "B4":
                buildingType = 4;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        atBuilding = 0;
    }
}
