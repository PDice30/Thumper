using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rigidBody;

	public float fuseLength;
	public float blastForce;
	public float blastRadius;


	void Start () {
		fuseLength = 3.0f;
		blastForce = 1000f;
		blastRadius = 5f;
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		fuseLength -= Time.deltaTime;
		if (fuseLength <= 0) {
			//Find all the colliders that can interact with the explosion
			Collider2D[] colliders = Physics2D.OverlapCircleAll (new Vector2 (transform.position.x, transform.position.y), blastRadius);
			foreach (Collider2D c in colliders) {
				Rigidbody2D r = c.GetComponent<Rigidbody2D> ();
				//Find the rigidbodies that will interact with the explosion
				//Not sure if the != rigidbody
				if (r != null && r != rigidBody) {
					
					Vector2 distanceFromBlast = r.transform.position - gameObject.transform.position;
					Vector2 forceDirection = distanceFromBlast.normalized;
					float forceMagnitude = distanceFromBlast.magnitude;

					Debug.Log ("distanceMagnitude: " + forceMagnitude);

					Vector2 blastingForce = forceDirection * (blastForce / forceMagnitude);
					//blastingForce = new Vector2 (-blastingForce.x, -blastingForce.y);

					//Vector2 blastingForce = (blastRadius - forceMagnitude) * distanceFromBlast * blastForce;
					//blastingForce = new Vector2 (-blastingForce.x, -blastingForce.y);
					Debug.Log ("Blasting force: " + blastingForce);
					r.AddForce (blastingForce);
				}
			}

			Debug.Log ("BOOM");
			Destroy (gameObject);
		}
	}
}
