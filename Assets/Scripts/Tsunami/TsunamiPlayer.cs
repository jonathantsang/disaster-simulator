using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiPlayer : MonoBehaviour {
    public int TsunamiPlayerSpeed;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    /*
	void Update () {
        rb.transform.Translate()
        float distance = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * distance);
    }
    */
    private void Update()
    {
        this.transform.position = this.transform.position + (Vector3.right * Time.deltaTime * TsunamiPlayerSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        print("!!!!");
    }


}
