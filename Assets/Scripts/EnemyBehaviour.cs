using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	private float movementSpeed;

	// Use this for initialization
	void Start () {
		movementSpeed = GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		movementSpeed = GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();
		transform.Translate(new Vector3(0,0,-1*movementSpeed*Time.deltaTime));
		if(transform.position.z <= -20f){
			Destroy(this.gameObject);
		}
	}
}
