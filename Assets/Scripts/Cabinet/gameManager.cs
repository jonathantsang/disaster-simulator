using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
    List<Transform> listOfPositions;
    List<Vector3> listOfTransformPositions;
    public int random1;
    public int random2;
    public int random3;
    public int random4;
    public static bool pickCabinet = true;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;

    public GameObject cabinet;
    public GameObject medkit;
    public GameObject positionForDrawer;

    public Transform cab1;
    public Transform cab2;
    public Transform cab3;
    public Transform cab4;

    public Text toptext; 

    // Use this for initialization
    void Start () {

        if (pickCabinet)
        {
            toptext.text = "Pick a cabinet! Be sure to remember it";
            pos1 = Instantiate(positionForDrawer, new Vector3(-12, 10, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos2 = Instantiate(positionForDrawer, new Vector3(-3, 10, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos3 = Instantiate(positionForDrawer, new Vector3(6, 10, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos4 = Instantiate(positionForDrawer, new Vector3(-12, 6, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos5 = Instantiate(positionForDrawer, new Vector3(-3, 6, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos6 = Instantiate(positionForDrawer, new Vector3(6, 6, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos7 = Instantiate(positionForDrawer, new Vector3(12, 6, 0), new Quaternion(0, 0, 0, 0)).transform;
            pos8 = Instantiate(positionForDrawer, new Vector3(12, 10, 0), new Quaternion(0, 0, 0, 0)).transform;

            listOfPositions = new List<Transform>();
            listOfPositions.Add(pos1);
            listOfPositions.Add(pos2);
            listOfPositions.Add(pos3);
            listOfPositions.Add(pos4);
            listOfPositions.Add(pos5);
            listOfPositions.Add(pos6);
            listOfPositions.Add(pos7);
            listOfPositions.Add(pos8);

            Instantiate(medkit,  new Vector3(-10.41f, -0.18f, 0f), new Quaternion(0,0,0,0));

            random1 = Random.Range(0, listOfPositions.Count - 1);
            random2 = Random.Range(0, listOfPositions.Count - 1);

            while (random1 == random2)
            {
                random2 = Random.Range(0, listOfPositions.Count - 1);
            }

            random3 = Random.Range(0, listOfPositions.Count - 1);

            while (random1 == random3 || random2 == random3)
            {
                random3 = Random.Range(0, listOfPositions.Count - 1);
            }

            random4 = Random.Range(0, listOfPositions.Count - 1);

            while (random1 == random4 || random2 == random4 || random3 == random4)
            {
                random4 = Random.Range(0, listOfPositions.Count - 1);
            }

            PlayerPrefs.SetInt("Cabinet1", random1);
            PlayerPrefs.SetInt("Cabinet2", random2);
            PlayerPrefs.SetInt("Cabinet3", random3);
            PlayerPrefs.SetInt("Cabinet4", random4);

            //change this after
            cab1 = Instantiate(cabinet, listOfPositions[random1].transform).transform;
            cab1.gameObject.GetComponent<DrawerBehaviour>().whichAmI = random1;
            cab2 = Instantiate(cabinet, listOfPositions[random2].transform).transform;
            cab2.gameObject.GetComponent<DrawerBehaviour>().whichAmI = random2;
            cab3 = Instantiate(cabinet, listOfPositions[random3].transform).transform;
            cab3.gameObject.GetComponent<DrawerBehaviour>().whichAmI = random3;
            cab4 = Instantiate(cabinet, listOfPositions[random4].transform).transform;
            cab4.gameObject.GetComponent<DrawerBehaviour>().whichAmI = random4;
        }
        else
        {
            toptext.text = "Where was the medkit?";
            listOfTransformPositions = new List<Vector3>();
            listOfTransformPositions.Add(new Vector3(-12, 10, 0));
            listOfTransformPositions.Add(new Vector3(-3, 10, 0));
            listOfTransformPositions.Add(new Vector3(6, 10, 0));
            listOfTransformPositions.Add(new Vector3(-12, 6, 0));
            listOfTransformPositions.Add(new Vector3(-3, 6, 0));
            listOfTransformPositions.Add(new Vector3(6, 6, 0));
            listOfTransformPositions.Add(new Vector3(12, 6, 0));
            listOfTransformPositions.Add(new Vector3(12, 10, 0));

            print(PlayerPrefs.GetInt("CorrectCabinet"));
            Transform medkitObject = Instantiate(medkit, listOfTransformPositions[PlayerPrefs.GetInt("CorrectCabinet")], new Quaternion(0, 0, 0, 0)).transform;
            medkitObject.gameObject.GetComponent<MedkitBehaviour>().hasBeenPlaced = true;
            Instantiate(cabinet, listOfTransformPositions[PlayerPrefs.GetInt("Cabinet1")], new Quaternion(0,0,0,0));
            Instantiate(cabinet, listOfTransformPositions[PlayerPrefs.GetInt("Cabinet2")], new Quaternion(0, 0, 0, 0));
            Instantiate(cabinet, listOfTransformPositions[PlayerPrefs.GetInt("Cabinet3")], new Quaternion(0, 0, 0, 0));
            Instantiate(cabinet, listOfTransformPositions[PlayerPrefs.GetInt("Cabinet4")], new Quaternion(0, 0, 0, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
