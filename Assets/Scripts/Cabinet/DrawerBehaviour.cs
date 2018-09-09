using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawerBehaviour : MonoBehaviour {
    public Transform frontDrawer;
    private Transform initialPosition;
    private bool isMouseOn;
    private bool hasMedkitBeenPlaced;
    public int drawerSpeed;
    public GameObject medkit;
    public bool isMedkitHere;
    public int whichAmI;
    public bool objectIsHere;

	GameController GC;
	TimerController TC;

    public bool enabledDrawer;
	// Use this for initialization
	void Start () {
        initialPosition = this.transform;
        isMouseOn = false;
        medkit = GameObject.FindGameObjectWithTag("MedKit");
        enabledDrawer = true;
		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		TC = GameObject.FindGameObjectWithTag ("TimeController").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (isMouseOn && frontDrawer.position.x > initialPosition.position.x - 4 && enabledDrawer) 
        {
            frontDrawer.Translate(Vector3.left * Time.deltaTime * drawerSpeed);
        }

        if ((!isMouseOn || !enabledDrawer) && frontDrawer.position.x < initialPosition.position.x)
        {
            frontDrawer.Translate(Vector3.right * Time.deltaTime * drawerSpeed);
        }

        if (!gameManager.pickCabinet)
        {
            enabledDrawer = false;
        }

        if (medkit.transform.position == this.transform.position)
        {
            objectIsHere = true;
        }
    }
    private void OnMouseDown()
    {
        if (enabledDrawer)
        {
            PlayerPrefs.SetInt("CorrectCabinet", whichAmI);
            isMedkitHere = true;
            medkit.GetComponent<MedkitBehaviour>().hasBeenPlaced = true;
            medkit.transform.position = initialPosition.position;
            enabledDrawer = false;
            //change the following

            Invoke("LoadScene", 0.05f);

            gameManager.pickCabinet = false;

        }

       else if (!gameManager.pickCabinet)
        {
            if (objectIsHere)
            {
                print("you win!");
                gameManager.pickCabinet = true;
                Invoke("LoadScene", 0.05f);
            }
            else
            {
                print("You lose!");
				Invoke ("LoseGame", 0.05f);
            }
        }
    }

    private void OnMouseEnter()
    {
        isMouseOn = true;
    }

    private void OnMouseExit()
    {
        isMouseOn = false;
    }

    private void LoadScene()
    {
		// Add to the GameController score
		print (TC.getCurTime());
		int currentTime =  Mathf.RoundToInt(TC.getCurTime());
		GC.addScore(currentTime);
		print (currentTime);

        // SceneManager.LoadScene(1);
		// Change the random number to something else
		// 3,4,5,6
		// This is scene 2
		int sceneNum = Random.Range(3,7);
		SceneManager.LoadScene (sceneNum);
    }

	private void LoseGame()
	{
		SceneManager.LoadScene ("GameOver");
	}
}
 