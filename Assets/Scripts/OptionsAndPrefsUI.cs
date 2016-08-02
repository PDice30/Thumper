using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsAndPrefsUI : MonoBehaviour {



	public float roundLength = 5; //In Minutes
	public float eventFrequency = 3; // 1 - 5
	public float powerUpFrequency = 5; // 1- 9
	public float bombFrequency = 5; // 1 - 9
	public float numberOfRounds = 3; // 1, 3, 5, 7, 9


	public Slider roundLengthSlider;
	public Slider eventFrequencySlider;
	public Slider powerUpFrequencySlider;
	public Slider bombFrequencySlider;
	public Slider numberOfRoundsSlider;

	public Text roundLengthText;
	public Text eventFrequencyText;
	public Text powerUpFrequencyText;
	public Text bombFrequencyText;
	public Text numberOfRoundsText;

	void Awake() {
		//This could also jsut be linked in the inspector...
		//Should probably change this find all objects in the panel and just assign children
		roundLengthSlider = GameObject.Find ("RoundLengthSlider").GetComponent<Slider> ();
		roundLengthSlider.onValueChanged.AddListener (changeRoundLength);
		eventFrequencySlider = GameObject.Find ("EventFrequencySlider").GetComponent<Slider> ();
		eventFrequencySlider.onValueChanged.AddListener (changeEventFrequency);
		powerUpFrequencySlider = GameObject.Find ("PowerUpFrequencySlider").GetComponent<Slider> ();
		powerUpFrequencySlider.onValueChanged.AddListener (changePowerUpFrequency);
		bombFrequencySlider = GameObject.Find ("BombFrequencySlider").GetComponent<Slider> ();
		bombFrequencySlider.onValueChanged.AddListener (changeBombFrequency);
		numberOfRoundsSlider = GameObject.Find ("NumberOfRoundsSlider").GetComponent<Slider> ();
		numberOfRoundsSlider.onValueChanged.AddListener (changeNumberOfRounds);

		roundLengthText = GameObject.Find ("RoundLengthText").GetComponent<Text> ();
		eventFrequencyText = GameObject.Find ("EventFrequencyText").GetComponent<Text> ();
		powerUpFrequencyText = GameObject.Find ("PowerUpFrequencyText").GetComponent<Text> ();
		bombFrequencyText = GameObject.Find ("BombFrequencyText").GetComponent<Text> ();
		numberOfRoundsText = GameObject.Find ("NumberOfRoundsText").GetComponent<Text> ();
	}

	void Start () {
	}
	void Update () {
	}

	public void changeRoundLength(float value) {
		roundLengthText.text = "Round Length: " + value;
		roundLength = value;
	}
	public void changeEventFrequency(float value) {
		eventFrequencyText.text = "Event Frequency: " + value;
		eventFrequency = value;
	}
	public void changePowerUpFrequency(float value) {
		powerUpFrequencyText.text = "PowerUp Frequency: " + value;
		powerUpFrequency = value;
	}
	public void changeBombFrequency(float value) {
		bombFrequencyText.text = "Bomb Frequency: " + value;
		bombFrequency = value;
	}
	public void changeNumberOfRounds(float value) {
		numberOfRoundsText.text = "Number of Rounds: " + value;
		numberOfRounds = value;
	}
}
