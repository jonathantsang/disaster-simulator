using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiMovement : MonoBehaviour {

    public int TsunamiSpeed;

    // Use this for initialization
    void Start()
    {
    }

    private void Update()
    {
        this.transform.position = this.transform.position + (Vector3.right * Time.deltaTime * TsunamiSpeed);
    }
}
