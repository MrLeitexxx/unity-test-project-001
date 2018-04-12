using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnePlatformMove : MonoBehaviour {

	private Vector2 direction = Vector2.right;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (direction * 0.03f);

		if (transform.position.x < 21.0f) {

			direction = Vector2.right;
		}

		if (transform.position.x > 27.0f) {

			direction = Vector2.left;
		}

	}
}
