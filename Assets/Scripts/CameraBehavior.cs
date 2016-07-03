using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public Camera _camera;
	public bool isFollowing;

	public Vector3 originalPosition;

	void Start () {
		//Will need to do something about this with Prefabs
		player = GameObject.Find ("Player");
		//camera = gameObject.GetComponent<Camera> ();
		isFollowing = false;
		_camera = gameObject.GetComponent<Camera> ();

		originalPosition = _camera.transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		//Called every frame? woof
		if (isFollowing) {
			_camera.orthographicSize = 5;
			_camera.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		} else {
			_camera.transform.position = originalPosition;
			_camera.orthographicSize = 10;
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			Debug.Log ("PressedC");
			isFollowing = !isFollowing;
		}
	}
}
