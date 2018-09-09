using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour {

    public bool onFire;
    private Color32 origColor;

	void Start () {
        onFire = false;
        origColor = gameObject.GetComponent<Image>().color;
    }
	
	void Update () {
        if (onFire) gameObject.GetComponent<Image>().color = Color.red;
        else gameObject.GetComponent<Image>().color = origColor;
	}
}
