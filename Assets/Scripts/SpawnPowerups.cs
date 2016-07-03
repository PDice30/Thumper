using UnityEngine;
using System.Collections;

public class SpawnPowerups : MonoBehaviour {

	//public ItemType itemType;
	public PlayerPowerup playerPowerUp;
	public Sprite[] playerPowerUpSprites = new Sprite[MainConstants.NUMBER_OF_PLAYER_POWERUPS];

	public int maxTimeToItemSpawn;
	public int currentTimeToItemSpawn;
	public int timeReduction;

	// Use this for initialization
	void Start () {
		maxTimeToItemSpawn = 120;
		currentTimeToItemSpawn = maxTimeToItemSpawn;
		timeReduction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeToItemSpawn -= timeReduction;

		if (currentTimeToItemSpawn <= 0) {
			int typeToSpawn = Random.Range (0, 5);
			//Debug.Log ("Current type to spawn = " + typeToSpawn); 

			float xPos = Random.Range (-10, 10);
			float yPos = Random.Range (-4, 10);

			playerPowerUp.setItemType((ItemType)typeToSpawn);
			playerPowerUp.setSprite(playerPowerUpSprites [typeToSpawn]);
			Instantiate (playerPowerUp, new Vector3(xPos, yPos, 0), Quaternion.identity);

			currentTimeToItemSpawn = maxTimeToItemSpawn;

		}
	}
}
