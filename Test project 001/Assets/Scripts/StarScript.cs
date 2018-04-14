using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	public bool isActive = false;
	private int starSpeed = 2;
	private int xMoveDirection = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (isActive == true) {

			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * starSpeed;
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.tag == "Player" && isActive == false) {

			Destroy (gameObject.GetComponent<BoxCollider2D> ());
			gameObject.AddComponent<BoxCollider2D> ();
			StartCoroutine ("ActivateSelf");

		} else if (isActive == true) {

			if (col.collider.tag == "Obstacle") {

				Flip ();

			} else if (col.collider.tag == "Enemy") {

				Destroy (gameObject);

			} else if (col.collider.tag == "Player") {

				Destroy (gameObject);
				col.gameObject.transform.localScale = Vector3.Scale (col.gameObject.transform.localScale, new Vector3 (1.5f, 1.5f, 0));
				Vector2 S = col.gameObject.GetComponent<SpriteRenderer> ().sprite.bounds.size;
				col.gameObject.GetComponent<BoxCollider2D> ().size = S;

			}

		}

	}

	void Flip(){

		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
		xMoveDirection *= -1;
	}

	IEnumerator ActivateSelf(){

		isActive = true;

		//raise object above box
		for (int i = 0; i < 20; i++) {

			transform.Translate (Vector3.up * 0.05f);
			yield return new WaitForSeconds (0.025f);
		}

		gameObject.AddComponent<Rigidbody2D> ();
		Rigidbody2D starRigid = gameObject.GetComponent<Rigidbody2D> ();
		starRigid.freezeRotation = true;
		starRigid.gravityScale = 30;
	}
}
