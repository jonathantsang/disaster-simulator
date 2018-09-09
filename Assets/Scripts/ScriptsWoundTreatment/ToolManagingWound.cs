using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManagingWound : MonoBehaviour {
    public bool hasBeenUsed;
	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseDown()
    {
        hasBeenUsed = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
