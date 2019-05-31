using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0,0,0);
		// Vector3 targetPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x , transform.position.y , transform.position.z);
		// transform.position = Vector3.MoveTowards(transform.position,targetPos,10*Time.deltaTime);
        transform.rotation = rotation;
	}
}
