using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controls : MonoBehaviour {

	public int playerSpeed = 7;
	private bool facingRight = true;
	public int playerJumpPower = 1150;
	private float moveX;
	public bool isGrounded = false;
	private Vector3 originalSize = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {

		originalSize = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		//check player death
		if(gameObject.transform.position.y < -7){

			Die ();
		}

		playerMove ();
	}

	void playerMove(){
	
		//Controls
		moveX = Input.GetAxis ("Horizontal");

		if(Input.GetButtonDown("Jump") && isGrounded){

			Jump();
		}

		//Animations
		
		//Player Direction
		if((moveX > 0.0f && facingRight == false) || (moveX < 0.0f && facingRight == true)){

			FlipPlayer();
		}
		
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
		
	}

	void Jump(){

		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;

	}
	
	void FlipPlayer(){
			
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D col){

		//Debug.Log (col.collider.name);
		if (col.collider.tag == "Ground" || col.collider.name.Contains("platform")) {

			isGrounded = true;
		
		} else if (col.collider.tag == "Enemy") {

			Die ();

		} 
		else if (col.collider.tag == "LevelEnd") {

			SceneManager.LoadScene ("EndScreen001");
		}
			
	}

	void Die(){

		Debug.Log ("Player has Died!");
		gameObject.transform.localScale = originalSize;
		gameObject.transform.position = new Vector3 (-4.5f, -2.5f, gameObject.transform.position.z);
		facingRight = true;
	}
				
}
