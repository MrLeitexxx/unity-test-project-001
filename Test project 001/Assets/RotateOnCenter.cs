using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (GetComponent<Renderer>().bounds.center, new Vector3(0,0,1), 100 * Time.deltaTime);
	}
}
