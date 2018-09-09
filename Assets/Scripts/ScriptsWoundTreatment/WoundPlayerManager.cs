using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundPlayerManager : MonoBehaviour {
    GameObject[] Spawners;
    public GameObject Bandage;
    public GameObject Water;
    public GameObject ApplyPressure;
	// Use this for initialization
	void Start ()
    {
        Spawners = GameObject.FindGameObjectsWithTag("ToolSpawn");
        int rando1 = Random.Range(0, 3);
        int rando2 = Random.Range(0, 3);
        while(rando1 == rando2)
        {
            rando2 = Random.Range(0, 3);
        }
        int rando3 = Random.Range(0, 3);
        while(rando1 == rando3 || rando2 == rando3)
        {
            rando3 = Random.Range(0, 3);
        }

        Instantiate(Bandage, Spawners[rando1].transform);
        Instantiate(Water, Spawners[rando2].transform);
        Instantiate(ApplyPressure, Spawners[rando3].transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
