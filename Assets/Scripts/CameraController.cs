using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3(followTarget.transform.position.x , transform.position.y , transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position,targetPos,15*Time.deltaTime);
	}
}
