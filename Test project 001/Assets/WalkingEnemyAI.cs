using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyAI : MonoBehaviour {

	private int enemySpeed = 2;
	private int xMoveDirection = -1;
	//private bool facingRight = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
//
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * enemySpeed;
//
//		if (hit.distance < 2.7f && hit.collider.tag == "Obstacle" ) {
//
//			Flip ();
//			Debug.Log ("Monster has collided with " + hit.collider.tag);
//		}

	}

	void OnCollisionEnter2D(Collision2D col){

		Debug.Log ("Monster has collided with " + col.collider.tag);

		if (col.collider.tag == "Obstacle" || col.collider.tag == "Enemy") {

			Flip ();
		}

	}

	void Flip(){

		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
		xMoveDirection *= -1;
	}
}
