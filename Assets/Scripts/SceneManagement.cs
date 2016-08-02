using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour {

	// Use this for initialization
	//private GameObject mainButtonPanel;
	private Canvas mainCanvas;
	private Canvas optionsCanvas;

	public void Start() {
		
		//mainButtonPanel = GameObject.Find ("Main Button Panel");
		mainCanvas = GameObject.Find ("MainCanvas").GetComponent<Canvas>();
		optionsCanvas = GameObject.Find ("OptionsCanvas").GetComponent<Canvas>();

		//Might need a coroutine to make sure it all finds everything properly
		optionsCanvas.enabled = false;
	}

	public void transitionToMain() {
		transferOptionInformation ();

		SceneManager.LoadScene ("Main");
	}

	//Disable the canvas object instead?
	public void displayOptionsCanvas() {
		mainCanvas.enabled = false;
		optionsCanvas.enabled = true;


	}

	public void displayMainCanvas() {
		optionsCanvas.enabled = false;
		mainCanvas.enabled = true;

	}

	public void transferOptionInformation() {
		OptionsAndPrefsUI optionsUI = GameObject.Find ("OptionsAndPrefsUI").GetComponent<OptionsAndPrefsUI>();
		OptionsAndPrefs options = GameObject.Find ("OptionsAndPrefs").GetComponent<OptionsAndPrefs> ();

		options.roundsLength = (int)optionsUI.roundLength;
		options.eventFrequency = (int)optionsUI.eventFrequency;
		options.powerUpFrequency = (int)optionsUI.powerUpFrequency;
		options.bombFrequency = (int)optionsUI.bombFrequency;
		options.numberOfRounds = (int)optionsUI.numberOfRounds;


	}
}
