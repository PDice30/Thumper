using UnityEngine;
using System.Collections;

public class OptionsAndPrefs : MonoBehaviour {

	public int roundsLength; //In Minutes
	public int eventFrequency; // 1 - 5
	public int powerUpFrequency; // 1 - 9
	public int bombFrequency; // 1 - 9
	public int numberOfRounds; // 1, 3, 5, 7, 9

	void Start () {
		DontDestroyOnLoad (gameObject);
	}

}
