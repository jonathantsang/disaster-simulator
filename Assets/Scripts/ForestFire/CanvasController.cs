using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public GameObject player;
    public ArrayList trees;
    float timer, gameInterval, fireTimer, fireTimeInterval;
    public float fireCount;
	int treesNeededToLose = 2; // need 2+1 trees

	GameController GC;

	void Start () {
        trees = new ArrayList();
        timer = 0;
        gameInterval = 10;
        fireTimer = 0;
        fireTimeInterval = 2.5f;
        fireCount = 0;
        player = GameObject.Find("Player");
        for (int i = 0; i < 8; ++i) {
            GameObject tree = GameObject.Find("Tree" + i);
            trees.Add(tree);
        }

		GC = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		float level = GC.getLevel ();
		fireTimeInterval = Mathf.Max(fireTimeInterval - level * 0.1f, 1.5f);
    }

    private void Update() {
        fireTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (fireCount > treesNeededToLose) {
            print("Game over! You lose!");
			SceneManager.LoadScene ("GameOver");
            return;
        }
        if (timer > gameInterval) {
            print("Congratulations! You score is: " + (8 - fireCount));

			// Add to the GameController score
			print (8-fireCount);
			int currentTime =  Mathf.RoundToInt(8-fireCount);
			GC.addScore(currentTime);

			// SceneManager.LoadScene(1);
			// Change the random number to something else
			// 2,3,5,6
			// This is scene 4
			int sceneNum;
			do {
				sceneNum = Random.Range(2, 7);
			} while (sceneNum == 4);

			SceneManager.LoadScene (sceneNum);

            return;
        }
        if (fireTimer < fireTimeInterval) return;
        fireTimer = 0;
        System.Random randNum = new System.Random();
        int num1 = randNum.Next(0, 7);
        GameObject treeObject = GameObject.Find("Tree" + num1);
        TreeController tcontrol = treeObject.GetComponent(typeof(TreeController)) as TreeController;
        if (tcontrol.onFire) return;
        tcontrol.onFire = true;
        fireCount++;
    }
}
