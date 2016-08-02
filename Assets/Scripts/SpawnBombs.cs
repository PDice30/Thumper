using UnityEngine;
using System.Collections;

public class SpawnBombs : MonoBehaviour {

	public float timeToSpawn;
	public Bomb bomb;

	public int bombFrequency;

	// Use this for initialization
	void Awake () {
		bombFrequency = GameObject.Find ("OptionsAndPrefs").GetComponent<OptionsAndPrefs> ().bombFrequency;
	}
	void Start () {
		
		timeToSpawn = 1.0f * (-bombFrequency + 10);
	}
	
	// Update is called once per frame
	void Update () {
		if ((timeToSpawn -= Time.deltaTime) <= 0) {

			bomb.fuseLength = Random.Range (2.0f, 6.0f);
			bomb.blastForce = Random.Range (500f, 1500f);
			float newScale = Random.Range (2.0f, 5.0f);

			bomb.transform.localScale = new Vector3 (newScale, newScale, 0);

			float xPos = Random.Range (-13, 13);
			float yPos = Random.Range (-4, 12);

			Instantiate (bomb, new Vector3 (xPos, yPos, 0), Quaternion.identity);

			timeToSpawn = 1.0f * (-bombFrequency + 10);
		}

	}
}
