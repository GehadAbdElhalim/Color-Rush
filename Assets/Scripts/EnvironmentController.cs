using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

	private float movementSpeed;
	private bool spawnedAnother ;
	// Use this for initialization
	void Start () {
		movementSpeed = GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();
		spawnedAnother = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// movementSpeed = GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();
		// transform.Translate(new Vector3(0,0,-1*movementSpeed*Time.deltaTime));
		// if (transform.position.z <= 0 && spawnedAnother == false){
		// 	GameObject.Find("GameManager").GetComponent<GameManager1>().spawnAnotherEnvironment = true;
		// 	spawnedAnother = true;
		// }
		// if(transform.position.z <= -180f){
		// 	Destroy(this.gameObject);
		// }
	}
}
