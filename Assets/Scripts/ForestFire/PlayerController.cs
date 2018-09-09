using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
	private Rigidbody2D rb2d;

    void Start() {
        speed = 10;
        rb2d = GetComponent<Rigidbody2D>();
    }

	private void Update() {
		float moveInput = Input.GetAxis ("Horizontal");
		this.transform.Translate(Vector3.right * moveInput * Time.deltaTime * speed);
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name.Contains("Tree")) {
            GameObject treeObj = GameObject.Find(other.gameObject.name);
            TreeController tc = treeObj.GetComponent(typeof(TreeController)) as TreeController;
            if (tc.onFire) {
                tc.onFire = false;
                GameObject canvas = GameObject.Find("Canvas");
                CanvasController cc = canvas.GetComponent(typeof(CanvasController)) as CanvasController;
                cc.fireCount--;
            }
        }
    }
}
