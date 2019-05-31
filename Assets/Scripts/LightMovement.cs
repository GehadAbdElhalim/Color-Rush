using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

	private Light L;
	private float red;

	// Use this for initialization
	void Start () {
		L = GetComponent<Light>();
		red = L.color.r;
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Rotate(10,0,0);
		// red += 0.5f;
		// L.color = new Color(red,L.color.g,L.color.b,L.color.a);

	}
}
