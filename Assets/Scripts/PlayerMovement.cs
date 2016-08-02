using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//TODO: Serialize a lot of fields, convert to private variables but still exposed in editor.
	// Use this for initialization
	public Rigidbody2D rigidBody;

	Animator anim;

	//Will need to rewrite a lot of this due to augments
	public bool isAirborne;
	public bool isDashing;

	public float dashTime;
	public float beginDashTime;

	public int currentJumps;
	public int currentDashes;

	public int maxJumps;
	public int maxDashes;

	[Range(2.0f, 50.0f)]
	public float maxVelocity;

	public float accelerationForce;
	public float jumpingForce;

	public float gravity;


	public float verticalSpeed;


	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		isDashing = false;
		isAirborne = true;
		maxJumps = 2;
		currentJumps = 2;
		maxDashes = 3;
		currentDashes = 3;
		dashTime = 0.0f;
		maxVelocity = 10f;
		accelerationForce = 20;
		jumpingForce = 700;
		gravity = rigidBody.gravityScale;
	}

	// Update is called once per frame
	void Update () {

		//Delta Time 

		//KeyCode.W replaced by player settings for Jump
		//Using a command type?
		if (Input.GetKeyDown(KeyCode.Space) && currentJumps != 0) {
			if (isAirborne) {
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 0);
				rigidBody.AddForce(new Vector2(0, jumpingForce));
				currentJumps -= 1;
			} else {
				rigidBody.AddForce(new Vector2(0, jumpingForce));
				currentJumps -= 1;
				isAirborne = true;
			}

		}

		//Air Dash
		if (Input.GetKeyDown(KeyCode.K) && isAirborne && currentDashes != 0 && !isDashing) {
			isDashing = true;
			playerAirdash ();
		}


		if (isDashing) {
			if ((dashTime -= Time.deltaTime) < 0) {
				if (gameObject.GetComponent<ConstantForce2D> () != null) {
					Destroy (gameObject.GetComponent<ConstantForce2D> ());
					rigidBody.gravityScale = gravity;
					isDashing = false;
				}
			}
		}

		anim.SetFloat ("PlayerSpeed", rigidBody.velocity.x);

		verticalSpeed = rigidBody.velocity.y;

	}

	//TODO: Could put a trigger right above platforms and a collider on the player's feet when they hit that trigger to reset jumps.


	//Reading these commands can be MISSED because they are in fixed update - only forces that are one offs need to be in normal update, like jump
	void FixedUpdate () {
		

		if (Input.GetKey(KeyCode.A)) { // Left
			rigidBody.AddForce (new Vector2 (-accelerationForce, 0));
		} else if (Input.GetKey(KeyCode.D)) { // Right
			rigidBody.AddForce (new Vector2 (accelerationForce, 0));

		}

	
		checkSpeed ();
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Ground" && currentJumps != maxJumps) {
			//Debug.Log("Hit ground");
			currentJumps = maxJumps;
			currentDashes = maxDashes;
			isAirborne = false;
		}
		if (coll.gameObject.tag == "PlayerPowerup") {
			getPowerup (coll.gameObject.GetComponent<PlayerPowerup>());
			Destroy (coll.gameObject);
		}
	}

	//This seems bad - testing for now
	/*
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Platform" && currentJumps != maxJumps && rigidBody.velocity.y <= 0) {
			//Debug.Log("Hit ground");
			currentJumps = maxJumps;
			currentDashes = maxDashes;
			isAirborne = false;
		}
	}
*/
	/* May be costly */
	void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject.tag == "Platform" && currentJumps != maxJumps && rigidBody.velocity.y <= 0) {
			//Debug.Log("Hit ground");
			currentJumps = maxJumps;
			currentDashes = maxDashes;
			isAirborne = false;
		}
	}


	//Will need to add a check to not stop velocity if thrown by something like a bomb.
	void checkSpeed() {
		
		if (Mathf.Abs(rigidBody.velocity.x) > maxVelocity) {
			if (rigidBody.velocity.x > 0) {
				//Just set it to a new vector?
				Vector2 newVelocity = new Vector2 (maxVelocity, rigidBody.velocity.y);
				rigidBody.velocity = newVelocity;
			} else {
				Vector2 newVelocity = new Vector2 (-maxVelocity, rigidBody.velocity.y);
				rigidBody.velocity = newVelocity;
			}
		}
	}

	void getPowerup(PlayerPowerup powerup) {
		switch (powerup.getItemType()) {
		case ItemType.Acceleration:
			accelerationForce += 5;
			break;
		case ItemType.Defense:
			//accelerationForce += 5;
			break;
		case ItemType.JumpForce:
			jumpingForce += 50;
			break;
		case ItemType.MaxJumps:
			maxJumps += 1;
			break;
		case ItemType.MaxSpeed:
			maxVelocity += 1;
			break;
		case ItemType.Power:
			//accelerationForce += 5;
			break;
		}
	}

	//Commands? Pass back instructions to the player object for buttons

	//Augments - How will they work with commands?  Players have different movement options based on their augments.

	//Testing airdash for fun: 'K' will input air dash
	void playerAirdash() {
		float currentDirection = rigidBody.velocity.x;
		rigidBody.velocity = new Vector2 (0, 0);
		gameObject.AddComponent<ConstantForce2D> ();


		if (Input.GetKey (KeyCode.A)) { // Dash Left
			gameObject.GetComponent<ConstantForce2D> ().force = new Vector2 (-150, 0);
		} else if (Input.GetKey (KeyCode.D)) { // Dash Right
			gameObject.GetComponent<ConstantForce2D> ().force = new Vector2 (150, 0);
		} else { // Dash the direction they are currently traveling
			if (currentDirection < 0) {
				gameObject.GetComponent<ConstantForce2D> ().force = new Vector2 (-150, 0);
			} else {
				gameObject.GetComponent<ConstantForce2D> ().force = new Vector2 (150, 0);
			}
		}


		rigidBody.gravityScale = 0;

		//Add a timer
		//beginDashTime = Time.time;

		//Dash Time will be set by Augment as well as Dash Speed, # of dashes etc.
		dashTime = 0.5f;
		currentDashes -= 1;


	}


	//TODO: Make sure everything is being passed correctly and look into the PlayerPowerup Script
}
