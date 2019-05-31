using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundColors : MonoBehaviour {

	private float r;
	private float g;
	private float b;

	private bool blue;
	private bool red;
	private bool green;

	public Material m;

	private float speed;
	// Use this for initialization
	void Start () {
		speed = 0.03f;
		r = m.color.r;
		g = m.color.g;
		b = m.color.b;
		blue = true;
		green = false;
		red = false;
		// print(b);
	}
	
	// Update is called once per frame
	void Update () {
		if (blue){
			b-= speed;
			r+= speed;
			m.SetColor("_Color",new Color(r,g,b,1));
			if(r >= 1){
				red = true;
				blue = false;
				green = false;
			}
		}
		if (red){
			r-= speed;
			g+= speed;
			m.SetColor("_Color",new Color(r,g,b,1));
			if(g >= 1){
				red = false;
				blue = false;
				green = true;
			}
		}
		if (green){
			b+= speed;
			g-= speed;
			m.SetColor("_Color",new Color(r,g,b,1));
			if(b >= 1){
				red = false;
				blue = true;
				green = false;
			}
		}
	}
}
